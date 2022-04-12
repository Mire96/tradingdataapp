
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
            this.sendRequestBtn.Location = new System.Drawing.Point(427, 25);
            this.sendRequestBtn.Name = "sendRequestBtn";
            this.sendRequestBtn.Size = new System.Drawing.Size(127, 29);
            this.sendRequestBtn.TabIndex = 2;
            this.sendRequestBtn.Text = "Send Request";
            this.sendRequestBtn.UseVisualStyleBackColor = true;
            this.sendRequestBtn.Click += new System.EventHandler(this.sendRequestBtn_ClickAsync);
            // 
            // tradingDataListBox
            // 
            this.tradingDataListBox.FormattingEnabled = true;
            this.tradingDataListBox.ItemHeight = 20;
            this.tradingDataListBox.Location = new System.Drawing.Point(55, 91);
            this.tradingDataListBox.Name = "tradingDataListBox";
            this.tradingDataListBox.Size = new System.Drawing.Size(1054, 304);
            this.tradingDataListBox.TabIndex = 3;
            // 
            // EnverusVWAPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 457);
            this.Controls.Add(this.tradingDataListBox);
            this.Controls.Add(this.sendRequestBtn);
            this.Controls.Add(this.symbolTxt);
            this.Controls.Add(this.label1);
            this.Name = "EnverusVWAPForm";
            this.Text = "Enverus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolTxt;
        private System.Windows.Forms.Button sendRequestBtn;
        private System.Windows.Forms.ListBox tradingDataListBox;
    }
}

