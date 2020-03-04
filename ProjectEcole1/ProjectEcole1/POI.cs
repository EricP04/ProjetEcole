using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathUtilLibrary;
namespace ProjectEcole1
{
    class POI : Coordonnees, IIsPointClose
    {
        private string description;
        public POI(double x= 50.610869,double y =5.510435) : base(x,y)
        {
            
            description = "Hepl life";
        }
        public POI(string nDes,double x, double y) : this(x,y)
        {
            description = nDes;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public override string ToString()
        {
            ///string buf = String.Format(base.ToString()+" " +"Nom : " + description);
            return base.ToString() + " Nom : " + description;
        }
        public bool IsPointClose(double x, double y, double precision)
        {
            bool isClose = false;
            double distance = MathUtil.DistanceDeuxPoints(X, Y, x, y);
            Console.WriteLine("Distance = " + distance + " Precision  = " + precision);
            if (distance <=precision)
                isClose = true;
                

            return isClose;
        }
        public override int nbPoint
        {
            get { return 1; }
        }

    }
}
