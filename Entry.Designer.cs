namespace ForestMan
{
    partial class Entry
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
            System.Windows.Forms.Button startGame;
            this.aboutMe = new System.Windows.Forms.Button();
            startGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            startGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            startGame.AutoSize = true;
            startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            startGame.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            startGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            startGame.FlatAppearance.BorderSize = 0;
            startGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            startGame.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            startGame.ForeColor = System.Drawing.Color.MidnightBlue;
            startGame.Location = new System.Drawing.Point(314, 267);
            startGame.Name = "startGame";
            startGame.Size = new System.Drawing.Size(169, 52);
            startGame.TabIndex = 0;
            startGame.Text = "开始游戏";
            startGame.UseCompatibleTextRendering = true;
            startGame.UseVisualStyleBackColor = false;
            startGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // aboutMe
            // 
            this.aboutMe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aboutMe.AutoSize = true;
            this.aboutMe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.aboutMe.FlatAppearance.BorderSize = 0;
            this.aboutMe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.aboutMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutMe.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aboutMe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.aboutMe.Location = new System.Drawing.Point(336, 336);
            this.aboutMe.Name = "aboutMe";
            this.aboutMe.Size = new System.Drawing.Size(116, 39);
            this.aboutMe.TabIndex = 1;
            this.aboutMe.Text = "关于我";
            this.aboutMe.UseVisualStyleBackColor = false;
            this.aboutMe.Click += new System.EventHandler(this.aboutMe_Click);
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ForestMan.Properties.Resources.冰火人背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutMe);
            this.Controls.Add(startGame);
            this.Name = "Entry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "森林冰火人";
            this.Load += new System.EventHandler(this.Entry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aboutMe;
    }
}