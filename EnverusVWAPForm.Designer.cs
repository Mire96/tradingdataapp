
namespace Enverus.VWAPService
{
    partial class EnverusVWAPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.symbolTxt = new System.Windows.Forms.TextBox();
            this.sendRequestBtn = new System.Windows.Forms.Button();
            this.tradingDataListBox = new System.Windows.Forms.ListBox();
            this.spinnerPic = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your symbol here: ";
            // 
            // symbolTxt
            // 
            this.symbolTxt.Location = new System.Drawing.Point(197, 26);
            this.symbolTxt.Name = "symbolTxt";
            this.symbolTxt.Size = new System.Drawing.Size(168, 27);
            this.symbolTxt.TabIndex = 1;
            // 
            // sendRequestBtn
            // 
            this.sendRequestBtn.Location = new System.Drawing.Point(526, 25);
            this.sendRequestBtn.Name = "sendRequestBtn";
            this.sendRequestBtn.Size = new System.Drawing.Size(127, 29);
            this.sendRequestBtn.TabIndex = 2;
            this.sendRequestBtn.Text = "Send Request";
            this.sendRequestBtn.UseVisualStyleBackColor = true;
            this.sendRequestBtn.Click += new System.EventHandler(this.sendRequestBtn_ClickAsync);
            // 
            // tradingDataListBox
            // 
            this.tradingDataListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tradingDataListBox.FormattingEnabled = true;
            this.tradingDataListBox.ItemHeight = 18;
            this.tradingDataListBox.Location = new System.Drawing.Point(23, 89);
            this.tradingDataListBox.Name = "tradingDataListBox";
            this.tradingDataListBox.Size = new System.Drawing.Size(732, 292);
            this.tradingDataListBox.TabIndex = 3;
            // 
            // spinnerPic
            // 
            this.spinnerPic.BackColor = System.Drawing.SystemColors.Window;
            this.spinnerPic.ErrorImage = null;
            this.spinnerPic.Image = global::Enverus.VWAPService.Properties.Resources.Infinity1;
            this.spinnerPic.InitialImage = global::Enverus.VWAPService.Properties.Resources.Infinity1;
            this.spinnerPic.Location = new System.Drawing.Point(295, 136);
            this.spinnerPic.Name = "spinnerPic";
            this.spinnerPic.Size = new System.Drawing.Size(202, 190);
            this.spinnerPic.TabIndex = 4;
            this.spinnerPic.TabStop = false;
            this.spinnerPic.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date and Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Open";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "High";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Low";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Close";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Volume";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(640, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "VWAP";
            // 
            // EnverusVWAPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 457);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spinnerPic);
            this.Controls.Add(this.tradingDataListBox);
            this.Controls.Add(this.sendRequestBtn);
            this.Controls.Add(this.symbolTxt);
            this.Controls.Add(this.label1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "EnverusVWAPForm";
            this.Text = "Enverus";
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolTxt;
        private System.Windows.Forms.Button sendRequestBtn;
        private System.Windows.Forms.ListBox tradingDataListBox;
        private System.Windows.Forms.PictureBox spinnerPic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

