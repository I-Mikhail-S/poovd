using System.Text.RegularExpressions;

namespace Laba_1 {
    public partial class Form1 : Form {
        // ������ ��� ���������� �����������
        Bitmap bitmap;
        // ������� ���������� �� ����� ��������� ������ Enter
        delegate void EnterHendler();
        EnterHendler enterHendler;
        // ����� ��� ���������� ������� �����������
        PictureReader pictureReader;
        // Y-���������� ������� ������ ������
        ushort topRow = 0;
        // ������� �����
        byte bitShift = 0;
        // ������� �����������
        byte[,] picture;

        // D:\����\5 �����\����������� ����������� ��������� ���������� ������\���� 1\������ ������������\BVx2500.mbv

        public Form1() {
            // �������������� ���������
            InitializeComponent();
            PictureBox.BackColor = Color.White;
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            VScrollBar.LargeChange = PictureBox.Size.Height;
        }

        /// <summary>
        /// ���� ������ �����
        /// </summary>
        private void TextBox_OnlyNumbersInput(object sender, KeyPressEventArgs e) {
            char number = e.KeyChar;

            if (!Char.IsDigit(number)) {
                e.Handled = true;
            }
        }

        /// <summary>
        /// ������� ����� ���� � �����
        /// </summary>
        private void TextBox_Path_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetPath;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// ����� ��������� ���� � �����
        /// </summary>
        private void SetPath() {
            // �������� ����������
            if (Regex.IsMatch(TextBox_Path.Text, "^.*\\.mbv$") && File.Exists(TextBox_Path.Text)) {
                // ���������� �����������
                pictureReader = new(TextBox_Path.Text);
                VScrollBar.Maximum = pictureReader.Height;
                TextBox_ImageSizeHeight.Text = $"{pictureReader.Height}";
                TextBox_ImageSizeWidth.Text = $"{pictureReader.Width}";
                ReadPicture();
            }
        }

        /// <summary>
        /// ������� ����� Y-���������� ������� ������ ������
        /// </summary>
        private void TextBox_TopRow_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetTopRow;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// ����� ��������� Y-���������� ������� ������ ������
        /// </summary>
        private void SetTopRow() {
            if (ushort.TryParse(TextBox_TopRow.Text, out ushort a)) {
                // ���� ������� �� ��������, ������� ������������
                topRow = (ushort)(a > VScrollBar.Maximum - VScrollBar.LargeChange ? VScrollBar.Maximum - VScrollBar.LargeChange : a);
                VScrollBar.Value = topRow;
                TextBox_TopRow.Text = $"{topRow}";
                // ��������� �����������
                ReadPicture();
            }
        }

        /// <summary>
        /// ������� ��������� ���� ��������� �����������
        /// </summary>
        private void TextBox_ScrollStep_KeyDown(object sender, KeyEventArgs e) {
            enterHendler = SetScrollStep;
            TextBoxKeyDownReaction(sender, e);

        }

        /// <summary>
        /// ����� ��������� ���� ��������� �����������
        /// </summary>
        private void SetScrollStep() { if (ushort.TryParse(TextBox_ScrollStep.Text, out ushort a)) VScrollBar.SmallChange = a; }

        /// <summary>
        /// ����� ��������� ������� �������
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
        /// ����� �������� ������ ��� ������ backspase
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
        /// ������� ����������� ���� �� ������
        /// </summary>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (pictureReader == null) return;
            // ���������� �����, ��������� � ���������� ����
            TextBox_XCoord.Text = $"{e.X}";
            TextBox_YCoord.Text = $"{topRow + e.Y}";
            TextBox_Luminance.Text = $"{pictureReader.activePixels[e.Y, e.X]}";
        }

        /// <summary>
        /// ��������� �����������
        /// </summary>
        private void VScrollBar_Scroll(object sender, ScrollEventArgs e) {
            // ��������� Y-���������� ������� ������ ������
            topRow = (ushort)e.NewValue;
            TextBox_TopRow.Text = $"{topRow}";
            // ��������� �����������
            ReadPicture();
        }

        /// <summary>
        /// ���������� �����������
        /// </summary>
        private void ReadPicture() {
            if (pictureReader != null) {
                // ��������� ������� �����������
                picture = pictureReader.ReadPicture(topRow, (ushort)PictureBox.Height, bitShift);
                // ��������� �����������
                PaintPicture();
            }
        }

        /// <summary>
        /// ������� ������, ���������� �� ������� �����
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
        /// �������������� ����������� � ����� �������
        /// </summary>
        private void ReuseByteShift() {
            if (picture != null) {
                picture = pictureReader.ReuseBitShift(bitShift);
                PaintPicture();
            }
        }

        // ������������ ��������� �����������
        private void PaintPicture() {
            int width = picture.GetLength(1) > bitmap.Width ? bitmap.Width : picture.GetLength(1);
            // ��������� bitmap
            for (int row = 0; row < picture.GetLength(0); row++)
                for (int col = 0; col < width; col++)
                    bitmap.SetPixel(col, row, Color.FromArgb(picture[row, col], picture[row, col], picture[row, col]));
            // ������������ bitmap
            PictureBox.Image = bitmap;
        }

        /// <summary>
        ///  ������� ��������� �������� ������
        /// </summary>
        private void Form1_ResizeEnd(object sender, EventArgs e) {
            // �������� ������� bitmap
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            // �������� ������� �������� ��������� �����������
            VScrollBar.LargeChange = PictureBox.Size.Height;

            if (pictureReader == null) return;
            if (topRow + PictureBox.Height > pictureReader.Height)
                topRow = (ushort)(pictureReader.Height - PictureBox.Height);
            // ������ �����������
            ReadPicture();
        }
    }
}
