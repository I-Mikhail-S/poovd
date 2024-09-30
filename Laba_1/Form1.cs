using System.Text.RegularExpressions;

namespace Laba_1 {
    public partial class Form1 : Form {
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

        // D:\инст\5 семак\Программное обеспечение обработки визуальных данных\лаба 1\Полосы вертикальные\BVx2500.mbv

        public Form1() {
            // Первоначальная настройка
            InitializeComponent();
            PictureBox.BackColor = Color.White;
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            VScrollBar.LargeChange = PictureBox.Size.Height;
        }

        /// <summary>
        /// Ввод только чисел
        /// </summary>
        private void TextBox_OnlyNumbersInput(object sender, KeyPressEventArgs e) {
            char number = e.KeyChar;

            if (!Char.IsDigit(number)) {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Событие ввода пути к файлу
        /// </summary>
        private void TextBox_Path_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetPath;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// Метод обработки пути к файлу
        /// </summary>
        private void SetPath() {
            // Проверка валидности
            if (Regex.IsMatch(TextBox_Path.Text, "^.*\\.mbv$") && File.Exists(TextBox_Path.Text)) {
                // построение изображения
                pictureReader = new(TextBox_Path.Text);
                VScrollBar.Maximum = pictureReader.Height;
                TextBox_ImageSizeHeight.Text = $"{pictureReader.Height}";
                TextBox_ImageSizeWidth.Text = $"{pictureReader.Width}";
                ReadPicture();
            }
        }

        /// <summary>
        /// Событие ввода Y-координаты верхней строки экрана
        /// </summary>
        private void TextBox_TopRow_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetTopRow;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// Метод обработки Y-координаты верхней строки экрана
        /// </summary>
        private void SetTopRow() {
            if (ushort.TryParse(TextBox_TopRow.Text, out ushort a)) {
                // Если выходит за диапазон, сделать максимальным
                topRow = (ushort)(a > VScrollBar.Maximum - VScrollBar.LargeChange ? VScrollBar.Maximum - VScrollBar.LargeChange : a);
                VScrollBar.Value = topRow;
                TextBox_TopRow.Text = $"{topRow}";
                // Построить изображение
                ReadPicture();
            }
        }

        /// <summary>
        /// Событие установки шага прокрутки изображения
        /// </summary>
        private void TextBox_ScrollStep_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetScrollStep;
            TextBoxKeyDownReaction(sender, e);

        }

        /// <summary>
        /// Метод обработки шага прокрутки изображения
        /// </summary>
        private void SetScrollStep() { if (ushort.TryParse(TextBox_ScrollStep.Text, out ushort a)) VScrollBar.SmallChange = a; }

        /// <summary>
        /// Метод обработки нажатой клавиши
        /// </summary>
        private void TextBoxKeyDownReaction(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter: {
                        enterHendler();
                        ActiveControl = null;
                        break;
                    }
                case Keys.Back: {
                        BackspaseHandler(sender as TextBox);
                        break;
                    }
            }
        }

        /// <summary>
        /// Метод стерания текста при помощи backspase
        /// </summary>
        private void BackspaseHandler(TextBox textBox) {
            var selectionStart = textBox.SelectionStart;
            if (textBox.SelectionLength > 0) {
                textBox.Text = textBox.Text.Substring(0, selectionStart) + textBox.Text.Substring(selectionStart + textBox.SelectionLength);
                textBox.SelectionStart = selectionStart;
            }
            else if (selectionStart > 0) {
                textBox.Text = textBox.Text.Substring(0, selectionStart - 1) + textBox.Text.Substring(selectionStart);
                textBox.SelectionStart = selectionStart - 1;
            }
        }

        /// <summary>
        /// Событие перемещения мыши по экрану
        /// </summary>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (pictureReader == null) return;
            // Заполнение полей, связанных с положением мыши
            TextBox_XCoord.Text = $"{e.X}";
            TextBox_YCoord.Text = $"{topRow + e.Y}";
            TextBox_Luminance.Text = $"{pictureReader.activePixels[e.Y, e.X]}";
        }

        /// <summary>
        /// Прокрутка изображения
        /// </summary>
        private void VScrollBar_Scroll(object sender, ScrollEventArgs e) {
            // Изменение Y-координаты верхней строки экрана
            topRow = (ushort)e.NewValue;
            TextBox_TopRow.Text = $"{topRow}";
            // Отрисовка изображения
            ReadPicture();
        }

        /// <summary>
        /// Построение изображения
        /// </summary>
        private void ReadPicture() {
            if (pictureReader != null) {
                // Получение матрицы изображения
                picture = pictureReader.ReadPicture(topRow, (ushort)PictureBox.Height, bitShift);
                // Отрисовка изображения
                PaintPicture();
            }
        }

        /// <summary>
        /// События кнопок, отвечающих за битовый сдвиг
        /// </summary>
        private void RadioButton_Shift0_CheckedChanged(object sender, EventArgs e) {
            bitShift = 0;
            ReuseByteShift();
        }

        private void RadioButton_Shift1_CheckedChanged(object sender, EventArgs e) {
            bitShift = 1;
            ReuseByteShift();
        }

        private void RadioButton_Shift2_CheckedChanged(object sender, EventArgs e) {
            bitShift = 2;
            ReuseByteShift();
        }

        /// <summary>
        /// Перерисовывает изображение с новым сдвигом
        /// </summary>
        private void ReuseByteShift() {
            if (picture != null) {
                picture = pictureReader.ReuseBitShift(bitShift);
                PaintPicture();
            }
        }

        // Попиксельная отрисовка изображения
        private void PaintPicture() {
            int width = picture.GetLength(1) > bitmap.Width ? bitmap.Width : picture.GetLength(1);
            // Заполняем bitmap
            for (int row = 0; row < picture.GetLength(0); row++)
                for (int col = 0; col < width; col++)
                    bitmap.SetPixel(col, row, Color.FromArgb(picture[row, col], picture[row, col], picture[row, col]));
            // Устанавлваем bitmap
            PictureBox.Image = bitmap;
        }

        /// <summary>
        ///  Событие изменения размеров экрана
        /// </summary>
        private void Form1_ResizeEnd(object sender, EventArgs e) {
            // Изменяем размеры bitmap
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            // Изменяем размеры ползунка прокрутки изображения
            VScrollBar.LargeChange = PictureBox.Size.Height;

            if (pictureReader == null) return;
            if (topRow + PictureBox.Height > pictureReader.Height)
                topRow = (ushort)(pictureReader.Height - PictureBox.Height);
            // Строим изображение
            ReadPicture();
        }
    }
}
