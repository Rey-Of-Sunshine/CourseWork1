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
            this.quantitiTtiangle = new System.Windows.Forms.TextBox();
            this.quantitiRectangle = new System.Windows.Forms.TextBox();
            this.quantitiCircle = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dealet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
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
            this.gameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // quantitiTtiangle
            // 
            this.quantitiTtiangle.Location = new System.Drawing.Point(787, 72);
            this.quantitiTtiangle.Name = "quantitiTtiangle";
            this.quantitiTtiangle.ReadOnly = true;
            this.quantitiTtiangle.ShortcutsEnabled = false;
            this.quantitiTtiangle.Size = new System.Drawing.Size(40, 22);
            this.quantitiTtiangle.TabIndex = 1;
            this.quantitiTtiangle.TabStop = false;
            this.quantitiTtiangle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // quantitiRectangle
            // 
            this.quantitiRectangle.Location = new System.Drawing.Point(787, 159);
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
            this.quantitiCircle.Location = new System.Drawing.Point(787, 249);
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
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTriangle.Location = new System.Drawing.Point(672, 58);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(50, 50);
            this.buttonTriangle.TabIndex = 5;
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            this.buttonTriangle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonTriangle_Paint);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRectangle.Location = new System.Drawing.Point(672, 145);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(50, 50);
            this.buttonRectangle.TabIndex = 6;
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            this.buttonRectangle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonRectangle_Paint);
            // 
            // buttonCircle
            // 
            this.buttonCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCircle.Location = new System.Drawing.Point(672, 235);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(50, 50);
            this.buttonCircle.TabIndex = 7;
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            this.buttonCircle.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonCircle_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(714, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Осталось фигур";
            // 
            // dealet
            // 
            this.dealet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dealet.Location = new System.Drawing.Point(690, 320);
            this.dealet.Name = "dealet";
            this.dealet.Size = new System.Drawing.Size(125, 47);
            this.dealet.TabIndex = 9;
            this.dealet.Text = "убрать";
            this.dealet.UseVisualStyleBackColor = true;
            this.dealet.Click += new System.EventHandler(this.dealet_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(690, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Запустить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Stop
            // 
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Location = new System.Drawing.Point(690, 514);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(125, 47);
            this.Stop.TabIndex = 11;
            this.Stop.Text = "Остановить";
            this.Stop.UseVisualStyleBackColor = true;
            // 
            // GameProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 653);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dealet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.quantitiCircle);
            this.Controls.Add(this.quantitiRectangle);
            this.Controls.Add(this.quantitiTtiangle);
            this.Controls.Add(this.gameField);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(920, 700);
            this.MinimumSize = new System.Drawing.Size(920, 700);
            this.Name = "GameProcess";
            this.Text = "GameProcess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameField;
        private System.Windows.Forms.TextBox quantitiTtiangle;
        private System.Windows.Forms.TextBox quantitiRectangle;
        private System.Windows.Forms.TextBox quantitiCircle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dealet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Stop;
    }
}

