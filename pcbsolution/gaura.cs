using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pcbsolution
{
    public class gaura
    {
        public dimensiune dimensiunea = new dimensiune();
        public float raza = 3;
        public pozitie pozitia = new pozitie();
        public stil stilul;
        public gaura() { }
        public gaura(float pwidth, float pheigth, float pdepth, float px, float py, float pz)
        {
            dimensiunea.lungime = pwidth;
            dimensiunea.latime = pheigth;
            dimensiunea.inaltime = pdepth;
            pozitia.x = px;
            pozitia.y = py;
            pozitia.z = pz;

        }
    }
}
