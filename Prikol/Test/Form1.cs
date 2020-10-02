using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Bitmap RedHeartTextur = Resource1.bear,
                      KonturTexture = Resource1.honey;
        private Point _targetPosition = new Point(300, 300);
        private Point _direction = Point.Empty;
        private int _score = 0;


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            timer2.Interval = r.Next(25, 1000);
            _direction.X = r.Next(-1, 2);
            _direction.Y = r.Next(-1, 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += _direction.X * 50;
            _targetPosition.Y += _direction.Y * 50;

            if (_targetPosition.X < 0 || _targetPosition.X > 500)
                _direction.X *= -1;
            if (_targetPosition.Y < 0 || _targetPosition.Y > 500)
                _direction.Y *= -1;
            Point Beetwin = new Point(localPosition.X - _targetPosition.X, localPosition.Y - _targetPosition.Y);
            float distanse = (float)Math.Sqrt((Beetwin.X * Beetwin.X) + (Beetwin.Y * Beetwin.Y));
            if (distanse < 20)
            {
                addscore(1);
            }
            var HundlerRect = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);
            var HoneyRect = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);

            g.DrawImage(RedHeartTextur, HundlerRect);
            g.DrawImage(KonturTexture, HoneyRect);
        }

      /*  private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Refresh();
        }*/

        private void addscore(int score)
        {
            _score += score;
            label2.Text = _score.ToString();
        }
    }
}
