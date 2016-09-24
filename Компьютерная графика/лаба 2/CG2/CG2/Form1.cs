using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace CG2
{
    public partial class formGraphics : Form
    {
        private const String acsioma = "F";
        private const String rule = "F-F++F-F";
        private const int angle = 60;
        private const int lengthLine = 150;
        Bitmap bit;
        Graphics graph;
        public formGraphics()
        {
            InitializeComponent();
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bit);
            label2.Visible = false;
        }

        private void zeroStepButton_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            String stepStr = textBox1.Text;
            int step=0;
            if (!("".Equals(stepStr)))
            {
                step = Convert.ToInt32(stepStr);
            }
            else
            {
                label2.Text = "Введите значение";
                label2.Visible = true;
            }
            String outString = "";
            if (step > 0)
            {
                outString = getRule(step);
            }
            else
            {
                label2.Text = "Введите корректное значение";
                label2.Visible = true;
            }
            paint(outString, step);

        }
 

        private String getRule(int step)
        {
            String outString = acsioma;
            for (int i = 0; i < step; i++)
            {
                outString = outString.Replace(acsioma, rule);
            }
            return outString;
        }

        private void paint(String outString, int step)
        {
            float x1 = 10;
            float y1 = 400;
            double rang = 2;
            if (step > 4)
            {
                rang = 2.8;
            }
            if (step > 6)
            {
                rang = 3.2;
            }
            if (step > 7)
            {
                rang = 3.6;
            }
            double line = lengthLine / Math.Pow(step,rang);
            float x2 = x1 + Convert.ToSingle(line);
            float y2 = y1;
            bool isAngle = false;
            int angle2 = 0;
            for (int i = 0; i < outString.Length; i++)
            {
                switch (outString[i])
                {
                    case 'F':
                        graph.DrawLine(new Pen(Color.Black, 3.0f), new PointF(x1, y1), new PointF(x2, y2));
                        x1 = x2;
                        y1 = y2;
                        break;
                    case '+':
                        angle2 -= angle;
                        x2 = x1 + Convert.ToSingle(Math.Cos(angle2*Math.PI/180) * line);
                        y2 = y1 - Convert.ToSingle(Math.Sin(angle2 * Math.PI / 180) * line);
                        break;
                    case '-':
                        angle2 += angle;
                        x2 = x1 + Convert.ToSingle(Math.Cos(angle2 * Math.PI / 180) * line);
                        y2 = y1 - Convert.ToSingle(Math.Sin(angle2 * Math.PI / 180) * line);
                        break;

                }
                pictureBox1.Image = bit;
            }
            

        }

       

       


        

       
    }
}
