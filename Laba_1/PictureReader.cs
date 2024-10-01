namespace Laba_1 {
    public class PictureReader {
        // Путь до файла
        public string Path { get; private set; }
        // Штрина изображения
        public int Width { get; private set; }
        // Длинна изображения
        public int Height { get; private set; }
        // Считанная часть изображения в 2-байтовом виде (кэш)
        public ushort[,] CachePixels { get; private set; }
        // Y-координата верхней строки экрана при последней отрисовке
        private ushort cacheTopRow = 0;
        // Кол-во строк, сохраняемых в кэш
        private ushort cacheRowsCount;
        // Тип файла(в тестовом ширина и высота 2 байта, в фулл 4 байта)
        private readonly bool testVersion;
        // Поток работы с файлом
        private FileStream fstream;

        /// <summary>
        /// Сразу считывает информацию о изображении
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public PictureReader(string path, ushort cacheRowsCount, bool testVersion) {
            Path = path;
            this.cacheRowsCount = cacheRowsCount;
            this.testVersion = testVersion;
            ReadInformation();
            CreateCache();
        }

        /// <summary>
        /// Выдаёт матрицу яркости пикселей избражения с данным битовым сдвигом в байт формате
        /// </summary>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количество строк</param>
        /// <param name="bitShift">Битовый сдвиг</param>
        /// <returns>Матрица яркости пикселей</returns>
        public byte[,] GetPicture(ushort topRow, ushort rowsCount, byte bitShift) {
            // Если изображение есть в кэше, просто выдаём его в byte со сдвигом
            if(InCache(topRow, rowsCount))
                return ConvertPictureToByte(topRow, rowsCount, bitShift);
            MessageBox.Show("Подгрузка");
            // Обновляем кэшированную часть изображения
            ushort newCacheTopRow = CalcTopRow((ushort)(topRow + rowsCount / 2));
            CachePixels = TryCopyAndRead(newCacheTopRow, cacheRowsCount);
            // Сохраняем Y-координату верхней строки кешированной части изображения
            cacheTopRow = newCacheTopRow;
            // Возврщаем конвертированное в byte со сдвигом изображение
            return ConvertPictureToByte(topRow, rowsCount, bitShift);
        }

        /// <summary>
        /// Метод изменения кол-ва строк, сохраняемых в кэше
        /// </summary>
        /// <param name="newCount">Новое кол-во строк</param>
        public void UpdateCacheRowsCount(ushort newCount)
        {
            cacheRowsCount = newCount;
            if(cacheTopRow + cacheRowsCount < Height)
                CachePixels = TryCopyAndRead(cacheTopRow, cacheRowsCount);
            else
                CachePixels = TryCopyAndRead((ushort)(Height - cacheRowsCount), cacheRowsCount);
        }

        /// <summary>
        /// Яркость пикселя по координатам
        /// </summary>
        /// <param name="row">Строка(Y)</param>
        /// <param name="col">Столбец(Х)</param>
        /// <returns></returns>
        public ushort PixelLuminance(int row, int col)
        {
            return CachePixels[row - cacheTopRow, col];
        }

        /// <summary>
        /// Загружает верхнюю часть изображения в кэш
        /// </summary>
        private void CreateCache()
        {
            // Создаём новое изображение
            CachePixels = new ushort[cacheRowsCount, Width];
            ReadPixelsInformation(CachePixels, 0, cacheRowsCount);
        }

        /// <summary>
        /// Сохранены ли запрашиваемые строки в кэше
        /// </summary>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количество строк</param>
        private bool InCache(ushort topRow, ushort rowsCount)
        {
            return cacheTopRow <= topRow 
                && cacheTopRow + cacheRowsCount >= topRow + rowsCount;
        }

        /// <summary>
        /// Считает Y-координату строки, 
        /// с которой нужно сохранить часть изображения в кэш
        /// </summary>
        /// <param name="centralRow"> Центральная строка изображения</param>
        /// <returns>Y-координата строки, 
        /// с которой нужно сохранить часть изображения в кэш</returns>
        private ushort CalcTopRow(ushort centralRow)
        {
            // Определение, с какой строки изображения сохранить кэш
            ushort topRow;
            ushort delta = (ushort)(cacheRowsCount / 2);
            if(centralRow - delta < 0)
                topRow = 0;
            else if(centralRow + delta > Height)
                topRow = (ushort)(Height - cacheRowsCount);
            else
                topRow = (ushort)(centralRow - delta);
            return topRow;
        }

        /// <summary>
        /// Конвертирует ushort в byte с указанным сдвигом
        /// </summary>
        /// <param name="bitShift">Битовый сдвиг</param>
        /// <returns>Матрица яркости пикселей в формате byte</returns>
        private byte[,] ConvertPictureToByte(ushort topRow, ushort rowsCount, byte bitShift) {
            // Создаём матрицу
            byte[,] pixels = new byte[rowsCount, Width];

            int delta = topRow - cacheTopRow;
            // Заполняем
            for (int row = delta; row < delta + rowsCount; row++)
                for (int column = 0; column < Width; column++)
                    pixels[row - delta, column] = (byte)(CachePixels[row, column] >> bitShift);
            return pixels;
        }

        /// <summary>
        /// Строит новую матрицу изображения, по возможности копируя часть старого
        /// </summary>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количество строк</param>
        /// <returns>Матрица изображения в формате ushort</returns>
        private ushort[,] TryCopyAndRead(ushort topRow, ushort rowsCount) {
            // Создаём новую матрицу
            ushort[,] newCachePixels = new ushort[rowsCount, Width];
            // Если верхняя строка нового изображения не выше верхней строки нынешнего
            // и часть нового изображения захватывает старое
            if (topRow >= cacheTopRow && rowsCount - (topRow - cacheTopRow) > 0) {
                // Определяем, сколько строк можно скопировать
                ushort rowsCountToCopy = rowsCount > CachePixels.GetLength(0) ? (ushort)CachePixels.GetLength(0) : rowsCount;
                // Копируем
                for (int row = topRow - cacheTopRow; row < rowsCountToCopy; row++)
                    for (int column = 0; column < Width; column++)
                        newCachePixels[row - (topRow - cacheTopRow), column] = CachePixels[row, column];
                // Определяем строку, с которой нужно дозаполнить матрицу
                int lastIndex = rowsCountToCopy - (topRow - cacheTopRow) - 1;
                // Дозаполняем матрицу
                ReadPixelsInformation(newCachePixels, topRow + lastIndex, rowsCount - lastIndex, lastIndex);
            }
            // Если верхняя строка нового изображения выше верхней строки нынешнего
            // и часть нового изображения захватывает старое
            else if (topRow < cacheTopRow && rowsCount - (cacheTopRow - topRow) > 0) {
                // Копируем
                for (int row = cacheTopRow - topRow; row < rowsCount; row++)
                    for (int column = 0; column < Width; column++)
                        newCachePixels[row, column] = CachePixels[row - (cacheTopRow - topRow), column];
                // Дозаполняем матрицу
                ReadPixelsInformation(newCachePixels, topRow, cacheTopRow - topRow);
            }
            // Если новая матрица не пересекается со старой
            else {
                // Считываем всю матрицу из файла
                ReadPixelsInformation(newCachePixels, topRow, rowsCount);
            }
            return newCachePixels;
        }

        /// <summary>
        /// Считывает информацию из файла и заносит в матрицу
        /// </summary>
        /// <param name="newCachePixels">Матрица, в которую нужно внести изменения</param>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количестро строк</param>
        /// <param name="startIndex">Строка матрицы, с которой нужно начать заполнение(standart = 0)</param>
        private void ReadPixelsInformation(ushort[,] newCachePixels, int topRow, int rowsCount, int startIndex = 0) {
            // Создаём массив для считывания из файла
            byte[] bytesCode = new byte[rowsCount * Width * 2];
            // Считываем файл
            using (fstream = File.OpenRead(Path)) {
                fstream.Position = (testVersion ? 4 : 8) + topRow * Width * 2;
                fstream.Read(bytesCode, 0, rowsCount * Width * 2);
            }
            // Преобразуем полученные данные в ushort и заносим в матрицу
            for (int row = 0; row < rowsCount; row++) {
                for (int col = 0; col < Width; col++) {
                    newCachePixels[startIndex + row, col] = BitConverter.ToUInt16(bytesCode, (row * Width + col) * 2);
                }
            }
        }

        /// <summary>
        /// Считывает из файла размеры изображения
        /// </summary>
        private void ReadInformation() {
            byte[] bytesOfNumber = new byte[4];
            using (fstream = File.OpenRead(Path)) {
                if (testVersion)
                {
                    fstream.Read(bytesOfNumber, 0, 2);
                    Width = BitConverter.ToUInt16(bytesOfNumber, 0);
                    fstream.Read(bytesOfNumber, 0, 2);
                    Height = BitConverter.ToUInt16(bytesOfNumber, 0);
                }
                else
                {
                    fstream.Read(bytesOfNumber, 0, 4);
                    Width = BitConverter.ToInt32(bytesOfNumber, 0);
                    fstream.Read(bytesOfNumber, 0, 4);
                    Height = BitConverter.ToInt32(bytesOfNumber, 0);
                }
            }
        }
    }
}
