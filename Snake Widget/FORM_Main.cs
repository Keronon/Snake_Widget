using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Widget
{
    public partial class FORM_Main : Form
    {
        #region FIELDs

        Random rand;

        private int x, y;

        private Point apple;
        private bool  golden_apple;
        private int   golden_apple_time;

        private Point       last_direction;
        private Point       direction;
        private List<Point> snake;
        private int         max_snake;
        private int         stop_del_snake;

        private List<Point> map;
        private int         map_num;
        private bool        map_last;
        private Point       step;
        private Point       map_side;

        private int         last_time;

        private Brush golden_apple_b;
        private Brush apple_b;
        private Brush snake_b;
        private Brush brick_b;
        private Brush grass_b;

        #endregion FIELDs

        private const int WS_EX_TOOLWINDOW = 0x80;
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= WS_EX_TOOLWINDOW;
                return Params;
            }
        }

        #region FORM CONTROL

        public FORM_Main()
        {
            InitializeComponent();
            if (Properties.Settings.Default._widget_pos.X != -1) Location = Properties.Settings.Default._widget_pos;
            PIC_field.Image = new Bitmap(PIC_field.Width, PIC_field.Height);

            ToolStripMenuItem close = new ToolStripMenuItem("Выключить");
            MNU_strip.Items.Add(close);
            close.Click += (s, e) => { Application.Exit(); };

            rand = new Random();

            // PICTURE VALUES
            golden_apple_b = Brushes.Goldenrod;
            apple_b = Brushes.OrangeRed;
            snake_b = Brushes.DarkGreen;
            brick_b = Brushes.SandyBrown;
            grass_b = Brushes.LightGreen;

            // -----
            Restart();
        }
        private void FORM_Main_Shown(object sender, EventArgs e) { SendToBack(); }

        private void FORM_Main_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._widget_pos = Location;
            Properties.Settings.Default.Save();
        }

        private void PIC_field_MouseDown(object sender, MouseEventArgs e) { x = e.X; y = e.Y; }
        private void PIC_field_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left = (Left + e.X) - x;
                Top = (Top + e.Y) - y;
                Size size = Screen.PrimaryScreen.Bounds.Size;
                if (Left > size.Width - Width - 10) Left = size.Width - Width;
                if (Top > size.Height - Height - 10) Top = size.Height - Height;
                if (Left < 10) Left = 0;
                if (Top < 10) Top = 0;
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();
        private void PIC_field_MouseEnter(object sender, EventArgs e)
        {
            if (GetActiveWindow() != Handle)
            {
                SendToBack();
                WindowState = FormWindowState.Minimized;
                WindowState = FormWindowState.Normal;
                if (BTN_restart.Visible)
                    BTN_restart.Focus();
                else if (BTN_play.Visible)
                    BTN_play.Focus();
                else if (BTN_next.Visible)
                    BTN_play.Focus();
            }
        }
        private void PIC_field_MouseLeave(object sender, EventArgs e)
        {
            SendToBack();
            if (TIME_er.Enabled)
            {
                BTN_play.Show();
                TIME_er.Stop();
            }
        }

        private void TIME_er_Tick(object sender, EventArgs e)
        {
            if (last_time > 0) { last_time--; return; }
            if (last_time == 0) { last_time--; LBL_last.Hide(); }

            Point new_p = new Point(snake[0].X + direction.X, snake[0].Y + direction.Y);
            last_direction = direction;
            if (new_p.X < 0) new_p.X = map_side.X - 1;
            else if (new_p.X > map_side.X - 1) new_p.X = 0;
            else if (new_p.Y < 0) new_p.Y = map_side.Y - 1;
            else if (new_p.Y > map_side.Y - 1) new_p.Y = 0;

            if (map.Contains(new_p))
            {
                LBL_gameover.Show();
                BTN_restart.Show();
                BTN_restart.Focus();
                TIME_er.Stop();
                return;
            }

            using (var field = Graphics.FromImage(PIC_field.Image))
            {
                if (new_p == apple)
                {
                    if (golden_apple) stop_del_snake += 3;
                    else stop_del_snake++;
                    Create_apple(field);
                }
                else if (golden_apple_time > 0)
                {
                    golden_apple_time--;
                }
                else if (golden_apple_time == 0)
                {
                    field.FillEllipse(grass_b, apple.X * step.X, apple.Y * step.Y, step.X, step.Y);
                    Create_apple(field);
                }

                if (stop_del_snake == 0)
                {
                    field.FillEllipse(grass_b, snake[snake.Count - 1].X * step.X, snake[snake.Count - 1].Y * step.Y, step.X, step.Y);
                    snake.RemoveAt(snake.Count - 1);
                }
                else
                {
                    stop_del_snake--;
                }
                int index = snake.IndexOf(new_p);
                if (index >= 0)
                {
                    for (int i = snake.Count - 1; i >= index; i--)
                    {
                        field.FillEllipse(grass_b, snake[i].X * step.X, snake[i].Y * step.Y, step.X, step.Y);
                        snake.RemoveAt(i);
                    }
                }
                field.FillEllipse(snake_b, new_p.X * step.X, new_p.Y * step.Y, step.X, step.Y);
                snake.Insert(0, new_p);
            }

            if (snake.Count == max_snake)
            {
                if (map_last)
                {
                    LBL_win.Show();
                    BTN_restart.Show();
                    BTN_restart.Focus();
                }
                else
                {
                    LBL_complated.Show();
                    BTN_next.Show();
                    BTN_next.Focus();
                }
                TIME_er.Stop();
                return;
            }
            PIC_field.Refresh();
        }

        private void FORM_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (GetActiveWindow() == Handle)
                     if (e.KeyCode == Keys.Up    && last_direction.Y == 0) { direction.X = 0;  direction.Y = -1; }
                else if (e.KeyCode == Keys.Down  && last_direction.Y == 0) { direction.X = 0;  direction.Y = 1; }
                else if (e.KeyCode == Keys.Left  && last_direction.X == 0) { direction.X = -1; direction.Y = 0; }
                else if (e.KeyCode == Keys.Right && last_direction.X == 0) { direction.X = 1;  direction.Y = 0; }
        }

        private void BTN_next_Click(object sender, EventArgs e) { LBL_complated.Hide(); BTN_next.Hide(); map_num++; Load_map(map_num); Focus(); TIME_er.Start(); }

        private void BTN_continue_Click(object sender, EventArgs e) { BTN_play.Hide(); Focus(); TIME_er.Start(); }

        private void BTN_restart_Click(object sender, EventArgs e) { LBL_win.Hide(); LBL_gameover.Hide(); BTN_restart.Hide(); Restart(); Focus(); TIME_er.Start(); }

        #endregion FORM CONTROL

        private void Restart()
        {
            map_num = 1;
            map_last = false;
            max_snake = 20;
            if (!Load_map(map_num)) Environment.Exit(0);
        }

        private bool Load_map(int _map_num)
        {
            List<string> map_lines = null;
            try { map_lines = File.ReadAllLines($"maps/{_map_num}.map").ToList(); }
            catch { MessageBox.Show("====================\nplease, check maps folder\n\ngame will be closed\n====================", "CAN NOT LOAD MAP"); return false; }

            if (map_lines[0] == "LAST")
            {
                map_last = true;
                max_snake = 30;
                last_time = 5;
                LBL_last.Show();
                map_lines.RemoveAt(0);
            }
            else last_time = -1;

            snake = new List<Point>();
            stop_del_snake = 0;

            map = new List<Point>();
            map_side.Y = map_lines.Count;
            step.Y = PIC_field.Height / map_side.Y;

            using (var field = Graphics.FromImage(PIC_field.Image))
            {
                field.Clear(Color.LightGreen);

                for (int i = 0; i < map_side.Y; i++)
                {
                    map_side.X = map_lines[i].Length;
                    step.X = PIC_field.Width / map_side.X;
                    for (int j = 0; j < map_side.X; j++)
                    {
                        if (map_lines[i][j] == 'x') // map
                        {
                            map.Add(new Point(j, i));
                            field.FillRectangle(brick_b, j * step.Y, i * step.X, step.X, step.Y);
                        }
                        else if (map_lines[i][j] == 'o') // snake
                        {
                            snake.Add(new Point(j, i));
                            field.FillEllipse(snake_b, j * step.Y, i * step.X, step.X, step.Y);
                        }
                        else field.FillRectangle(grass_b, j * step.Y, i * step.X, step.X, step.Y);
                    }
                }

                Create_apple(field); // apple
            }

            int snake_last = snake.Count - 1;
            direction = new Point(snake[snake_last - 1].X - snake[snake_last].X, snake[snake_last - 1].Y - snake[snake_last].Y);
            last_direction = direction;

            return true;
        }

        private void Create_apple(Graphics field)
        {
            do
            {
                apple.X = rand.Next(map_side.X - 1);
                apple.Y = rand.Next(map_side.Y - 1);
                if (rand.Next(10) < 2) { golden_apple = true; golden_apple_time = 30; }
                else { golden_apple = false; golden_apple_time = -1; }
            }
            while (map.Contains(apple) || snake.Contains(apple));

            if (golden_apple) field.FillEllipse(golden_apple_b, apple.X * step.X, apple.Y * step.Y, step.X, step.Y);
            else field.FillEllipse(apple_b, apple.X * step.X, apple.Y * step.Y, step.X, step.Y);
        }
    }
}
