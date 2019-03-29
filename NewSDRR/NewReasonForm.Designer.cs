namespace NewSDRR
{
    partial class NewReasonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.contactnoTxt = new System.Windows.Forms.TextBox();
            this.fnameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.grpreason = new System.Windows.Forms.GroupBox();
            this.btnreason = new System.Windows.Forms.Button();
            this.txtreason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpreason.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contactnoTxt
            // 
            this.contactnoTxt.Location = new System.Drawing.Point(110, 95);
            this.contactnoTxt.Name = "contactnoTxt";
            this.contactnoTxt.Size = new System.Drawing.Size(133, 20);
            this.contactnoTxt.TabIndex = 22;
            // 
            // fnameTxt
            // 
            this.fnameTxt.Location = new System.Drawing.Point(110, 69);
            this.fnameTxt.Name = "fnameTxt";
            this.fnameTxt.Size = new System.Drawing.Size(133, 20);
            this.fnameTxt.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Contact no :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            // 
            // cboPosition
            // 
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Items.AddRange(new object[] {
            "Driver",
            "Helper"});
            this.cboPosition.Location = new System.Drawing.Point(110, 42);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(133, 21);
            this.cboPosition.TabIndex = 16;
            // 
            // grpreason
            // 
            this.grpreason.BackColor = System.Drawing.Color.White;
            this.grpreason.Controls.Add(this.btnreason);
            this.grpreason.Controls.Add(this.txtreason);
            this.grpreason.Controls.Add(this.label4);
            this.grpreason.ForeColor = System.Drawing.Color.Black;
            this.grpreason.Location = new System.Drawing.Point(2, 9);
            this.grpreason.Name = "grpreason";
            this.grpreason.Size = new System.Drawing.Size(270, 152);
            this.grpreason.TabIndex = 11;
            this.grpreason.TabStop = false;
            this.grpreason.Text = "Add reason";
            this.grpreason.Visible = false;
            // 
            // btnreason
            // 
            this.btnreason.BackColor = System.Drawing.Color.White;
            this.btnreason.ForeColor = System.Drawing.Color.Black;
            this.btnreason.Location = new System.Drawing.Point(189, 120);
            this.btnreason.Name = "btnreason";
            this.btnreason.Size = new System.Drawing.Size(75, 23);
            this.btnreason.TabIndex = 23;
            this.btnreason.Text = "Add";
            this.btnreason.UseVisualStyleBackColor = false;
            this.btnreason.Click += new System.EventHandler(this.btnreason_Click);
            // 
            // txtreason
            // 
            this.txtreason.BackColor = System.Drawing.Color.White;
            this.txtreason.ForeColor = System.Drawing.Color.Black;
            this.txtreason.Location = new System.Drawing.Point(58, 25);
            this.txtreason.Multiline = true;
            this.txtreason.Name = "txtreason";
            this.txtreason.Size = new System.Drawing.Size(206, 89);
            this.txtreason.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Reason";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Position: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.contactnoTxt);
            this.groupBox2.Controls.Add(this.fnameTxt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboPosition);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(4, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 151);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver/Helper Form";
            this.groupBox2.Visible = false;
            // 
            // NewReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 169);
            this.Controls.Add(this.grpreason);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewReasonForm";
            this.Text = "New Reason";
            this.grpreason.ResumeLayout(false);
            this.grpreason.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox contactnoTxt;
        private System.Windows.Forms.TextBox fnameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.GroupBox grpreason;
        private System.Windows.Forms.Button btnreason;
        private System.Windows.Forms.TextBox txtreason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}