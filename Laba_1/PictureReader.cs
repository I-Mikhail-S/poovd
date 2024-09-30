namespace Laba_1 {
    public class PictureReader {
        // Путь до файла
        public string Path { get; private set; }
        // Штрина изображения
        public ushort Width { get; private set; }
        // Длинна изображения
        public ushort Height { get; private set; }
        // Пиксели экрана в 2-байтовом виде (изображение)
        public ushort[,] activePixels { get; private set; }
        // Y-координата верхней строки экрана при последней отрисовке
        private ushort lastTopRow;
        // Поток файла
        private FileStream fstream;

        /// <summary>
        /// Сразу считывает информацию о изображении
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public PictureReader(string path) {
            Path = path;
            ReadInformation();
        }

        /// <summary>
        /// Считывает изображение с файла, по возможности часть копирует с прошлой изображения
        /// </summary>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количество строк</param>
        /// <param name="bitShift">Битовый сдвиг</param>
        /// <returns>Матрица яркости пикселей</returns>
        public byte[,] ReadPicture(ushort topRow, ushort rowsCount, byte bitShift) {
            //Проверяем наличие старого изображения
            if (activePixels != null) {
                //Пытаемся скопировать часть старого изображения и докачать остаток
                activePixels = TryCopyAndRead(topRow, rowsCount);
            }
            else {
                // Создаём новое изображение
                activePixels = new ushort[rowsCount, Width];
                ReadPixelsInformation(activePixels, topRow, rowsCount);
            }
            // Сохраняем Y-координату верхней строки экрана
            lastTopRow = topRow;
            // Возврщаем конвертированное в byte со сдвигом изображение
            return ConvertPictureToByte(bitShift);
        }

        /// <summary>
        /// Возвращает изображение на экране с другим битовым сдвигом
        /// </summary>
        /// <param name="bitShift">Битовый сдвиг</param>
        /// <returns>Матрица яркости пикселей в формате byte</returns>
        public byte[,] ReuseBitShift(byte bitShift) {
            return ConvertPictureToByte(bitShift);
        }

        /// <summary>
        /// Конвертирует ushort в byte с указанным сдвигом
        /// </summary>
        /// <param name="bitShift">Битовый сдвиг</param>
        /// <returns>Матрица яркости пикселей в формате byte</returns>
        private byte[,] ConvertPictureToByte(byte bitShift) {
            // Создаём матрицу
            byte[,] pixels = new byte[activePixels.GetLength(0), Width];
            // Заполняем
            for (int row = 0; row < pixels.GetLength(0); row++)
                for (int column = 0; column < Width; column++)
                    pixels[row, column] = (byte)(activePixels[row, column] >> bitShift);
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
            ushort[,] newActivePixels = new ushort[rowsCount, Width];
            // Если верхняя строка нового изображения не выше верхней строки нынешнего
            // и часть нового изображения захватывает старое
            if (topRow >= lastTopRow && rowsCount - (topRow - lastTopRow) > 0) {
                // Определяем, сколько строк можно скопировать
                ushort rowsCountToCopy = rowsCount > activePixels.GetLength(0) ? (ushort)activePixels.GetLength(0) : rowsCount;
                // Копируем
                for (int row = topRow - lastTopRow; row < rowsCountToCopy; row++)
                    for (int column = 0; column < Width; column++)
                        newActivePixels[row - (topRow - lastTopRow), column] = activePixels[row, column];
                // Определяем строку, с которой нужно дозаполнить матрицу
                int lastIndex = rowsCountToCopy - (topRow - lastTopRow) - 1;
                // Дозаполняем матрицу
                ReadPixelsInformation(newActivePixels, topRow + lastIndex, rowsCount - lastIndex, lastIndex);
            }
            // Если верхняя строка нового изображения выше верхней строки нынешнего
            // и часть нового изображения захватывает старое
            else if (topRow < lastTopRow && rowsCount - (lastTopRow - topRow) > 0) {
                // Копируем
                for (int row = lastTopRow - topRow; row < rowsCount; row++)
                    for (int column = 0; column < Width; column++)
                        newActivePixels[row, column] = activePixels[row - (lastTopRow - topRow), column];
                // Дозаполняем матрицу
                ReadPixelsInformation(newActivePixels, topRow, lastTopRow - topRow);
            }
            // Если новая матрица не пересекается со старой
            else {
                // Считываем всю матрицу из файла
                ReadPixelsInformation(newActivePixels, topRow, rowsCount);
            }
            return newActivePixels;
        }

        /// <summary>
        /// Считывает информацию из файла и заносит в матрицу
        /// </summary>
        /// <param name="newActivePixels">Матрица, в которую нужно внести изменения</param>
        /// <param name="topRow">Y-координата верхней строки экрана</param>
        /// <param name="rowsCount">Количестро строк</param>
        /// <param name="startIndex">Строка матрицы, с которой нужно начать заполнение(standart = 0)</param>
        private void ReadPixelsInformation(ushort[,] newActivePixels, int topRow, int rowsCount, int startIndex = 0) {
            // Создаём массив для считывания из файла
            byte[] bytesCode = new byte[rowsCount * Width * 2];
            // Считываем файл
            using (fstream = File.OpenRead(Path)) {
                fstream.Position = 4 + topRow * Width * 2;
                fstream.Read(bytesCode, 0, rowsCount * Width * 2);
            }
            // Преобразуем полученные данные в ushort и заносим в матрицу
            for (int row = 0; row < rowsCount; row++) {
                for (int col = 0; col < Width; col++) {
                    newActivePixels[startIndex + row, col] = BitConverter.ToUInt16(bytesCode, (row * Width + col) * 2);
                }
            }
        }

        /// <summary>
        /// Считывает из файла размеры изображения
        /// </summary>
        private void ReadInformation() {
            byte[] bytesOfNumber = new byte[2];
            using (fstream = File.OpenRead(Path)) {
                fstream.Read(bytesOfNumber, 0, 2);
                Width = BitConverter.ToUInt16(bytesOfNumber, 0);
                fstream.Read(bytesOfNumber, 0, 2);
                Height = BitConverter.ToUInt16(bytesOfNumber, 0);
            }
        }
    }
}
