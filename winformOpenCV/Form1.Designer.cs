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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectSerial = new System.Windows.Forms.Button();
            this.loggingTargetDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.REC = new System.Windows.Forms.Button();
            this.serialBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(370, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 514);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(722, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CaptureDeviceConnectButton_Click);
            // 
            // cameraList
            // 
            this.cameraList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cameraList.FormattingEnabled = true;
            this.cameraList.Location = new System.Drawing.Point(370, 76);
            this.cameraList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraList.Name = "cameraList";
            this.cameraList.Size = new System.Drawing.Size(345, 23);
            this.cameraList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(366, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Live Camera";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 79);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(210, 23);
            this.comboBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Printer List";
            // 
            // connectSerial
            // 
            this.connectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.connectSerial.Location = new System.Drawing.Point(227, 76);
            this.connectSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectSerial.Name = "connectSerial";
            this.connectSerial.Size = new System.Drawing.Size(133, 29);
            this.connectSerial.TabIndex = 8;
            this.connectSerial.Text = "Connect";
            this.connectSerial.UseVisualStyleBackColor = true;
            // 
            // REC
            // 
            this.REC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.REC.Location = new System.Drawing.Point(862, 76);
            this.REC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.REC.Name = "REC";
            this.REC.Size = new System.Drawing.Size(133, 26);
            this.REC.TabIndex = 2;
            this.REC.Text = "REC start";
            this.REC.UseVisualStyleBackColor = true;
            this.REC.Click += new System.EventHandler(this.RECstart_Click);
            // 
            // serialBox
            // 
            this.serialBox.Location = new System.Drawing.Point(10, 116);
            this.serialBox.Multiline = true;
            this.serialBox.Name = "serialBox";
            this.serialBox.Size = new System.Drawing.Size(350, 513);
            this.serialBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 641);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.connectSerial);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cameraList);
            this.Controls.Add(this.REC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectSerial;
        private System.Windows.Forms.FolderBrowserDialog loggingTargetDirectory;
        private System.Windows.Forms.Button REC;
        private System.Windows.Forms.TextBox serialBox;
    }
}

