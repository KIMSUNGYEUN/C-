using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Hanoi_Tower_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x1, x2, x3;
        int n, m = 0, p = 0;
        ListBox listBox1;
        //Button button1;
        //TextBox textBox1;
        PictureBox pictureBox1;
        Timer timer1;
        Graphics graphics;
        Bitmap bitmap;
        Pen pen;
        int[,] box;
        char[,] move;
        SolidBrush solid;
        private void hanoi(int h, char s, char i, char d)
        {
            if (h == 1)
            {
                listBox1.Items.Add(s + "==>" + d);
                move[0, m] = s;
                move[1, m] = d;
                m++;
            }

            else
            {
                hanoi(h - 1, s, d, i);
                hanoi(1, s, i, d);
                hanoi(h - 1, i, s, d);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            timer1.Enabled = true;
            listBox1.Items.Clear();
            n = int.Parse(textBox1.Text);
            box = new int[3, n];
            move = new char[2, 1000];
            for (i = 0; i < n; i++)
                box[0, i] = n - i;
            hanoi(n, 'A', 'B', 'C');
            draw_();
            timer1.Enabled = true;
        }

        private void refr()
        {
            pictureBox1.Image = bitmap;
        }

        private int pow(int a, int b)
        {
            if (b != 0)
                return a * pow(a, b - 1);
            else return 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1 = new ListBox();
            listBox1.Parent = this;
            listBox1.Location = new Point(10, 10);
            listBox1.Size = new Size(70, 400);

            button1 = new Button();
            button1.Parent = this;
            button1.Location = new Point(500, 30);
            button1.Click += new EventHandler(button1_Click);
            button1.Text = "Create";

            textBox1 = new TextBox();
            textBox1.Parent = this;
            textBox1.Location = new Point(130, 30);
            textBox1.Text = "3";

            pictureBox1 = new PictureBox();
            pictureBox1.Parent = this;
            pictureBox1.Location = new Point(100, 100);
            pictureBox1.Size = new Size(700, 400);
            pictureBox1.BackColor = Color.White;

            timer1 = new Timer();
            timer1.Interval = 300;
            timer1.Tick += new EventHandler(timer1_Tick);

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(bitmap);

            pen = new Pen(Color.Black, 3);
        }

        private void draw_()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(box[i,j] != 0)
                    {
                        switch(box[i, j])
                        {
                            case 1: solid = new SolidBrush(Color.Red); break;
                            case 2: solid = new SolidBrush(Color.Pink); break;
                            case 3: solid = new SolidBrush(Color.Yellow); break;
                            case 4: solid = new SolidBrush(Color.Green); break;
                            case 5: solid = new SolidBrush(Color.Blue); break;
                            case 6: solid = new SolidBrush(Color.Brown); break;
                            case 7: solid = new SolidBrush(Color.DarkOrange); break;
                            case 8: solid = new SolidBrush(Color.DarkRed); break;
                        }
                        graphics.FillRectangle(solid, (i + 1) * 190 - 60 - (box[i, j]) * 10, 320 - j * 30, box[i, j] * 20, 30);
                    }
                }
            }
            
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);

            x1 = -1;
            x2 = -1;
            x3 = -1;

            graphics.DrawLine(pen, 60, 350, 200, 350);
            graphics.DrawLine(pen, 250, 350, 390, 350);
            graphics.DrawLine(pen, 440, 350, 580, 350);
            graphics.DrawLine(pen, 130, 350, 130, 150);
            graphics.DrawLine(pen, 320, 350, 320, 150);
            graphics.DrawLine(pen, 510, 350, 510, 150);

            for(int i = 0; i<n; i++)
                if(box[0, i] == 0)
                { x1 = i; break; }
            for (int i = 0; i < n; i++)
                if (box[1, i] == 0)
                { x2 = i; break; }
            for (int i = 0; i < n; i++)
                if (box[2, i] == 0)
                { x3 = i; break; }
            if (x1 == -1)
                x1 = n;
            if (x2 == -1)
                x2 = n;
            if (x3 == -1)
                x3 = n;

            switch (move[0, p])
            {
                case 'A':
                    switch (move[1, p])
                    {
                        case 'B':
                            box[1, x2] = box[0, x1 - 1];
                            box[0, x1 - 1] = 0;
                            break;
                        case 'C':
                            box[2, x3] = box[0, x1 - 1];
                            box[0, x1 - 1] = 0;
                            break;
                    }
                    break;

                case 'B':
                    switch (move[1, p])
                    {
                        case 'A':
                            box[0, x1] = box[1, x2 - 1];
                            box[1, x2 - 1] = 0;
                            break;
                        case 'C':
                            box[2, x3] = box[1, x2 - 1];
                            box[1, x2 - 1] = 0;
                            break;
                    }
                    break;

                case 'C':
                    switch (move[1, p])
                    {
                        case 'A':
                            box[0, x1] = box[2, x3 - 1];
                            box[2, x3 - 1] = 0;
                            break;
                        case 'B':
                            box[1, x2] = box[2, x3 - 1];
                            box[2, x3 - 1] = 0;
                            break;
                    }
                    break;
            }

            draw_();
            refr();
            p++;
        }

    }
}
