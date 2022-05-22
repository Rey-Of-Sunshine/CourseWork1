namespace GeometryChess
{
    partial class StartWindow
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonStart.Location = new System.Drawing.Point(320, 300);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(266, 77);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Начать игру";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Lavender;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Exit.Location = new System.Drawing.Point(391, 543);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(127, 44);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выйти";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(902, 653);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.buttonStart);
            this.MaximumSize = new System.Drawing.Size(920, 700);
            this.MinimumSize = new System.Drawing.Size(920, 700);
            this.Name = "StartWindow";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button Exit;
    }
}