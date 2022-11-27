


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pcbsolution
{


    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        public Graphics g;

        public pcb pcb0 = new pcb();

        private void Form1_Load(object sender, EventArgs e)
        {

            g = CreateGraphics();


           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pcb0.distantaintregauripeorizontala = 5;
            pcb0.distantaintregauripeverticala = 5;
            pcb0.numardestraturi = 1;
            dimensiune dimpcb0 = new dimensiune();
            dimpcb0.inaltime = 0.3f;
            dimpcb0.latime = 700.0f;
            dimpcb0.lungime = 900.0f;
            pozitie pozpcb0 = new pozitie();
            pozpcb0.x = 10.0f;
            pozpcb0.y = 10.0f;
            pozpcb0.z = 1.0f;
            pcb0.dimensiunea = dimpcb0;
            pcb0.pozitia = pozpcb0;

            pcb0.drawBackGround(ref g);
            pcb0.drawPCB(ref g);
            pcb0.drawGauri(ref g);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int ggaurax = (int)pcb0.GasesteGauraCeaMaiApropiata(e.X, e.Y).a;
                Text = ggaurax.ToString();
                Text += " : ";
                int ggauray = (int)pcb0.GasesteGauraCeaMaiApropiata(e.X, e.Y).b;
                Text = ggauray.ToString();
                int px = e.X;
                int py = e.Y;
                if ((px > pcb0.pozitia.x && px < pcb0.pozitia.x + pcb0.dimensiunea.lungime)
                     &&
                     (py > pcb0.pozitia.y && py < pcb0.pozitia.y + pcb0.dimensiunea.latime))
                {
                    pcb0.selectgaura(ref g, pcb0.gauri[ggaurax].pozitia.x, pcb0.gauri[ggauray].pozitia.y);
                    pcb0.drawWire(ref g);

                    if (pcb0.drawRedMicroLines == 1)
                    {
                        g.DrawLine(new Pen(Color.Red), e.X, e.Y, pcb0.gauri[ggaurax].pozitia.x, pcb0.gauri[ggauray].pozitia.y);
                    }
                }
                button2.Text = (pcb0.GetNumberOfComponentsOnPCB()).ToString();
            }
            catch { }
           
        }

        public void drawLineAtMouseMove(int px , int py)
        {

          
          try
            {
                int ggaurax = (int)pcb0.GasesteGauraCeaMaiApropiata(px, py).a;
                Text = ggaurax.ToString();
                Text += " : ";
                int ggauray = (int)pcb0.GasesteGauraCeaMaiApropiata(px, py).b;
                Text = ggauray.ToString();
                if ((px > pcb0.pozitia.x && px < pcb0.pozitia.x + pcb0.dimensiunea.lungime)
                    &&
                    (py > pcb0.pozitia.y && py < pcb0.pozitia.y + pcb0.dimensiunea.latime))
                {
                    if (pcb0.drawRedMicroLines == 1)
                    {
                        g.DrawLine(new Pen(Color.Red), px, py, pcb0.gauri[ggaurax].pozitia.x, pcb0.gauri[ggauray].pozitia.y);
                    }
                }
            }
            catch { }
          

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
                Text = e.X.ToString() + " : " + e.Y.ToString();
                drawLineAtMouseMove( e.X,  e.Y);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = (pcb0.GetNumberOfComponentsOnPCB()+1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pcb0.componente[0].drawComponenta(ref g);
        }
    }
}
