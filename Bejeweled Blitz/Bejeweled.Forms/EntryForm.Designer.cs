
namespace Bejeweled.Forms {
    partial class EntryForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.button1 = new System.Windows.Forms.Button();
            this._droplabel = new System.Windows.Forms.Label();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._speedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._sizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._handleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._prioritizeColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._speedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sizeNumeric)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _droplabel
            // 
            this._droplabel.BackColor = System.Drawing.Color.Gray;
            this._droplabel.Font = new System.Drawing.Font("Calibri", 14F);
            this._droplabel.Location = new System.Drawing.Point(121, 101);
            this._droplabel.Name = "_droplabel";
            this._droplabel.Size = new System.Drawing.Size(180, 106);
            this._droplabel.TabIndex = 1;
            this._droplabel.Text = "Drap && Drop at \r\nthe left-top corner";
            this._droplabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._droplabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.droplabel_MouseUp);
            // 
            // _timer
            // 
            this._timer.Interval = 800;
            // 
            // _speedNumeric
            // 
            this._speedNumeric.Font = new System.Drawing.Font("Calibri", 16F);
            this._speedNumeric.Location = new System.Drawing.Point(120, 58);
            this._speedNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this._speedNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._speedNumeric.Name = "_speedNumeric";
            this._speedNumeric.Size = new System.Drawing.Size(181, 40);
            this._speedNumeric.TabIndex = 2;
            this._speedNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._speedNumeric.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F);
            this.label1.Location = new System.Drawing.Point(120, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ctrl + F1 = Stop\r\nCtrl + F2 = Start\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16F);
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interval";
            // 
            // _sizeNumeric
            // 
            this._sizeNumeric.Font = new System.Drawing.Font("Calibri", 16F);
            this._sizeNumeric.Location = new System.Drawing.Point(120, 12);
            this._sizeNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this._sizeNumeric.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this._sizeNumeric.Name = "_sizeNumeric";
            this._sizeNumeric.Size = new System.Drawing.Size(181, 40);
            this._sizeNumeric.TabIndex = 2;
            this._sizeNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._sizeNumeric.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F);
            this.label3.Location = new System.Drawing.Point(58, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this._handleLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 328);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(310, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(218, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel1.Text = "Handle:";
            // 
            // _handleLabel
            // 
            this._handleLabel.Name = "_handleLabel";
            this._handleLabel.Size = new System.Drawing.Size(17, 20);
            this._handleLabel.Text = "0";
            // 
            // _prioritizeColor
            // 
            this._prioritizeColor.Font = new System.Drawing.Font("Calibri", 16F);
            this._prioritizeColor.FormattingEnabled = true;
            this._prioritizeColor.Location = new System.Drawing.Point(120, 210);
            this._prioritizeColor.Name = "_prioritizeColor";
            this._prioritizeColor.Size = new System.Drawing.Size(181, 41);
            this._prioritizeColor.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16F);
            this.label4.Location = new System.Drawing.Point(5, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "Prioritize";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 106);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(310, 354);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._prioritizeColor);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._sizeNumeric);
            this.Controls.Add(this._speedNumeric);
            this.Controls.Add(this._droplabel);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntryForm";
            this.Text = "Bejewled Blitz";
            ((System.ComponentModel.ISupportInitialize)(this._speedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sizeNumeric)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label _droplabel;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.NumericUpDown _speedNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _sizeNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel _handleLabel;
        private System.Windows.Forms.ComboBox _prioritizeColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

