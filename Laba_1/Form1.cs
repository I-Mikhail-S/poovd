using System.Text.RegularExpressions;

namespace Laba_1 {
    public partial class Form1 : Form
    {
        // Объект для построения изображения
        Bitmap bitmap;
        // Делигат отвечающий за метод обработки кнопки Enter
        delegate void EnterHendler();
        EnterHendler enterHendler;
        // Класс для построения матрицы изображения
        PictureReader pictureReader;
        // Y-координата верхней строки экрана
        ushort topRow = 0;
        // Битовый сдвиг
        byte bitShift = 0;
        // Матрица изображения
        byte[,] picture;


        public Form1()
        {
            // Первоначальная настройка
            InitializeComponent();
            PictureBox_Main.BackColor = Color.White;
            bitmap = new Bitmap(PictureBox_Main.Width, PictureBox_Main.Height);
            VScrollBar_Main.LargeChange = PictureBox_Main.Height;
            HScrollBar_Main.LargeChange = PictureBox_Main.Width;
            UpdateCacheRowsCount();
        }

        /// <summary>
        /// Ввод только чисел
        /// </summary>
        private void TextBox_OnlyNumbersInput(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if(!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Событие кнопки указания пути к файлу
        /// </summary>
        private void Button_SetPath_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new())
            {
                // Расширения файла, который нам нужен
                openFileDialog.Filter = "(*.mbv)|*.mbv";
                // Если не открыли файл, выходим
                if(openFileDialog.ShowDialog() != DialogResult.OK) return;

                // Создаём объект PictureReader 
                pictureReader = new(openFileDialog.FileName,
                    ushort.Parse(TextBox_CacheRowsCount.Text), CheckBox_TestVersion.Checked);
                // Уставанливаем макс значения скролбаров
                VScrollBar_Main.Maximum = pictureReader.Height - 1;
                HScrollBar_Main.Maximum = pictureReader.Width - 1;
                // Выводим название файла
                Label_FileName.Text = openFileDialog.
                    FileName[(openFileDialog.FileName.LastIndexOf('\\') + 1)..];
                // Выводим инфу о изображении
                TextBox_ImageSize.Text = $"{pictureReader.Width}х{pictureReader.Height}";
                // Выводим изображение на экран
                ReadPicture();
            }
        }

        /// <summary>
        /// Событие ввода Y-координаты верхней строки экрана
        /// </summary>
        private void TextBox_TopRow_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = SetTopRow;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// Метод обработки Y-координаты верхней строки экрана
        /// </summary>
        private void SetTopRow()
        {
            if(!ushort.TryParse(TextBox_TopRow.Text, out ushort newTopRow)) return;
            // Если выходит за диапазон, сделать максимальным
            topRow = (ushort)(newTopRow > VScrollBar_Main.Maximum - VScrollBar_Main.LargeChange ?
                VScrollBar_Main.Maximum - VScrollBar_Main.LargeChange : newTopRow);
            VScrollBar_Main.Value = topRow;
            TextBox_TopRow.Text = $"{topRow}";
            // Построить изображение
            ReadPicture();
        }

        /// <summary>
        /// Событие установки кол-ва строк сохраняемых в кэше
        /// </summary>
        private void TextBox_CacheRowsCount_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = UpdateCacheRowsCount;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// Метод обработки кол-ва строк сохраняемых в кэше
        /// </summary>
        private void UpdateCacheRowsCount()
        {
            ushort newCount;
            // Если пустая строка, то считаем нулём
            if(TextBox_CacheRowsCount.Text == "")
                newCount = 0;
            // Проверяем валидность данных
            else if(!ushort.TryParse(TextBox_CacheRowsCount.Text, out newCount)) return;
            // Если меньше экрана, ставимпоразмерам экрана
            if(newCount < PictureBox_Main.Height)
                newCount = (ushort)PictureBox_Main.Height;
            // Если больше размеров тестовой картинки, то ставим 3000
            if(newCount > 3000) newCount = 3000;
            // Обновляем значение в интерфейсе
            TextBox_CacheRowsCount.Text = $"{newCount}";
            // Если загружено изображение, то и его кэш обновляем
            pictureReader?.UpdateCacheRowsCount(newCount);
        }

        /// <summary>
        /// Событие установки шага прокрутки изображения
        /// </summary>
        private void TextBox_ScrollStep_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = SetScrollStep;
            TextBoxKeyDownReaction(sender, e);

        }

        /// <summary>
        /// Метод обработки шага прокрутки изображения
        /// </summary>
        private void SetScrollStep()
        {
            if(!ushort.TryParse(TextBox_ScrollStep.Text, out ushort step)) return;
            HScrollBar_Main.SmallChange = step;
            VScrollBar_Main.SmallChange = step;
        }

        /// <summary>
        /// Метод обработки нажатой клавиши
        /// </summary>
        private void TextBoxKeyDownReaction(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    {
                        enterHendler();
                        ActiveControl = null;
                        break;
                    }
                case Keys.Back:
                    {
                        BackspaseHandler(sender as TextBox);
                        break;
                    }
            }
        }

        /// <summary>
        /// Метод стерания текста при помощи backspase
        /// </summary>
        private void BackspaseHandler(TextBox textBox)
        {
            var selectionStart = textBox.SelectionStart;
            if(textBox.SelectionLength > 0)
            {
                textBox.Text = textBox.Text.Substring(0, selectionStart) + textBox.Text.Substring(selectionStart + textBox.SelectionLength);
                textBox.SelectionStart = selectionStart;
            }
            else if(selectionStart > 0)
            {
                textBox.Text = textBox.Text.Substring(0, selectionStart - 1) + textBox.Text.Substring(selectionStart);
                textBox.SelectionStart = selectionStart - 1;
            }
        }

        /// <summary>
        /// Событие перемещения мыши по экрану
        /// </summary>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureReader == null) return;
            // Заполнение полей, связанных с положением мыши
            TextBox_XCoord.Text = $"{e.X}";
            TextBox_YCoord.Text = $"{topRow + e.Y}";
            if(e.X < pictureReader.Width)
                TextBox_Luminance.Text = $"{pictureReader.PixelLuminance(e.Y + topRow, e.X)}";
            else
                TextBox_Luminance.Text = "0";
        }

        /// <summary>
        /// Вертикальная прокрутка изображения
        /// </summary>
        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            // Изменение Y-координаты верхней строки экрана
            topRow = (ushort)e.NewValue;
            TextBox_TopRow.Text = $"{topRow}";
            // Отрисовка изображения
            ReadPicture();
        }

        /// <summary>
        /// Горизонтальная прокрутка изображения
        /// </summary>
        private void HScrollBar_Main_Scroll(object sender, ScrollEventArgs e)
        {
            // Отрисовка изображения
            ReadPicture();
        }

        /// <summary>
        /// Построение изображения
        /// </summary>
        private void ReadPicture()
        {
            if(pictureReader != null)
            {
                // Получение матрицы изображения
                picture = pictureReader.GetPicture(topRow, (ushort)PictureBox_Main.Height,
                    (ushort)HScrollBar_Main.Value, (ushort)PictureBox_Main.Width, bitShift);
                // Отрисовка изображения
                PaintPicture();
            }
        }

        /// <summary>
        /// События кнопок, отвечающих за битовый сдвиг
        /// </summary>
        private void RadioButton_Shift0_CheckedChanged(object sender, EventArgs e)
        {
            bitShift = 0;
            ReadPicture();
        }

        private void RadioButton_Shift1_CheckedChanged(object sender, EventArgs e)
        {
            bitShift = 1;
            ReadPicture();
        }

        private void RadioButton_Shift2_CheckedChanged(object sender, EventArgs e)
        {
            bitShift = 2;
            ReadPicture();
        }

        // Попиксельная отрисовка изображения
        private void PaintPicture()
        {
            int width = picture.GetLength(1) > bitmap.Width ? bitmap.Width : picture.GetLength(1);
            // Заполняем bitmap
            for(int row = 0; row < picture.GetLength(0); row++)
                for(int col = 0; col < width; col++)
                    bitmap.SetPixel(col, row, Color.FromArgb(picture[row, col], picture[row, col], picture[row, col]));
            // Устанавлваем bitmap
            PictureBox_Main.Image = bitmap;
        }

        /// <summary>
        ///  Событие изменения размеров экрана
        /// </summary>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            // Изменяем размеры bitmap
            bitmap = new Bitmap(PictureBox_Main.Width, PictureBox_Main.Height);
            // Изменяем размеры ползунка прокрутки изображения
            VScrollBar_Main.LargeChange = PictureBox_Main.Height;
            HScrollBar_Main.LargeChange = PictureBox_Main.Width;
            // Проверяем актуальность, не стало ли строк кэша меньше, чем строк изображения
            UpdateCacheRowsCount();

            if(pictureReader == null) return;
            if(topRow + PictureBox_Main.Height > pictureReader.Height)
                topRow = (ushort)(pictureReader.Height - PictureBox_Main.Height);
            // Строим изображение
            ReadPicture();
        }

        /// <summary>
        /// Смешной кастыль, но я хз...
        /// Просто,ну, нету события фуллскрина....
        /// Дебилизм....
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                Form1_ResizeEnd(sender, e);
        }
    }
}
