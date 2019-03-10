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
            this.grpreason = new System.Windows.Forms.GroupBox();
            this.btnreason = new System.Windows.Forms.Button();
            this.txtreason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpreason.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpreason
            // 
            this.grpreason.Controls.Add(this.btnreason);
            this.grpreason.Controls.Add(this.txtreason);
            this.grpreason.Controls.Add(this.label4);
            this.grpreason.Location = new System.Drawing.Point(2, 12);
            this.grpreason.Name = "grpreason";
            this.grpreason.Size = new System.Drawing.Size(270, 152);
            this.grpreason.TabIndex = 4;
            this.grpreason.TabStop = false;
            this.grpreason.Text = "Add reason";
            // 
            // btnreason
            // 
            this.btnreason.Location = new System.Drawing.Point(189, 120);
            this.btnreason.Name = "btnreason";
            this.btnreason.Size = new System.Drawing.Size(75, 23);
            this.btnreason.TabIndex = 23;
            this.btnreason.Text = "Add";
            this.btnreason.UseVisualStyleBackColor = true;
            this.btnreason.Click += new System.EventHandler(this.btnreason_Click);
            // 
            // txtreason
            // 
            this.txtreason.Location = new System.Drawing.Point(58, 25);
            this.txtreason.Multiline = true;
            this.txtreason.Name = "txtreason";
            this.txtreason.Size = new System.Drawing.Size(206, 89);
            this.txtreason.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Reason";
            // 
            // NewReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 169);
            this.Controls.Add(this.grpreason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewReasonForm";
            this.Text = "New Reason";
            this.grpreason.ResumeLayout(false);
            this.grpreason.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpreason;
        private System.Windows.Forms.Button btnreason;
        private System.Windows.Forms.TextBox txtreason;
        private System.Windows.Forms.Label label4;
    }
}