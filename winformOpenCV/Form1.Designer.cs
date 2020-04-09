namespace winformOpenCV
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cameraList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recordTargetDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.serialDeviceList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectSerial = new System.Windows.Forms.Button();
            this.loggingTargetDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.REC = new System.Windows.Forms.Button();
            this.serialBox = new System.Windows.Forms.TextBox();
            this.stopPrinterButton = new System.Windows.Forms.Button();
            this.folderSelectorButton = new System.Windows.Forms.Button();
            this.selectedFolderText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(324, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(546, 412);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(632, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CaptureDeviceConnectButton_Click);
            // 
            // cameraList
            // 
            this.cameraList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cameraList.FormattingEnabled = true;
            this.cameraList.Location = new System.Drawing.Point(324, 61);
            this.cameraList.Name = "cameraList";
            this.cameraList.Size = new System.Drawing.Size(302, 23);
            this.cameraList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(320, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Live Camera";
            // 
            // serialDeviceList
            // 
            this.serialDeviceList.FormattingEnabled = true;
            this.serialDeviceList.Location = new System.Drawing.Point(9, 63);
            this.serialDeviceList.Name = "serialDeviceList";
            this.serialDeviceList.Size = new System.Drawing.Size(184, 20);
            this.serialDeviceList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Printer List";
            // 
            // connectSerial
            // 
            this.connectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.connectSerial.Location = new System.Drawing.Point(199, 61);
            this.connectSerial.Name = "connectSerial";
            this.connectSerial.Size = new System.Drawing.Size(116, 23);
            this.connectSerial.TabIndex = 8;
            this.connectSerial.Text = "Connect";
            this.connectSerial.UseVisualStyleBackColor = true;
            this.connectSerial.Click += new System.EventHandler(this.connectSerial_Click);
            // 
            // REC
            // 
            this.REC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.REC.Location = new System.Drawing.Point(754, 61);
            this.REC.Name = "REC";
            this.REC.Size = new System.Drawing.Size(116, 21);
            this.REC.TabIndex = 2;
            this.REC.Text = "REC start";
            this.REC.UseVisualStyleBackColor = true;
            this.REC.Click += new System.EventHandler(this.RECstart_Click);
            // 
            // serialBox
            // 
            this.serialBox.Location = new System.Drawing.Point(9, 93);
            this.serialBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serialBox.Multiline = true;
            this.serialBox.Name = "serialBox";
            this.serialBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serialBox.Size = new System.Drawing.Size(307, 411);
            this.serialBox.TabIndex = 9;
            // 
            // stopPrinterButton
            // 
            this.stopPrinterButton.Location = new System.Drawing.Point(756, 512);
            this.stopPrinterButton.Name = "stopPrinterButton";
            this.stopPrinterButton.Size = new System.Drawing.Size(114, 23);
            this.stopPrinterButton.TabIndex = 10;
            this.stopPrinterButton.Text = "Stop Printer";
            this.stopPrinterButton.UseVisualStyleBackColor = true;
            this.stopPrinterButton.Click += new System.EventHandler(this.stopPrinterButton_Click);
            // 
            // folderSelectorButton
            // 
            this.folderSelectorButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.folderSelectorButton.AllowDrop = true;
            this.folderSelectorButton.Location = new System.Drawing.Point(636, 512);
            this.folderSelectorButton.Name = "folderSelectorButton";
            this.folderSelectorButton.Size = new System.Drawing.Size(114, 23);
            this.folderSelectorButton.TabIndex = 11;
            this.folderSelectorButton.Text = "Select";
            this.folderSelectorButton.UseVisualStyleBackColor = true;
            this.folderSelectorButton.Click += new System.EventHandler(this.folderSelectorButton_Click);
            // 
            // selectedFolderText
            // 
            this.selectedFolderText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectedFolderText.Location = new System.Drawing.Point(9, 512);
            this.selectedFolderText.Name = "selectedFolderText";
            this.selectedFolderText.ReadOnly = true;
            this.selectedFolderText.Size = new System.Drawing.Size(621, 21);
            this.selectedFolderText.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(877, 61);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 443);
            this.textBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(877, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Comment";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 543);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.selectedFolderText);
            this.Controls.Add(this.folderSelectorButton);
            this.Controls.Add(this.stopPrinterButton);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.connectSerial);
            this.Controls.Add(this.serialDeviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cameraList);
            this.Controls.Add(this.REC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "3D Printer Remote Management Program v0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cameraList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog recordTargetDirectory;
        private System.Windows.Forms.ComboBox serialDeviceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectSerial;
        private System.Windows.Forms.FolderBrowserDialog loggingTargetDirectory;
        private System.Windows.Forms.Button REC;
        private System.Windows.Forms.TextBox serialBox;
        private System.Windows.Forms.Button stopPrinterButton;
        private System.Windows.Forms.Button folderSelectorButton;
        private System.Windows.Forms.TextBox selectedFolderText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

