namespace GeometryChess
{
    partial class End_Reload
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
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.winer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReload
            // 
            this.buttonReload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReload.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReload.Location = new System.Drawing.Point(196, 220);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(240, 47);
            this.buttonReload.TabIndex = 1;
            this.buttonReload.Text = "Заново";
            this.buttonReload.UseVisualStyleBackColor = false;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(196, 314);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(240, 47);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Завершить";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // winer
            // 
            this.winer.AutoSize = true;
            this.winer.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.winer.Location = new System.Drawing.Point(188, 142);
            this.winer.Name = "winer";
            this.winer.Size = new System.Drawing.Size(102, 43);
            this.winer.TabIndex = 3;
            this.winer.Text = "label1";
            this.winer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // End_Reload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 466);
            this.Controls.Add(this.winer);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReload);
            this.MaximumSize = new System.Drawing.Size(652, 513);
            this.MinimumSize = new System.Drawing.Size(652, 513);
            this.Name = "End_Reload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End_Reload";
            this.Load += new System.EventHandler(this.End_Reload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label winer;
    }
}