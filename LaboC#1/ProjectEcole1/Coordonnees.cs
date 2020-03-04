using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtilLibrary;
namespace ProjectLibraryClass
{
    public class Coordonnees : CartoObj
    {
        private double x;
        private double y;
        public Coordonnees() : base()
        {
            x = 0;
            y = 0;
        }
        public Coordonnees(double nX, double nY) : this()
        {
            x = nX;
            y = nY;
        }

        public override string ToString()
        {
            return base.ToString() + " Coordonnee : (" + x.ToString("#.000") + " , " + y.ToString("#.000") + " )";

        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public override int nbPoint
        {
            get { return 1; }
        }

    }
}
