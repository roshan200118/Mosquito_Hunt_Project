namespace RoshanNanthapalanA1MosquitoHunt
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblRestart = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblInsectRepellent = new System.Windows.Forms.Label();
            this.lblEnergyDrinks = new System.Windows.Forms.Label();
            this.pnlHomeScreen = new System.Windows.Forms.Panel();
            this.picControls = new System.Windows.Forms.PictureBox();
            this.lblPlay = new System.Windows.Forms.Label();
            this.lblControls = new System.Windows.Forms.Label();
            this.lblCurrentHealth = new System.Windows.Forms.Label();
            this.lblMaxHealth = new System.Windows.Forms.Label();
            this.pnlStatus.SuspendLayout();
            this.pnlHomeScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picControls)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 15;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Yellow;
            this.pnlStatus.Controls.Add(this.lblMaxHealth);
            this.pnlStatus.Controls.Add(this.lblCurrentHealth);
            this.pnlStatus.Controls.Add(this.lblHome);
            this.pnlStatus.Controls.Add(this.lblRestart);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.lblKills);
            this.pnlStatus.Controls.Add(this.lblInsectRepellent);
            this.pnlStatus.Controls.Add(this.lblEnergyDrinks);
            this.pnlStatus.ForeColor = System.Drawing.Color.Red;
            this.pnlStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1018, 86);
            this.pnlStatus.TabIndex = 0;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.Location = new System.Drawing.Point(109, 49);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(50, 22);
            this.lblHome.TabIndex = 7;
            this.lblHome.Text = "Home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.Location = new System.Drawing.Point(12, 49);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(64, 22);
            this.lblRestart.TabIndex = 6;
            this.lblRestart.Text = "Restart";
            this.lblRestart.Click += new System.EventHandler(this.lblRestart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(396, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(298, 39);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "SWAT MOSQUITOS!!";
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.Location = new System.Drawing.Point(5, 4);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(47, 22);
            this.lblKills.TabIndex = 0;
            this.lblKills.Text = "Kills:";
            // 
            // lblInsectRepellent
            // 
            this.lblInsectRepellent.AutoSize = true;
            this.lblInsectRepellent.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsectRepellent.Location = new System.Drawing.Point(845, 49);
            this.lblInsectRepellent.Name = "lblInsectRepellent";
            this.lblInsectRepellent.Size = new System.Drawing.Size(134, 22);
            this.lblInsectRepellent.TabIndex = 3;
            this.lblInsectRepellent.Text = "Insect Repellent:";
            // 
            // lblEnergyDrinks
            // 
            this.lblEnergyDrinks.AutoSize = true;
            this.lblEnergyDrinks.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergyDrinks.Location = new System.Drawing.Point(859, 9);
            this.lblEnergyDrinks.Name = "lblEnergyDrinks";
            this.lblEnergyDrinks.Size = new System.Drawing.Size(120, 22);
            this.lblEnergyDrinks.TabIndex = 2;
            this.lblEnergyDrinks.Text = "Energy Drinks:";
            // 
            // pnlHomeScreen
            // 
            this.pnlHomeScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHomeScreen.BackgroundImage")));
            this.pnlHomeScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHomeScreen.Controls.Add(this.lblControls);
            this.pnlHomeScreen.Controls.Add(this.lblPlay);
            this.pnlHomeScreen.Controls.Add(this.picControls);
            this.pnlHomeScreen.Location = new System.Drawing.Point(863, 458);
            this.pnlHomeScreen.Name = "pnlHomeScreen";
            this.pnlHomeScreen.Size = new System.Drawing.Size(1035, 700);
            this.pnlHomeScreen.TabIndex = 1;
            this.pnlHomeScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHomeScreen_Paint);
            // 
            // picControls
            // 
            this.picControls.Image = ((System.Drawing.Image)(resources.GetObject("picControls.Image")));
            this.picControls.Location = new System.Drawing.Point(214, 238);
            this.picControls.Name = "picControls";
            this.picControls.Size = new System.Drawing.Size(665, 336);
            this.picControls.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picControls.TabIndex = 2;
            this.picControls.TabStop = false;
            // 
            // lblPlay
            // 
            this.lblPlay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPlay.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlay.ForeColor = System.Drawing.Color.Yellow;
            this.lblPlay.Location = new System.Drawing.Point(261, 133);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(138, 55);
            this.lblPlay.TabIndex = 3;
            this.lblPlay.Text = "Play";
            this.lblPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlay.Click += new System.EventHandler(this.lblPlay_Click);
            // 
            // lblControls
            // 
            this.lblControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblControls.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControls.ForeColor = System.Drawing.Color.Yellow;
            this.lblControls.Location = new System.Drawing.Point(680, 133);
            this.lblControls.Name = "lblControls";
            this.lblControls.Size = new System.Drawing.Size(138, 55);
            this.lblControls.TabIndex = 4;
            this.lblControls.Text = "Controls";
            this.lblControls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblControls.Click += new System.EventHandler(this.lblControls_Click);
            // 
            // lblCurrentHealth
            // 
            this.lblCurrentHealth.AutoSize = true;
            this.lblCurrentHealth.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHealth.Location = new System.Drawing.Point(190, 9);
            this.lblCurrentHealth.Name = "lblCurrentHealth";
            this.lblCurrentHealth.Size = new System.Drawing.Size(127, 22);
            this.lblCurrentHealth.TabIndex = 8;
            this.lblCurrentHealth.Text = "Current Health:";
            // 
            // lblMaxHealth
            // 
            this.lblMaxHealth.AutoSize = true;
            this.lblMaxHealth.Font = new System.Drawing.Font("Jokerman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxHealth.Location = new System.Drawing.Point(190, 49);
            this.lblMaxHealth.Name = "lblMaxHealth";
            this.lblMaxHealth.Size = new System.Drawing.Size(98, 22);
            this.lblMaxHealth.TabIndex = 9;
            this.lblMaxHealth.Text = "Max Health:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1019, 661);
            this.Controls.Add(this.pnlHomeScreen);
            this.Controls.Add(this.pnlStatus);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseClick);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlHomeScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInsectRepellent;
        private System.Windows.Forms.Label lblEnergyDrinks;
        private System.Windows.Forms.Panel pnlHomeScreen;
        private System.Windows.Forms.PictureBox picControls;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.Label lblControls;
        private System.Windows.Forms.Label lblMaxHealth;
        private System.Windows.Forms.Label lblCurrentHealth;
    }
}

