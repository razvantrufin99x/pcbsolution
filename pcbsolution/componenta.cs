using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace pcbsolution
{
    public class componenta
    {
       public string denumire;
       public string tip;
       public List<pin> piniIntrare = new List<pin>();
       public List<pin> piniIesire = new List<pin>();
       public dimensiune dimensiuni = new dimensiune();
       public pozitie pozitia = new pozitie();
       public stil stilul = new stil();
        

       public void drawComponenta(ref Graphics gg)
       {
           gg.DrawRectangle(new Pen(stilul.foreground), this.pozitia.x, this.pozitia.y,  this.dimensiuni.lungime ,  this.dimensiuni.latime );
       }

    }
}
