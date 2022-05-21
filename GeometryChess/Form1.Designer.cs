namespace GeometryChess
{
    partial class GameProcess
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameField = new System.Windows.Forms.PictureBox();
            this.quantitiTriangle = new System.Windows.Forms.TextBox();
            this.quantitiRectangle = new System.Windows.Forms.TextBox();
            this.quantitiCircle = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.rules = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).BeginInit();
            this.SuspendLayout();
            // 
            // gameField
            // 
            this.gameField.Location = new System.Drawing.Point(34, 48);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(408, 408);
            this.gameField.TabIndex = 0;
            this.gameField.TabStop = false;
            this.gameField.Paint += new System.Windows.Forms.PaintEventHandler(this.gameField_Paint);
            this.gameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // quantitiTriangle
            // 
            this.quantitiTriangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quantitiTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantitiTriangle.Location = new System.Drawing.Point(787, 113);
            this.quantitiTriangle.Name = "quantitiTriangle";
            this.quantitiTriangle.ReadOnly = true;
            this.quantitiTriangle.ShortcutsEnabled = false;
            this.quantitiTriangle.Size = new System.Drawing.Size(40, 22);
            this.quantitiTriangle.TabIndex = 1;
            this.quantitiTriangle.TabStop = false;
            this.quantitiTriangle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // quantitiRectangle
            // 
            this.quantitiRectangle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quantitiRectangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantitiRectangle.Location = new System.Drawing.Point(787, 200);
            this.quantitiRectangle.Name = "quantitiRectangle";
            this.quantitiRectangle.ReadOnly = true;
            this.quantitiRectangle.ShortcutsEnabled = false;
            this.quantitiRectangle.Size = new System.Drawing.Size(40, 22);
            this.quantitiRectangle.TabIndex = 2;
            this.quantitiRectangle.TabStop = false;
            this.quantitiRectangle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // quantitiCircle
            // 
            this.quantitiCircle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.quantitiCircle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantitiCircle.Location = new System.Drawing.Point(787, 290);
            this.quantitiCircle.Name = "quantitiCircle";
            this.quantitiCircle.ReadOnly = true;
            this.quantitiCircle.ShortcutsEnabled = false;
            this.quantitiCircle.Size = new System.Drawing.Size(40, 22);
            this.quantitiCircle.TabIndex = 3;
            this.quantitiCircle.TabStop = false;
            this.quantitiCircle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.buttonTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTriangle.Location = new System.Drawing.Point(672, 99);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(50, 50);
            this.buttonTriangle.TabIndex = 5;
            this.buttonTriangle.UseVisualStyleBackColor = false;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            this.buttonTriangle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonTriangle_Paint);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.buttonRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRectangle.Location = new System.Drawing.Point(672, 186);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(50, 50);
            this.buttonRectangle.TabIndex = 6;
            this.buttonRectangle.UseVisualStyleBackColor = false;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            this.buttonRectangle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonRectangle_Paint);
            // 
            // buttonCircle
            // 
            this.buttonCircle.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.buttonCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCircle.Location = new System.Drawing.Point(672, 276);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(50, 50);
            this.buttonCircle.TabIndex = 7;
            this.buttonCircle.UseVisualStyleBackColor = false;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            this.buttonCircle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCircle_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(714, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Осталось фигур";
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.ForeColor = System.Drawing.Color.DarkGreen;
            this.delete.Location = new System.Drawing.Point(690, 361);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(125, 47);
            this.delete.TabIndex = 9;
            this.delete.Text = "убрать";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.dealet_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Honeydew;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.ForeColor = System.Drawing.Color.Green;
            this.Start.Location = new System.Drawing.Point(690, 453);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(125, 47);
            this.Start.TabIndex = 10;
            this.Start.Text = "Запустить";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.Honeydew;
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.ForeColor = System.Drawing.Color.Green;
            this.Stop.Location = new System.Drawing.Point(690, 514);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(125, 47);
            this.Stop.TabIndex = 11;
            this.Stop.Text = "Остановить";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // rules
            // 
            this.rules.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rules.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.rules.Location = new System.Drawing.Point(787, 12);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(95, 31);
            this.rules.TabIndex = 12;
            this.rules.Text = "правила";
            this.rules.UseVisualStyleBackColor = false;
            this.rules.Click += new System.EventHandler(this.правила_Click);
            // 
            // GameProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(902, 653);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.quantitiCircle);
            this.Controls.Add(this.quantitiRectangle);
            this.Controls.Add(this.quantitiTriangle);
            this.Controls.Add(this.gameField);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(920, 700);
            this.MinimumSize = new System.Drawing.Size(920, 700);
            this.Name = "GameProcess";
            this.Text = "GameProcess";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameField;
        private System.Windows.Forms.TextBox quantitiTriangle;
        private System.Windows.Forms.TextBox quantitiRectangle;
        private System.Windows.Forms.TextBox quantitiCircle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button rules;
    }
}

