using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        public Bitmap RedHeartTextur = Resource1.RedHeart,
                      KonturTexture = Resource1.Kontur;
                                
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(RedHeartTextur,new Rectangle(0,0,100,100));
            g.DrawImage(KonturTexture, new Rectangle(0, 0, 100, 100));
        }
    }
}
