namespace Laba_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VScrollBar = new VScrollBar();
            RadioButton_Shift0 = new RadioButton();
            RadioButton_Shift1 = new RadioButton();
            groupBox1 = new GroupBox();
            RadioButton_Shift2 = new RadioButton();
            groupBox2 = new GroupBox();
            TextBox_TopRow = new TextBox();
            groupBox4 = new GroupBox();
            TextBox_ScrollStep = new TextBox();
            PictureBox = new PictureBox();
            TextBox_XCoord = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TextBox_YCoord = new TextBox();
            label3 = new Label();
            TextBox_Luminance = new TextBox();
            TextBox_Path = new TextBox();
            groupBox3 = new GroupBox();
            TextBox_ImageSizeHeight = new TextBox();
            groupBox_imageSize = new GroupBox();
            label_imageSizeWidth = new Label();
            label_ImageSizeHeigth = new Label();
            TextBox_ImageSizeWidth = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            groupBox3.SuspendLayout();
            groupBox_imageSize.SuspendLayout();
            SuspendLayout();
            // 
            // VScrollBar
            // 
            VScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            VScrollBar.Location = new Point(724, 56);
            VScrollBar.Maximum = 5000;
            VScrollBar.Name = "VScrollBar";
            VScrollBar.Size = new Size(31, 348);
            VScrollBar.TabIndex = 1;
            VScrollBar.Scroll += VScrollBar_Scroll;
            // 
            // RadioButton_Shift0
            // 
            RadioButton_Shift0.AutoSize = true;
            RadioButton_Shift0.Location = new Point(14, 20);
            RadioButton_Shift0.Margin = new Padding(3, 2, 3, 2);
            RadioButton_Shift0.Name = "RadioButton_Shift0";
            RadioButton_Shift0.Size = new Size(31, 19);
            RadioButton_Shift0.TabIndex = 2;
            RadioButton_Shift0.TabStop = true;
            RadioButton_Shift0.Text = "0";
            RadioButton_Shift0.UseVisualStyleBackColor = true;
            RadioButton_Shift0.CheckedChanged += RadioButton_Shift0_CheckedChanged;
            // 
            // RadioButton_Shift1
            // 
            RadioButton_Shift1.AutoSize = true;
            RadioButton_Shift1.Location = new Point(52, 20);
            RadioButton_Shift1.Margin = new Padding(3, 2, 3, 2);
            RadioButton_Shift1.Name = "RadioButton_Shift1";
            RadioButton_Shift1.Size = new Size(31, 19);
            RadioButton_Shift1.TabIndex = 3;
            RadioButton_Shift1.TabStop = true;
            RadioButton_Shift1.Text = "1";
            RadioButton_Shift1.UseVisualStyleBackColor = true;
            RadioButton_Shift1.CheckedChanged += RadioButton_Shift1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RadioButton_Shift2);
            groupBox1.Controls.Add(RadioButton_Shift1);
            groupBox1.Controls.Add(RadioButton_Shift0);
            groupBox1.Location = new Point(289, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(135, 45);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сдвигать коды на:";
            // 
            // RadioButton_Shift2
            // 
            RadioButton_Shift2.AutoSize = true;
            RadioButton_Shift2.Location = new Point(91, 20);
            RadioButton_Shift2.Margin = new Padding(3, 2, 3, 2);
            RadioButton_Shift2.Name = "RadioButton_Shift2";
            RadioButton_Shift2.Size = new Size(31, 19);
            RadioButton_Shift2.TabIndex = 4;
            RadioButton_Shift2.TabStop = true;
            RadioButton_Shift2.Text = "2";
            RadioButton_Shift2.UseVisualStyleBackColor = true;
            RadioButton_Shift2.CheckedChanged += RadioButton_Shift2_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TextBox_TopRow);
            groupBox2.Location = new Point(429, 9);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(204, 45);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Верхняя строка изображения";
            // 
            // TextBox_TopRow
            // 
            TextBox_TopRow.Location = new Point(46, 17);
            TextBox_TopRow.Margin = new Padding(3, 2, 3, 2);
            TextBox_TopRow.MaxLength = 4;
            TextBox_TopRow.Name = "TextBox_TopRow";
            TextBox_TopRow.Size = new Size(100, 23);
            TextBox_TopRow.TabIndex = 0;
            TextBox_TopRow.Text = "0";
            TextBox_TopRow.KeyDown += TextBox_TopRow_KeyDown;
            TextBox_TopRow.KeyPress += TextBox_OnlyNumbersInput;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(TextBox_ScrollStep);
            groupBox4.Location = new Point(639, 9);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(113, 45);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Шаг прокрутки";
            // 
            // TextBox_ScrollStep
            // 
            TextBox_ScrollStep.Location = new Point(26, 17);
            TextBox_ScrollStep.Margin = new Padding(3, 2, 3, 2);
            TextBox_ScrollStep.Name = "TextBox_ScrollStep";
            TextBox_ScrollStep.Size = new Size(69, 23);
            TextBox_ScrollStep.TabIndex = 0;
            TextBox_ScrollStep.Text = "1";
            TextBox_ScrollStep.KeyDown += TextBox_ScrollStep_KeyDown;
            TextBox_ScrollStep.KeyPress += TextBox_OnlyNumbersInput;
            // 
            // PictureBox
            // 
            PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PictureBox.Location = new Point(10, 56);
            PictureBox.Margin = new Padding(3, 2, 3, 2);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(474, 348);
            PictureBox.TabIndex = 7;
            PictureBox.TabStop = false;
            PictureBox.MouseMove += PictureBox_MouseMove;
            // 
            // TextBox_XCoord
            // 
            TextBox_XCoord.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_XCoord.Location = new Point(68, 410);
            TextBox_XCoord.Margin = new Padding(3, 2, 3, 2);
            TextBox_XCoord.Name = "TextBox_XCoord";
            TextBox_XCoord.ReadOnly = true;
            TextBox_XCoord.Size = new Size(64, 23);
            TextBox_XCoord.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(35, 412);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 9;
            label1.Text = "X =";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(156, 412);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 11;
            label2.Text = "Y =";
            // 
            // TextBox_YCoord
            // 
            TextBox_YCoord.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_YCoord.Location = new Point(189, 410);
            TextBox_YCoord.Margin = new Padding(3, 2, 3, 2);
            TextBox_YCoord.Name = "TextBox_YCoord";
            TextBox_YCoord.ReadOnly = true;
            TextBox_YCoord.Size = new Size(64, 23);
            TextBox_YCoord.TabIndex = 10;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(262, 412);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 13;
            label3.Text = "Яркость:";
            // 
            // TextBox_Luminance
            // 
            TextBox_Luminance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_Luminance.Location = new Point(326, 410);
            TextBox_Luminance.Margin = new Padding(3, 2, 3, 2);
            TextBox_Luminance.Name = "TextBox_Luminance";
            TextBox_Luminance.ReadOnly = true;
            TextBox_Luminance.Size = new Size(64, 23);
            TextBox_Luminance.TabIndex = 12;
            // 
            // TextBox_Path
            // 
            TextBox_Path.Location = new Point(5, 17);
            TextBox_Path.Margin = new Padding(3, 2, 3, 2);
            TextBox_Path.Name = "TextBox_Path";
            TextBox_Path.Size = new Size(263, 23);
            TextBox_Path.TabIndex = 14;
            TextBox_Path.KeyDown += TextBox_Path_KeyDown;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TextBox_Path);
            groupBox3.Location = new Point(10, 9);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(273, 45);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Загрузка mbv файла:";
            // 
            // TextBox_ImageSizeHeight
            // 
            TextBox_ImageSizeHeight.Location = new Point(101, 22);
            TextBox_ImageSizeHeight.Name = "TextBox_ImageSizeHeight";
            TextBox_ImageSizeHeight.ReadOnly = true;
            TextBox_ImageSizeHeight.Size = new Size(85, 23);
            TextBox_ImageSizeHeight.TabIndex = 14;
            // 
            // groupBox_imageSize
            // 
            groupBox_imageSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox_imageSize.Controls.Add(label_imageSizeWidth);
            groupBox_imageSize.Controls.Add(label_ImageSizeHeigth);
            groupBox_imageSize.Controls.Add(TextBox_ImageSizeWidth);
            groupBox_imageSize.Controls.Add(TextBox_ImageSizeHeight);
            groupBox_imageSize.Location = new Point(522, 331);
            groupBox_imageSize.Name = "groupBox_imageSize";
            groupBox_imageSize.Size = new Size(199, 102);
            groupBox_imageSize.TabIndex = 15;
            groupBox_imageSize.TabStop = false;
            groupBox_imageSize.Text = "Размеры изображения";
            // 
            // label_imageSizeWidth
            // 
            label_imageSizeWidth.AutoSize = true;
            label_imageSizeWidth.Location = new Point(22, 66);
            label_imageSizeWidth.Name = "label_imageSizeWidth";
            label_imageSizeWidth.Size = new Size(52, 15);
            label_imageSizeWidth.TabIndex = 17;
            label_imageSizeWidth.Text = "Ширина";
            // 
            // label_ImageSizeHeigth
            // 
            label_ImageSizeHeigth.AutoSize = true;
            label_ImageSizeHeigth.Location = new Point(22, 30);
            label_ImageSizeHeigth.Name = "label_ImageSizeHeigth";
            label_ImageSizeHeigth.Size = new Size(47, 15);
            label_ImageSizeHeigth.TabIndex = 16;
            label_ImageSizeHeigth.Text = "Высота";
            // 
            // TextBox_ImageSizeWidth
            // 
            TextBox_ImageSizeWidth.Location = new Point(101, 66);
            TextBox_ImageSizeWidth.Name = "TextBox_ImageSizeWidth";
            TextBox_ImageSizeWidth.ReadOnly = true;
            TextBox_ImageSizeWidth.Size = new Size(85, 23);
            TextBox_ImageSizeWidth.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 439);
            Controls.Add(groupBox_imageSize);
            Controls.Add(groupBox3);
            Controls.Add(label3);
            Controls.Add(TextBox_Luminance);
            Controls.Add(label2);
            Controls.Add(TextBox_YCoord);
            Controls.Add(label1);
            Controls.Add(TextBox_XCoord);
            Controls.Add(PictureBox);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(VScrollBar);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(776, 385);
            Name = "Form1";
            Text = "Визуализация изображений высокого разрешения";
            ResizeEnd += Form1_ResizeEnd;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox_imageSize.ResumeLayout(false);
            groupBox_imageSize.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VScrollBar VScrollBar;
        private RadioButton RadioButton_Shift0;
        private RadioButton RadioButton_Shift1;
        private GroupBox groupBox1;
        private RadioButton RadioButton_Shift2;
        private GroupBox groupBox2;
        private TextBox TextBox_TopRow;
        private GroupBox groupBox4;
        private TextBox TextBox_ScrollStep;
        private PictureBox PictureBox;
        private TextBox TextBox_XCoord;
        private Label label1;
        private Label label2;
        private TextBox TextBox_YCoord;
        private Label label3;
        private TextBox TextBox_Luminance;
        private TextBox TextBox_Path;
        private GroupBox groupBox3;
        private TextBox TextBox_ImageSizeHeight;
        private GroupBox groupBox_imageSize;
        private Label label_imageSizeWidth;
        private Label label_ImageSizeHeigth;
        private TextBox TextBox_ImageSizeWidth;
    }
}
