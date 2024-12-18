namespace Lab5
{
    partial class Form1
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
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerAdd = new System.Windows.Forms.Timer(this.components);
            this.gamePanel = new Lab5.DoubleBufferedPanel();
            this.mainMenuBox = new System.Windows.Forms.GroupBox();
            this.labelCredits = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonTrial = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelGuide = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.gamePanel.SuspendLayout();
            this.mainMenuBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timerMenu
            // 
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // gamePanel
            // 
            this.gamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gamePanel.Controls.Add(this.mainMenuBox);
            this.gamePanel.Controls.Add(this.labelGuide);
            this.gamePanel.Controls.Add(this.pictureBox2);
            this.gamePanel.Controls.Add(this.progressBar1);
            this.gamePanel.Controls.Add(this.textBox2);
            this.gamePanel.Controls.Add(this.buttonPause);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 450);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gamePanel_MouseClick);
            // 
            // mainMenuBox
            // 
            this.mainMenuBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainMenuBox.Controls.Add(this.labelCredits);
            this.mainMenuBox.Controls.Add(this.button1);
            this.mainMenuBox.Controls.Add(this.buttonSettings);
            this.mainMenuBox.Controls.Add(this.buttonTrial);
            this.mainMenuBox.Controls.Add(this.pictureBox1);
            this.mainMenuBox.Controls.Add(this.buttonExit);
            this.mainMenuBox.Controls.Add(this.buttonStart);
            this.mainMenuBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainMenuBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.mainMenuBox.Location = new System.Drawing.Point(0, 0);
            this.mainMenuBox.Name = "mainMenuBox";
            this.mainMenuBox.Size = new System.Drawing.Size(800, 450);
            this.mainMenuBox.TabIndex = 0;
            this.mainMenuBox.TabStop = false;
            // 
            // labelCredits
            // 
            this.labelCredits.AutoSize = true;
            this.labelCredits.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCredits.Location = new System.Drawing.Point(6, 361);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(0, 13);
            this.labelCredits.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(7, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = global::Lab5.Properties.Resources.Btn;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSettings.Location = new System.Drawing.Point(270, 380);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(260, 25);
            this.buttonSettings.TabIndex = 7;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // buttonTrial
            // 
            this.buttonTrial.BackgroundImage = global::Lab5.Properties.Resources.Btn;
            this.buttonTrial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTrial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTrial.Location = new System.Drawing.Point(270, 349);
            this.buttonTrial.Name = "buttonTrial";
            this.buttonTrial.Size = new System.Drawing.Size(260, 25);
            this.buttonTrial.TabIndex = 4;
            this.buttonTrial.TabStop = false;
            this.buttonTrial.Text = "Пробный";
            this.buttonTrial.UseVisualStyleBackColor = true;
            this.buttonTrial.Click += new System.EventHandler(this.buttonTrial_Click);
            this.buttonTrial.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonTrial.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::Lab5.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(7, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(781, 224);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = global::Lab5.Properties.Resources.Btn;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExit.Location = new System.Drawing.Point(270, 411);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(260, 25);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.TabStop = false;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // buttonStart
            // 
            this.buttonStart.BackgroundImage = global::Lab5.Properties.Resources.Btn;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Location = new System.Drawing.Point(270, 318);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(260, 25);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.buttonStart.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // labelGuide
            // 
            this.labelGuide.AutoSize = true;
            this.labelGuide.Location = new System.Drawing.Point(23, 13);
            this.labelGuide.Name = "labelGuide";
            this.labelGuide.Size = new System.Drawing.Size(0, 13);
            this.labelGuide.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Lab5.Properties.Resources.coin_1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(737, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 20);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(659, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(659, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            // 
            // buttonPause
            // 
            this.buttonPause.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonPause.BackgroundImage = global::Lab5.Properties.Resources.pause;
            this.buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPause.Location = new System.Drawing.Point(765, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(23, 21);
            this.buttonPause.TabIndex = 3;
            this.buttonPause.TabStop = false;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gamePanel);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "MySekiro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.mainMenuBox.ResumeLayout(false);
            this.mainMenuBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox mainMenuBox;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Timer timerAnimation;
        private DoubleBufferedPanel gamePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerAdd;
        private System.Windows.Forms.Button buttonTrial;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelGuide;
        private System.Windows.Forms.Label labelCredits;
    }
}

