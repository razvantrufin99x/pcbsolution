using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace pcbsolution
{
    public class pcb
    {
        public float currentpositionx;
        public float currentpositiony;
        public float lastpositionx;
        public float lastpositiony;
        public int firstgaura = 0;
        public float distantaintregauripeorizontala;
        public float distantaintregauripeverticala;
        public int numardestraturi;
        public dimensiune dimensiunea;
        public pozitie pozitia;
        public material materialulPlacii;
        public List<gaura> gauri = new List<gaura>();
        public List<pad> paduri = new List<pad>();
        public List<componenta> componente = new List<componenta>();
        public Color backdroungcolor = Color.LightGreen;
        public Color foredroungcolor = Color.White;
        public stil stilul;
        public int drawRedMicroLines = 0;
        public int nrofcomponentsofpcb = 0;
       

        public pcb() { }
        public pcb(dimensiune pdimensiunea, pozitie ppozitia, material pmaterialulPlacii)
        {
            dimensiunea = pdimensiunea;
            pozitia = ppozitia;
            materialulPlacii = pmaterialulPlacii;
            
        }
        public void drawWire(ref Graphics gg)
        {
            gg.DrawLine(new Pen(Color.Black, 1), currentpositionx, currentpositiony, lastpositionx, lastpositiony);
           
           
        }
        public void selectgaura(ref Graphics gg, float px, float py)
        {
            if (firstgaura == 0)
            {
                currentpositionx = px;
                currentpositiony = py;
                lastpositionx = currentpositionx;
                lastpositiony = currentpositiony;
                firstgaura = 1;
            }
            try
            {
                lastpositionx = currentpositionx;
                lastpositiony = currentpositiony;

                gg.FillEllipse(new SolidBrush(this.foredroungcolor), px - 3, py - 3, 8, 8);
                paduri.Add(new pad(8, 8, 1, px - 3, py - 3, 1));

                currentpositionx = px;
                currentpositiony = py;

                AdaugaComponenta(px, py, ref gg);
            
            this.drawWire(ref gg);

            }
            catch { }

        }

        public void AdaugaComponenta(float ppx, float ppy, ref Graphics ggg)
        {
            //adauga componenta in lista de compoennete
            nrofcomponentsofpcb = componente.Count;
            componente.Add(new componenta());
           

            componente[nrofcomponentsofpcb].pozitia = new pozitie();
            componente[nrofcomponentsofpcb].pozitia.x = ppx;
            componente[nrofcomponentsofpcb].pozitia.y = ppy;
            componente[nrofcomponentsofpcb].dimensiuni = new dimensiune();
            componente[nrofcomponentsofpcb].dimensiuni.latime = 10;
            componente[nrofcomponentsofpcb].dimensiuni.lungime = 50;
            componente[nrofcomponentsofpcb].stilul.foreground = Color.Black;
            componente[nrofcomponentsofpcb].drawComponenta(ref ggg);
        
        }
        
        public int GetNumberOfComponentsOnPCB()
        {
            return nrofcomponentsofpcb;
             
        }

        public void drawGauri(ref Graphics gg)
        {
            float nrgx = (dimensiunea.lungime / distantaintregauripeorizontala);
            float nrgy = (dimensiunea.latime / distantaintregauripeverticala);
            int margineLeft = 5;
            int margineTop = 5;
            for (int i = 1; i < nrgx ; i+= (int)distantaintregauripeorizontala )
            {
                for (int j = 1; j < nrgy ; j+= (int)distantaintregauripeverticala )
                {
                      gg.FillEllipse(new SolidBrush(this.foredroungcolor), margineLeft + pozitia.x + i * distantaintregauripeorizontala, margineTop + pozitia.y + j * distantaintregauripeverticala, 3, 3);
                      gg.DrawEllipse(new Pen(Color.Black, 1), margineLeft + pozitia.x + i * distantaintregauripeorizontala, margineTop + pozitia.y + j * distantaintregauripeverticala, 3, 3);
                      gauri.Add(new gaura(3,3,3,margineLeft + pozitia.x + i * distantaintregauripeorizontala,margineTop + pozitia.y + j * distantaintregauripeverticala,1));
                }
            }
        }


        public pereche GasesteGauraCeaMaiApropiata(int px, int py)
        {
            float difxc=0.0f;
            float difyc=0.0f;
            float minx = 100.0f;
            float miny = 100.0f;
            int retix = 0;
            int retiy = 0;
            pereche per = new pereche();

            for (int i = 1; i < gauri.Count; i++)
            {
                
                difxc = Math.Abs(gauri[i].pozitia.x - px);
                if (difxc < minx) { minx = difxc; retix = i; }
            }

            for (int i = 1; i < gauri.Count; i++)
            {

                difyc = Math.Abs(gauri[i].pozitia.y - py);
                if (difyc < miny) { miny = difyc; retiy = i; }
            }


            per.a = retix;
            per.b = retiy;
           


               return per;
        }



        public void drawBackGround(ref Graphics gg)
        {
            gg.FillRectangle(new SolidBrush(backdroungcolor), this.pozitia.x, this.pozitia.y, this.dimensiunea.lungime, this.dimensiunea.latime);
        }
        public void drawPCB(ref Graphics gg)
        {
            gg.DrawRectangle(new Pen(Color.Black, 5), this.pozitia.x, this.pozitia.y, this.dimensiunea.lungime, this.dimensiunea.latime);
           

        }

    }
}
