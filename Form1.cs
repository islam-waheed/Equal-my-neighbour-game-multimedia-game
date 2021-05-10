using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ass13
{
    class actors
    {
        public int X, Y, W, H;
        public int type;
    }

    public partial class Form1 : Form
    {   
        public
        int Xpos, Ypo2,Ypos = 100, Xd = 100, Yd = 500;

        List<actors> L = new List<actors>();
        List<actors> L1 = new List<actors>();
        List<actors> L3 = new List<actors>();

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            creatActors();
        }

    

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                actors pnn = new actors();
                pnn.X = Xpos;
                pnn.Y = Ypo2 + 5;
                pnn.W = 40;
                pnn.H = 40;
                pnn.type = 1;
                L3.Add(pnn);
                Xpos += 10 + pnn.W;
                if (pnn.X >= 750)
                {
                    Xpos = Yd;
                    Ypo2 += 50;
                }

            }
            if (e.KeyCode == Keys.Enter)
            {
                if (L.Count == (L1.Count+L3.Count))
                {
                    MessageBox.Show("Good");
                }
                else
                {
                    MessageBox.Show("Bad");
                }
            }
      
            DrawScene();
        }

        void creatActors()
        {
            Random R = new Random();
            int n = R.Next(10, 20);
            int k = R.Next(1, 9);

            int p1 = 100;
            int p1y = Ypos;
            for (int i = 0; i < n; i++)
            {
                actors pnn = new actors();
                pnn.X = p1;
                pnn.Y = p1y + 5;
                pnn.W = 40;
                pnn.H = 40;
                L.Add(pnn);
                p1 += 10 + pnn.W;
                if (pnn.X >= 350)
                {
                    p1 = Xd;
                    p1y += 50;
                }

            }

            p1 = Yd;
            p1y = Ypos;
            for (int i = 0; i < k; i++)
            {
                actors pnn = new actors();
                pnn.X = p1;
                pnn.Y = p1y + 5;
                pnn.W = 40;
                pnn.H = 40;
                pnn.type = 2;
                L1.Add(pnn);
                p1 += 10 + pnn.W;
                if (pnn.X >= 750)
                {
                    p1 = Yd;
                    p1y += 50;
                }

            }
            Xpos = p1;
            Ypo2 = p1y;

        }

        void DrawScene()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);
            g.DrawRectangle(Pens.White, Xd, Ypos, 300, 300);
            g.DrawRectangle(Pens.Blue, Yd, Ypos, 300, 300);
            for (int i = 0; i < L.Count; i++)
            {
                g.FillRectangle(Brushes.Gray, L[i].X, L[i].Y, L[i].W, L[i].H);
            }

            for (int i = 0; i < L1.Count; i++)
            {
                
                    g.FillRectangle(Brushes.Blue, L1[i].X, L1[i].Y, L1[i].W, L1[i].H);
            }

            for (int i = 0; i < L3.Count; i++)
            {
                g.FillEllipse(Brushes.Red, L3[i].X, L3[i].Y, L3[i].W, L3[i].H);
            }
        }
    }
}
