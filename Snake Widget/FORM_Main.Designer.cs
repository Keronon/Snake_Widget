namespace Snake_Widget
{
    partial class FORM_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_Main));
            this.TIME_er = new System.Windows.Forms.Timer(this.components);
            this.LBL_gameover = new System.Windows.Forms.Label();
            this.BTN_restart = new System.Windows.Forms.Button();
            this.PIC_field = new System.Windows.Forms.PictureBox();
            this.MNU_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LBL_win = new System.Windows.Forms.Label();
            this.BTN_play = new System.Windows.Forms.Button();
            this.LBL_complated = new System.Windows.Forms.Label();
            this.BTN_next = new System.Windows.Forms.Button();
            this.LBL_last = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_field)).BeginInit();
            this.SuspendLayout();
            // 
            // TIME_er
            // 
            this.TIME_er.Interval = 150;
            this.TIME_er.Tick += new System.EventHandler(this.TIME_er_Tick);
            // 
            // LBL_gameover
            // 
            this.LBL_gameover.AutoSize = true;
            this.LBL_gameover.BackColor = System.Drawing.Color.LightGreen;
            this.LBL_gameover.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_gameover.ForeColor = System.Drawing.Color.Red;
            this.LBL_gameover.Location = new System.Drawing.Point(36, 87);
            this.LBL_gameover.Name = "LBL_gameover";
            this.LBL_gameover.Size = new System.Drawing.Size(129, 28);
            this.LBL_gameover.TabIndex = 1;
            this.LBL_gameover.Text = "GAME OVER";
            this.LBL_gameover.Visible = false;
            // 
            // BTN_restart
            // 
            this.BTN_restart.BackColor = System.Drawing.Color.LightGreen;
            this.BTN_restart.FlatAppearance.BorderSize = 0;
            this.BTN_restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_restart.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_restart.ForeColor = System.Drawing.Color.DarkBlue;
            this.BTN_restart.Location = new System.Drawing.Point(64, 168);
            this.BTN_restart.Name = "BTN_restart";
            this.BTN_restart.Size = new System.Drawing.Size(75, 23);
            this.BTN_restart.TabIndex = 0;
            this.BTN_restart.Text = "RESTART";
            this.BTN_restart.UseVisualStyleBackColor = false;
            this.BTN_restart.Visible = false;
            this.BTN_restart.Click += new System.EventHandler(this.BTN_restart_Click);
            // 
            // PIC_field
            // 
            this.PIC_field.BackColor = System.Drawing.Color.LightGreen;
            this.PIC_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PIC_field.ContextMenuStrip = this.MNU_strip;
            this.PIC_field.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PIC_field.Location = new System.Drawing.Point(0, 0);
            this.PIC_field.Name = "PIC_field";
            this.PIC_field.Size = new System.Drawing.Size(202, 202);
            this.PIC_field.TabIndex = 0;
            this.PIC_field.TabStop = false;
            this.PIC_field.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PIC_field_MouseDown);
            this.PIC_field.MouseEnter += new System.EventHandler(this.PIC_field_MouseEnter);
            this.PIC_field.MouseLeave += new System.EventHandler(this.PIC_field_MouseLeave);
            this.PIC_field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PIC_field_MouseMove);
            // 
            // MNU_strip
            // 
            this.MNU_strip.Name = "MNU_strip";
            this.MNU_strip.Size = new System.Drawing.Size(61, 4);
            // 
            // LBL_win
            // 
            this.LBL_win.AutoSize = true;
            this.LBL_win.BackColor = System.Drawing.Color.LightGreen;
            this.LBL_win.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_win.ForeColor = System.Drawing.Color.Orange;
            this.LBL_win.Location = new System.Drawing.Point(75, 87);
            this.LBL_win.Name = "LBL_win";
            this.LBL_win.Size = new System.Drawing.Size(51, 28);
            this.LBL_win.TabIndex = 3;
            this.LBL_win.Text = "WIN";
            this.LBL_win.Visible = false;
            // 
            // BTN_play
            // 
            this.BTN_play.BackColor = System.Drawing.Color.LightGreen;
            this.BTN_play.FlatAppearance.BorderSize = 0;
            this.BTN_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_play.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_play.ForeColor = System.Drawing.Color.DarkBlue;
            this.BTN_play.Location = new System.Drawing.Point(79, 90);
            this.BTN_play.Name = "BTN_play";
            this.BTN_play.Size = new System.Drawing.Size(45, 23);
            this.BTN_play.TabIndex = 4;
            this.BTN_play.Text = "PLAY";
            this.BTN_play.UseVisualStyleBackColor = false;
            this.BTN_play.Click += new System.EventHandler(this.BTN_continue_Click);
            // 
            // LBL_complated
            // 
            this.LBL_complated.AutoSize = true;
            this.LBL_complated.BackColor = System.Drawing.Color.LightGreen;
            this.LBL_complated.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_complated.ForeColor = System.Drawing.Color.DarkBlue;
            this.LBL_complated.Location = new System.Drawing.Point(37, 87);
            this.LBL_complated.Name = "LBL_complated";
            this.LBL_complated.Size = new System.Drawing.Size(129, 28);
            this.LBL_complated.TabIndex = 5;
            this.LBL_complated.Text = "COMPLATED";
            this.LBL_complated.Visible = false;
            // 
            // BTN_next
            // 
            this.BTN_next.BackColor = System.Drawing.Color.LightGreen;
            this.BTN_next.FlatAppearance.BorderSize = 0;
            this.BTN_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_next.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_next.ForeColor = System.Drawing.Color.DarkBlue;
            this.BTN_next.Location = new System.Drawing.Point(64, 167);
            this.BTN_next.Name = "BTN_next";
            this.BTN_next.Size = new System.Drawing.Size(75, 23);
            this.BTN_next.TabIndex = 6;
            this.BTN_next.Text = "NEXT";
            this.BTN_next.UseVisualStyleBackColor = false;
            this.BTN_next.Visible = false;
            this.BTN_next.Click += new System.EventHandler(this.BTN_next_Click);
            // 
            // LBL_last
            // 
            this.LBL_last.AutoSize = true;
            this.LBL_last.BackColor = System.Drawing.Color.LightGreen;
            this.LBL_last.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBL_last.ForeColor = System.Drawing.Color.DarkGreen;
            this.LBL_last.Location = new System.Drawing.Point(43, 84);
            this.LBL_last.Name = "LBL_last";
            this.LBL_last.Size = new System.Drawing.Size(116, 28);
            this.LBL_last.TabIndex = 7;
            this.LBL_last.Text = "LAST MAP";
            this.LBL_last.Visible = false;
            // 
            // FORM_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(202, 202);
            this.Controls.Add(this.LBL_last);
            this.Controls.Add(this.BTN_next);
            this.Controls.Add(this.LBL_complated);
            this.Controls.Add(this.BTN_play);
            this.Controls.Add(this.LBL_win);
            this.Controls.Add(this.LBL_gameover);
            this.Controls.Add(this.BTN_restart);
            this.Controls.Add(this.PIC_field);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Snake";
            this.Shown += new System.EventHandler(this.FORM_Main_Shown);
            this.LocationChanged += new System.EventHandler(this.FORM_Main_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FORM_Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PIC_field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TIME_er;
        private System.Windows.Forms.Label LBL_gameover;
        private System.Windows.Forms.Button BTN_restart;
        private System.Windows.Forms.PictureBox PIC_field;
        private System.Windows.Forms.ContextMenuStrip MNU_strip;
        private System.Windows.Forms.Label LBL_win;
        private System.Windows.Forms.Button BTN_play;
        private System.Windows.Forms.Label LBL_complated;
        private System.Windows.Forms.Button BTN_next;
        private System.Windows.Forms.Label LBL_last;
    }
}

