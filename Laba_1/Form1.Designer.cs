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
            VScrollBar_Main = new VScrollBar();
            RadioButton_Shift0 = new RadioButton();
            RadioButton_Shift1 = new RadioButton();
            groupBox1 = new GroupBox();
            RadioButton_Shift2 = new RadioButton();
            groupBox2 = new GroupBox();
            TextBox_TopRow = new TextBox();
            groupBox4 = new GroupBox();
            TextBox_ScrollStep = new TextBox();
            PictureBox_Main = new PictureBox();
            TextBox_XCoord = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TextBox_YCoord = new TextBox();
            label3 = new Label();
            TextBox_Luminance = new TextBox();
            groupBox3 = new GroupBox();
            CheckBox_TestVersion = new CheckBox();
            Label_FileName = new Label();
            Button_SetPath = new Button();
            TextBox_ImageSize = new TextBox();
            label4 = new Label();
            groupBox5 = new GroupBox();
            TextBox_CacheRowsCount = new TextBox();
            HScrollBar_Main = new HScrollBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox_Main).BeginInit();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // VScrollBar_Main
            // 
            VScrollBar_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            VScrollBar_Main.Location = new Point(960, 75);
            VScrollBar_Main.Maximum = 1000;
            VScrollBar_Main.Name = "VScrollBar_Main";
            VScrollBar_Main.Size = new Size(31, 464);
            VScrollBar_Main.TabIndex = 1;
            VScrollBar_Main.Scroll += VScrollBar_Scroll;
            // 
            // RadioButton_Shift0
            // 
            RadioButton_Shift0.AutoSize = true;
            RadioButton_Shift0.Location = new Point(16, 27);
            RadioButton_Shift0.Name = "RadioButton_Shift0";
            RadioButton_Shift0.Size = new Size(38, 24);
            RadioButton_Shift0.TabIndex = 2;
            RadioButton_Shift0.TabStop = true;
            RadioButton_Shift0.Text = "0";
            RadioButton_Shift0.UseVisualStyleBackColor = true;
            RadioButton_Shift0.CheckedChanged += RadioButton_Shift0_CheckedChanged;
            // 
            // RadioButton_Shift1
            // 
            RadioButton_Shift1.AutoSize = true;
            RadioButton_Shift1.Location = new Point(59, 27);
            RadioButton_Shift1.Name = "RadioButton_Shift1";
            RadioButton_Shift1.Size = new Size(38, 24);
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
            groupBox1.Location = new Point(288, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(154, 60);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сдвигать коды на:";
            // 
            // RadioButton_Shift2
            // 
            RadioButton_Shift2.AutoSize = true;
            RadioButton_Shift2.Location = new Point(104, 27);
            RadioButton_Shift2.Name = "RadioButton_Shift2";
            RadioButton_Shift2.Size = new Size(38, 24);
            RadioButton_Shift2.TabIndex = 4;
            RadioButton_Shift2.TabStop = true;
            RadioButton_Shift2.Text = "2";
            RadioButton_Shift2.UseVisualStyleBackColor = true;
            RadioButton_Shift2.CheckedChanged += RadioButton_Shift2_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TextBox_TopRow);
            groupBox2.Location = new Point(448, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(233, 60);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Верхняя строка изображения";
            // 
            // TextBox_TopRow
            // 
            TextBox_TopRow.Location = new Point(53, 23);
            TextBox_TopRow.MaxLength = 4;
            TextBox_TopRow.Name = "TextBox_TopRow";
            TextBox_TopRow.Size = new Size(114, 27);
            TextBox_TopRow.TabIndex = 0;
            TextBox_TopRow.Text = "0";
            TextBox_TopRow.KeyDown += TextBox_TopRow_KeyDown;
            TextBox_TopRow.KeyPress += TextBox_OnlyNumbersInput;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(TextBox_ScrollStep);
            groupBox4.Location = new Point(862, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(129, 60);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Шаг прокрутки";
            // 
            // TextBox_ScrollStep
            // 
            TextBox_ScrollStep.Location = new Point(30, 23);
            TextBox_ScrollStep.Name = "TextBox_ScrollStep";
            TextBox_ScrollStep.Size = new Size(78, 27);
            TextBox_ScrollStep.TabIndex = 0;
            TextBox_ScrollStep.Text = "1";
            TextBox_ScrollStep.KeyDown += TextBox_ScrollStep_KeyDown;
            TextBox_ScrollStep.KeyPress += TextBox_OnlyNumbersInput;
            // 
            // PictureBox_Main
            // 
            PictureBox_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PictureBox_Main.Location = new Point(11, 75);
            PictureBox_Main.Name = "PictureBox_Main";
            PictureBox_Main.Size = new Size(580, 440);
            PictureBox_Main.TabIndex = 7;
            PictureBox_Main.TabStop = false;
            PictureBox_Main.MouseMove += PictureBox_MouseMove;
            // 
            // TextBox_XCoord
            // 
            TextBox_XCoord.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_XCoord.Location = new Point(78, 547);
            TextBox_XCoord.Name = "TextBox_XCoord";
            TextBox_XCoord.ReadOnly = true;
            TextBox_XCoord.Size = new Size(73, 27);
            TextBox_XCoord.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(40, 549);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 9;
            label1.Text = "X =";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(178, 549);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 11;
            label2.Text = "Y =";
            // 
            // TextBox_YCoord
            // 
            TextBox_YCoord.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_YCoord.Location = new Point(216, 547);
            TextBox_YCoord.Name = "TextBox_YCoord";
            TextBox_YCoord.ReadOnly = true;
            TextBox_YCoord.Size = new Size(73, 27);
            TextBox_YCoord.TabIndex = 10;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(299, 549);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 13;
            label3.Text = "Яркость:";
            // 
            // TextBox_Luminance
            // 
            TextBox_Luminance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_Luminance.Location = new Point(373, 547);
            TextBox_Luminance.Name = "TextBox_Luminance";
            TextBox_Luminance.ReadOnly = true;
            TextBox_Luminance.Size = new Size(73, 27);
            TextBox_Luminance.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(CheckBox_TestVersion);
            groupBox3.Controls.Add(Label_FileName);
            groupBox3.Controls.Add(Button_SetPath);
            groupBox3.Location = new Point(11, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(271, 60);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Загрузка mbv файла:";
            // 
            // CheckBox_TestVersion
            // 
            CheckBox_TestVersion.AutoSize = true;
            CheckBox_TestVersion.Checked = true;
            CheckBox_TestVersion.CheckState = CheckState.Checked;
            CheckBox_TestVersion.Location = new Point(205, 0);
            CheckBox_TestVersion.Name = "CheckBox_TestVersion";
            CheckBox_TestVersion.Size = new Size(55, 24);
            CheckBox_TestVersion.TabIndex = 2;
            CheckBox_TestVersion.Text = "test";
            CheckBox_TestVersion.UseVisualStyleBackColor = true;
            // 
            // Label_FileName
            // 
            Label_FileName.AutoSize = true;
            Label_FileName.Location = new Point(125, 29);
            Label_FileName.Name = "Label_FileName";
            Label_FileName.Size = new Size(0, 20);
            Label_FileName.TabIndex = 1;
            // 
            // Button_SetPath
            // 
            Button_SetPath.Location = new Point(6, 25);
            Button_SetPath.Name = "Button_SetPath";
            Button_SetPath.Size = new Size(113, 29);
            Button_SetPath.TabIndex = 0;
            Button_SetPath.Text = "Загрузить";
            Button_SetPath.UseVisualStyleBackColor = true;
            Button_SetPath.Click += Button_SetPath_Click;
            // 
            // TextBox_ImageSize
            // 
            TextBox_ImageSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TextBox_ImageSize.Location = new Point(643, 547);
            TextBox_ImageSize.Margin = new Padding(3, 4, 3, 4);
            TextBox_ImageSize.Name = "TextBox_ImageSize";
            TextBox_ImageSize.ReadOnly = true;
            TextBox_ImageSize.Size = new Size(146, 27);
            TextBox_ImageSize.TabIndex = 14;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(463, 549);
            label4.Name = "label4";
            label4.Size = new Size(174, 20);
            label4.TabIndex = 16;
            label4.Text = "Размеры изображения:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(TextBox_CacheRowsCount);
            groupBox5.Location = new Point(687, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(169, 60);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Кол-во строк в кэше";
            // 
            // TextBox_CacheRowsCount
            // 
            TextBox_CacheRowsCount.Location = new Point(29, 23);
            TextBox_CacheRowsCount.MaxLength = 4;
            TextBox_CacheRowsCount.Name = "TextBox_CacheRowsCount";
            TextBox_CacheRowsCount.Size = new Size(114, 27);
            TextBox_CacheRowsCount.TabIndex = 0;
            TextBox_CacheRowsCount.Text = "0";
            TextBox_CacheRowsCount.KeyDown += TextBox_CacheRowsCount_KeyDown;
            TextBox_CacheRowsCount.KeyPress += TextBox_OnlyNumbersInput;
            // 
            // HScrollBar_Main
            // 
            HScrollBar_Main.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HScrollBar_Main.Location = new Point(11, 518);
            HScrollBar_Main.Maximum = 500;
            HScrollBar_Main.Name = "HScrollBar_Main";
            HScrollBar_Main.Size = new Size(580, 26);
            HScrollBar_Main.TabIndex = 17;
            HScrollBar_Main.Scroll += HScrollBar_Main_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 585);
            Controls.Add(HScrollBar_Main);
            Controls.Add(groupBox5);
            Controls.Add(label4);
            Controls.Add(groupBox3);
            Controls.Add(TextBox_ImageSize);
            Controls.Add(label3);
            Controls.Add(TextBox_Luminance);
            Controls.Add(label2);
            Controls.Add(TextBox_YCoord);
            Controls.Add(label1);
            Controls.Add(TextBox_XCoord);
            Controls.Add(PictureBox_Main);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(VScrollBar_Main);
            MinimumSize = new Size(1020, 632);
            Name = "Form1";
            Text = "Визуализация изображений высокого разрешения";
            ResizeEnd += Form1_ResizeEnd;
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox_Main).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VScrollBar VScrollBar_Main;
        private RadioButton RadioButton_Shift0;
        private RadioButton RadioButton_Shift1;
        private GroupBox groupBox1;
        private RadioButton RadioButton_Shift2;
        private GroupBox groupBox2;
        private TextBox TextBox_TopRow;
        private GroupBox groupBox4;
        private TextBox TextBox_ScrollStep;
        private PictureBox PictureBox_Main;
        private TextBox TextBox_XCoord;
        private Label label1;
        private Label label2;
        private TextBox TextBox_YCoord;
        private Label label3;
        private TextBox TextBox_Luminance;
        private GroupBox groupBox3;
        private TextBox TextBox_ImageSize;
        private Label Label_FileName;
        private Button Button_SetPath;
        private CheckBox CheckBox_TestVersion;
        private Label label4;
        private GroupBox groupBox5;
        private TextBox TextBox_CacheRowsCount;
        private HScrollBar HScrollBar_Main;
    }
}
