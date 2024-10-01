using System.Text.RegularExpressions;

namespace Laba_1 {
    public partial class Form1 : Form
    {
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


        public Form1()
        {
            // �������������� ���������
            InitializeComponent();
            PictureBox_Main.BackColor = Color.White;
            bitmap = new Bitmap(PictureBox_Main.Width, PictureBox_Main.Height);
            VScrollBar_Main.LargeChange = PictureBox_Main.Height;
            HScrollBar_Main.LargeChange = PictureBox_Main.Width;
            UpdateCacheRowsCount();
        }

        /// <summary>
        /// ���� ������ �����
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
        /// ������� ������ �������� ���� � �����
        /// </summary>
        private void Button_SetPath_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new())
            {
                // ���������� �����, ������� ��� �����
                openFileDialog.Filter = "(*.mbv)|*.mbv";
                // ���� �� ������� ����, �������
                if(openFileDialog.ShowDialog() != DialogResult.OK) return;

                // ������ ������ PictureReader 
                pictureReader = new(openFileDialog.FileName,
                    ushort.Parse(TextBox_CacheRowsCount.Text), CheckBox_TestVersion.Checked);
                // ������������� ���� �������� ����������
                VScrollBar_Main.Maximum = pictureReader.Height - 1;
                HScrollBar_Main.Maximum = pictureReader.Width - 1;
                // ������� �������� �����
                Label_FileName.Text = openFileDialog.
                    FileName[(openFileDialog.FileName.LastIndexOf('\\') + 1)..];
                // ������� ���� � �����������
                TextBox_ImageSize.Text = $"{pictureReader.Width}�{pictureReader.Height}";
                // ������� ����������� �� �����
                ReadPicture();
            }
        }

        /// <summary>
        /// ������� ����� Y-���������� ������� ������ ������
        /// </summary>
        private void TextBox_TopRow_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = SetTopRow;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// ����� ��������� Y-���������� ������� ������ ������
        /// </summary>
        private void SetTopRow()
        {
            if(!ushort.TryParse(TextBox_TopRow.Text, out ushort newTopRow)) return;
            // ���� ������� �� ��������, ������� ������������
            topRow = (ushort)(newTopRow > VScrollBar_Main.Maximum - VScrollBar_Main.LargeChange ?
                VScrollBar_Main.Maximum - VScrollBar_Main.LargeChange : newTopRow);
            VScrollBar_Main.Value = topRow;
            TextBox_TopRow.Text = $"{topRow}";
            // ��������� �����������
            ReadPicture();
        }

        /// <summary>
        /// ������� ��������� ���-�� ����� ����������� � ����
        /// </summary>
        private void TextBox_CacheRowsCount_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = UpdateCacheRowsCount;
            TextBoxKeyDownReaction(sender, e);
        }

        /// <summary>
        /// ����� ��������� ���-�� ����� ����������� � ����
        /// </summary>
        private void UpdateCacheRowsCount()
        {
            ushort newCount;
            // ���� ������ ������, �� ������� ����
            if(TextBox_CacheRowsCount.Text == "")
                newCount = 0;
            // ��������� ���������� ������
            else if(!ushort.TryParse(TextBox_CacheRowsCount.Text, out newCount)) return;
            // ���� ������ ������, ���������������� ������
            if(newCount < PictureBox_Main.Height)
                newCount = (ushort)PictureBox_Main.Height;
            // ���� ������ �������� �������� ��������, �� ������ 3000
            if(newCount > 3000) newCount = 3000;
            // ��������� �������� � ����������
            TextBox_CacheRowsCount.Text = $"{newCount}";
            // ���� ��������� �����������, �� � ��� ��� ���������
            pictureReader?.UpdateCacheRowsCount(newCount);
        }

        /// <summary>
        /// ������� ��������� ���� ��������� �����������
        /// </summary>
        private void TextBox_ScrollStep_KeyDown(object sender, KeyEventArgs e)
        {
            enterHendler = SetScrollStep;
            TextBoxKeyDownReaction(sender, e);

        }

        /// <summary>
        /// ����� ��������� ���� ��������� �����������
        /// </summary>
        private void SetScrollStep()
        {
            if(!ushort.TryParse(TextBox_ScrollStep.Text, out ushort step)) return;
            HScrollBar_Main.SmallChange = step;
            VScrollBar_Main.SmallChange = step;
        }

        /// <summary>
        /// ����� ��������� ������� �������
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
        /// ����� �������� ������ ��� ������ backspase
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
        /// ������� ����������� ���� �� ������
        /// </summary>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureReader == null) return;
            // ���������� �����, ��������� � ���������� ����
            TextBox_XCoord.Text = $"{e.X}";
            TextBox_YCoord.Text = $"{topRow + e.Y}";
            if(e.X < pictureReader.Width)
                TextBox_Luminance.Text = $"{pictureReader.PixelLuminance(e.Y + topRow, e.X)}";
            else
                TextBox_Luminance.Text = "0";
        }

        /// <summary>
        /// ������������ ��������� �����������
        /// </summary>
        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            // ��������� Y-���������� ������� ������ ������
            topRow = (ushort)e.NewValue;
            TextBox_TopRow.Text = $"{topRow}";
            // ��������� �����������
            ReadPicture();
        }

        /// <summary>
        /// �������������� ��������� �����������
        /// </summary>
        private void HScrollBar_Main_Scroll(object sender, ScrollEventArgs e)
        {
            // ��������� �����������
            ReadPicture();
        }

        /// <summary>
        /// ���������� �����������
        /// </summary>
        private void ReadPicture()
        {
            if(pictureReader != null)
            {
                // ��������� ������� �����������
                picture = pictureReader.GetPicture(topRow, (ushort)PictureBox_Main.Height,
                    (ushort)HScrollBar_Main.Value, (ushort)PictureBox_Main.Width, bitShift);
                // ��������� �����������
                PaintPicture();
            }
        }

        /// <summary>
        /// ������� ������, ���������� �� ������� �����
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

        // ������������ ��������� �����������
        private void PaintPicture()
        {
            int width = picture.GetLength(1) > bitmap.Width ? bitmap.Width : picture.GetLength(1);
            // ��������� bitmap
            for(int row = 0; row < picture.GetLength(0); row++)
                for(int col = 0; col < width; col++)
                    bitmap.SetPixel(col, row, Color.FromArgb(picture[row, col], picture[row, col], picture[row, col]));
            // ������������ bitmap
            PictureBox_Main.Image = bitmap;
        }

        /// <summary>
        ///  ������� ��������� �������� ������
        /// </summary>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            // �������� ������� bitmap
            bitmap = new Bitmap(PictureBox_Main.Width, PictureBox_Main.Height);
            // �������� ������� �������� ��������� �����������
            VScrollBar_Main.LargeChange = PictureBox_Main.Height;
            HScrollBar_Main.LargeChange = PictureBox_Main.Width;
            // ��������� ������������, �� ����� �� ����� ���� ������, ��� ����� �����������
            UpdateCacheRowsCount();

            if(pictureReader == null) return;
            if(topRow + PictureBox_Main.Height > pictureReader.Height)
                topRow = (ushort)(pictureReader.Height - PictureBox_Main.Height);
            // ������ �����������
            ReadPicture();
        }

        /// <summary>
        /// ������� �������, �� � ��...
        /// ������,��, ���� ������� ����������....
        /// ��������....
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                Form1_ResizeEnd(sender, e);
        }
    }
}
