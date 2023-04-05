using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabVez1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            this.Width = 700;
            this.Height = 700;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics,g1=CreateGraphics(),g2=CreateGraphics();
            Pen p1 = new Pen(Color.Black, 1), p2 = new Pen(Color.Blue, 3),
                p3 = new Pen(Color.Green, 2), p4 = new Pen(Color.Red, 2); //inicijalizacija Pen-ova
            Rectangle r1 = new Rectangle(50, 50, 250, 500)
                , r2 = new Rectangle(65, 55, 225, 490)
                , r3 = new Rectangle(150, 450, 50, 50)
                , r4 = new Rectangle(155, 98, 40, 365); //inicijalizacija pravougaonika
            LinearGradientBrush gb1 = new LinearGradientBrush(r1, Color.Gray, Color.White, LinearGradientMode.Horizontal),
                gb2 = new LinearGradientBrush(r2, Color.White, Color.Gray, LinearGradientMode.Horizontal); // inicijalizacija Brush-eva
            g.DrawRectangle(p1, r1);
            g.FillRectangle(gb1, r1);
            g.FillRectangle(gb2, r2); //iscrtavanje pozadine termostata
            GraphicsPath gp = new GraphicsPath(), gp1 = new GraphicsPath(), gp2 = new GraphicsPath(); //inicijalizacija putanja

            SolidBrush crv = new SolidBrush(Color.Red); //inicijalizacija Brush-a za bojenje

            
            FontFamily FontFamily = new FontFamily("Arial");
            Point tacka1 = new Point(85, 425), tacka2 = new Point(230, 405);
            StringFormat myStringFormat = new StringFormat();                //FontFamily,StringFormat i početne tačke za slova F i C
            String[] Celzijusi = { "-20°", "-10°", "0°", "10°", "20°", "30°", "40°" };//Brojevi za skalu
            for (int i = 0; i < 7; i++)
            {
                gp2.AddString(Celzijusi[i], FontFamily, 0, 18, tacka1, myStringFormat);
                g.DrawPath(p1, gp2);
                gp2.Reset();
                tacka1.Y = tacka1.Y - 50;
            }//Postavljanje brojeva za celzijusovu skalu
            String[] Ferenheiti = { "0°", "20°", "40°", "60°", "80°", "100°" };//Brojevi za Ferenhajta
            for (int i = 0; i < 6; i++)
            {
                gp2.AddString(Ferenheiti[i], FontFamily, 0, 18, tacka2, myStringFormat);
                g.DrawPath(p1, gp2);
                gp2.Reset();
                tacka2.Y = tacka2.Y - 55;

            }//Postavljanje brojeva za Ferenhajta

            Point pt1 = new Point(155, 440), pt2 = new Point(140, 440),pt3=new Point(133,440);//tačke za C podeoke
            Point pt4 = new Point(195,419),pt5=new Point(210,419),pt6=new Point(220,419);
            for (int i = 0; i < 35; i++)
            {
                if (i == 0 || i == 5 || i == 10 || i == 15 || i == 20 || i == 25 || i == 30)
                {
                    g1.DrawLine(p2, pt1, pt3);
                }
                else
                {
                    g1.DrawLine(p3, pt1, pt2);
                }
                if (i < 30)
                {
                    if (i == 0 || i == 5 || i == 10 || i == 15 || i == 20 || i == 25 )
                    {
                        g2.DrawLine(p2, pt4, pt6);
                    }
                    else
                    {
                        g2.DrawLine(p3, pt4, pt5);
                    }


                }
                g2.TranslateTransform(0, -11);
                g1.TranslateTransform(0, -10);//Transliranje 
            }

            Point tacka3 = new Point(100, 470), tacka4 = new Point(220, 470); //Tačke za F i C
            gp2.AddString("C°", FontFamily, 0, 30, tacka3, myStringFormat);
            gp2.AddString("F°", FontFamily, 0, 30, tacka4, myStringFormat);
            g.DrawPath(p4, gp2);
            gp2.Reset();
            
            gp.AddEllipse(r3);
            gp.AddRectangle(r4);
            g.DrawPath(p1, gp);
            g.FillEllipse(crv, r3);//Postavljanje kruga i pravougaonika za skale
        }



        public void Pokazi()
        {
            string temp = textBox1.Text;
            Graphics g = this.CreateGraphics();
            Rectangle Recttemp = new Rectangle(155, 98, 40, 365);
            SolidBrush br = new SolidBrush(Color.Red),bb=new SolidBrush(Color.Gray);
           
            g.FillRectangle(bb, Recttemp);
            int  i = 0;
            for (int brojac = 48; brojac >= -20; brojac--)
            {
                if (brojac.ToString() != temp && brojac % 2 == 0)
                {
                    i=i+1;
                }
                else if (brojac.ToString() == temp)
                {
                    break;
                }
            }
            Recttemp.Y = Recttemp.Y + i * 10;
            Recttemp.Height = Recttemp.Height - i * 10;
            g.FillRectangle(br, Recttemp);//Crtanje skale na osnovu unete temperature
        }
        public void Slika() 
        {            
            Graphics g = this.CreateGraphics();
            Rectangle r = new Rectangle(340, 250, 400, 400);
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, r);
            int temp = Int32.Parse(textBox1.Text);
            if (temp > 15)
            {
                Bitmap bm = new Bitmap(Properties.Resources.Capture);
                g.DrawImage(bm, 340, 300);//Slika sunca
            }
            else if (temp <= 15 && temp > 0)
            {

                Point[] tacke =
                   {
                new Point(400,400),new Point(600,400),
                new Point(625,340),new Point(600,300),
                new Point(580,290),new Point(540,320),
                new Point(530,340),new Point(520,320),
                new Point(530,300),new Point(510,280),
                new Point(510,270),new Point(490,260),
                new Point(460,260),new Point(400,260),
                new Point(380,270),new Point(380,300),
                new Point(350,350),new Point(400,400)
                };
                Pen p = new Pen(Color.Black, 5);
                g.DrawCurve(p, tacke);//Crtanje oblaka uz pomoć krive
            }
            else if (temp <= 0)
            {
                float[] dashvalues = { 5, 5, 5, 5 };
                float[] dashvalues1 = { 5, 5, 5 };
                Pen p1 = new Pen(Color.Black, 3), p2 = new Pen(Color.Black, 3);
                p1.DashPattern = dashvalues;
                p2.DashPattern = dashvalues1;
                g.DrawLine(p1, new Point(450, 300), new Point(390, 400));
                g.DrawLine(p2, new Point(470, 320), new Point(420, 410));
                g.DrawLine(p1, new Point(490, 340), new Point(440, 430));
                g.DrawLine(p2, new Point(520, 330), new Point(470, 430));
                g.DrawLine(p1, new Point(550, 330), new Point(500, 425));//Crtanje pahuljica uz pomoć patterna
            }
        
        
        
        
        }
        private void PokaziTemp(object sender, EventArgs e)
        {
            Pokazi();
            Slika();
        }
    }
}