using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace L3
{
    public partial class Form1 : Form
    {
        Bitmap bit;
        Graphics graph;
        public Form1()
        {
            InitializeComponent();
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bit);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            drawCircle();
            drawBesye();
            drawLine2(70, 200, 254, 600,Color.Black);
            drawLine2(50, 350, 600, 350, Color.Black);
            
            fillMod(200, 200, Color.Red);
            fillMod(105,352,Color.White);
            fillMod(170, 352, Color.Green);
            fillMod(352, 349, Color.Pink);
            pictureBox1.Image = bit;
        }
        public void drawCircle()
        {
            int x0 = 200, y0 = 200, r = 100, x = 0, y = r;
            int d = 3 - 2 * r;
            while (y >= x)
            {
                draw8Pixels(x, x0, y, y0);
                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
        public void draw8Pixels(int x, int x0, int y, int y0)
        {
            bit.SetPixel(x+x0, y+y0, Color.Black);
            bit.SetPixel(x+x0, -y+y0, Color.Black);
            bit.SetPixel(-x+x0, y+y0, Color.Black);
            bit.SetPixel(-x+x0, -y+y0, Color.Black);
            bit.SetPixel(y+x0, x+y0, Color.Black);
            bit.SetPixel(y+x0, -x+y0, Color.Black);
            bit.SetPixel(-y+x0, x+y0, Color.Black);
            bit.SetPixel(-y+x0, -x+y0, Color.Black);
        }

        public void drawBesye()
        {
            int[] x = {100, 480, 550, 300};
            int[] y = {350, 700, 50, 350};
            int m = 3;
            double step = 0.001;
            for (double t = 0; t < 1; t += step)
            {
                double Px = Math.Pow((1 - t), 3) * x[0] + 3 * t * Math.Pow((1 - t), 2) * x[1] + 3 * Math.Pow(t, 2) * (1 - t) * x[2] + Math.Pow(t, 3) * x[3];
                double Py = Math.Pow((1 - t), 3) * y[0] + 3 * t * Math.Pow((1 - t), 2) * y[1] + 3 * Math.Pow(t, 2) * (1 - t) * y[2] + Math.Pow(t, 3) * y[3];
                bit.SetPixel((int)Px, (int)Py, Color.Black);
            }
        }
        private void Swap(ref int x, ref int y)
        {
            int buff = x;
            x = y;
            y = buff;
        }
        public void drawLine2(int x0, int y0, int x1, int y1, Color color)
        {
            bool flg = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (flg)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            double dx = x1 - x0;
            double dy = Math.Abs(y1 - y0);
            double m = dy / dx;
            double error = m - 0.5;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                bit.SetPixel(flg ? y : x, flg ? x : y, color);
                if (error >= 0)
                {
                    y += ystep;
                    error += m - 1;
                }
                else error += m;
            }
        }
        public void drawLine(int x0, int y0, int x1, int y1)
        {
            int x = x0;
            int y = y0;
            double dx = x1 - x0;
            //if (dx < 0)
            //{
            //    dx *= -1;
            //}
            double dy = y1 - y0;
            //if (dy < 0)
            //{
            //    dy *= -1;
            //}
            double m = dy / dx;
            double e = m - 0.5;
            int i = 0;
            while (i < dx)
            {
                if (e >= 0)
                {
                    y++;
                    e += m - 1;
                }
                else
                {
                    e += m;
                }
                x++;
                bit.SetPixel(x, y, Color.Black);
                i++;
            }
        }
        public void fill(int x, int y)
        {
            bit.SetPixel(x,y,Color.Red);
            if (!(Color.Black.ToArgb().Equals(bit.GetPixel(x + 1, y).ToArgb()))&&!(Color.Red.ToArgb().Equals(bit.GetPixel(x + 1, y).ToArgb())))
            {
                fill(x + 1, y);
            }
            if (!(Color.Black.ToArgb().Equals(bit.GetPixel(x - 1, y).ToArgb()))&&!(Color.Red.ToArgb().Equals(bit.GetPixel(x - 1, y).ToArgb())))
            {
                fill(x - 1, y);
            }
            if (!(Color.Black.ToArgb().Equals(bit.GetPixel(x, y+1).ToArgb()))&&!(Color.Red.ToArgb().Equals(bit.GetPixel(x, y+1).ToArgb())))
            {
                fill(x, y+1);
            }
            if (!(Color.Black.ToArgb().Equals(bit.GetPixel(x, y-1).ToArgb()))&&!(Color.Red.ToArgb().Equals(bit.GetPixel(x, y-1).ToArgb())))
            {
                fill(x, y-1);
            }
        }

        public void fillMod(int x, int y,Color color)
        {
            Color tmp_color = bit.GetPixel(x, y); 
            int xl = x;  
            int xr = x + 1;                 
            while ((xl >= 0) && (bit.GetPixel(xl, y) == tmp_color))
            {
                bit.SetPixel(xl, y, color);
                xl--;
            }
            xl++;
            while ((xr < bit.Width - 1) && (bit.GetPixel(xr, y) == tmp_color))
            {
                bit.SetPixel(xr, y, color);
                xr++;
            }
            xr--;
            int tmp_x = xl;
            while ((tmp_x <= xr) && (y != 0))
            {
                while ((tmp_x <= xr) && (bit.GetPixel(tmp_x, y - 1) != tmp_color))
                {
                    tmp_x++;
                }
                if (tmp_x <= xr) fillMod(tmp_x, y - 1, color);
                tmp_x++;
            }
            tmp_x = xl;
            while ((tmp_x <= xr) && (y + 1 != bit.Height))
            {
                while ((tmp_x <= xr) && (bit.GetPixel(tmp_x, y + 1) != tmp_color))
                {
                    tmp_x++;
                }
                if (tmp_x <= xr) fillMod(tmp_x, y + 1, color);
                tmp_x++;
            }
        }
      



    }
}

