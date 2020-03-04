using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MathUtilLibrary;
namespace ProjectEcole1
{
    class Polyline : CartoObj, IIsPointClose, IPointy, IComparable<Polyline>
    {
        private List<Coordonnees> lCoordonnees;
        private Color color;
        private int epaisseur;
        public Polyline() : base()
        {
            lCoordonnees = new List<Coordonnees>();
            color = Colors.White;
            epaisseur = 0;
        }
        public Polyline(int ep, Color col, Coordonnees[] coord) : this()
        {
           // c = new Collection<Coordonnees>();
            for (int i = 0; i < coord.Length; i++)
                lCoordonnees.Add(coord[i]);

            epaisseur = ep;
            color = col;

        }
        ~Polyline()
        {
            for (int i = 0; i < lCoordonnees.Count; i++)
            {
                lCoordonnees.RemoveAt(i);
            }
        }
        public void AddCoord(Coordonnees coord)
        {
            lCoordonnees.Add(coord);

        }
       public override int nbPoint
            {
            get { return lCoordonnees.Count; }
            }
        public override string ToString()
        {
            string tmp = "---------------------------------------------" + Environment.NewLine;
             tmp +="Polyline " + base.ToString() +Environment.NewLine+ " " + "Epaisseur = " + epaisseur + " Couleur = " + color.ToString() + Environment.NewLine;
            for (int i = 0; i < lCoordonnees.Count(); i++)
            {
                tmp += lCoordonnees[i].ToString();
                tmp += Environment.NewLine;
            }
            tmp += "---------------------------------------------" + Environment.NewLine;
            return tmp;
        }
        public override void Draw()
        {
            base.Draw();
            this.ToString();

        }

        public bool IsPointClose(double x, double y, double precision)
        {
            double distance;
            /// Normalement un polyline est composé d'au moins une ligne (même si on parlera plus d'une line que d'un polyline)
            if (lCoordonnees.Count < 2) 
                return false;
            for(int i=0;i<lCoordonnees.Count-1;i++)
            {
                ///Distance premier point du segment
                distance = MathUtil.DistanceDeuxPoints(x, y, lCoordonnees[i].X, lCoordonnees[i].Y);
                if (distance <= precision)
                    return true;
                ///Distance deuxieme point du segment
                distance = MathUtil.DistanceDeuxPoints(x, y, lCoordonnees[i + 1].X, lCoordonnees[i + 1].Y);
                if (distance <= precision)
                    return true;
                ///Distance points segment
                ///Calcul du coefficient directeut (y2 -y1)/(x2-x1)
                distance = MathUtil.DistancePointSegment(x, y, lCoordonnees[i].X, lCoordonnees[i].Y, lCoordonnees[i + 1].X, lCoordonnees[i + 1].Y);
                if (distance <= precision)
                    return true;

            }
            return false;

        }
        ///Implémentation IComparable<Polyline>
        public int CompareTo(Polyline poly)
        {
            if (poly == null) return 1;

            return LongueurPolyline().CompareTo(poly.LongueurPolyline()); 
               
        }

        public double LongueurPolyline()
        {
            double distance = 0;
            int i = 0;
            while(i< lCoordonnees.Count-1)
            {
                distance += MathUtil.DistanceDeuxPoints(lCoordonnees[i].X, lCoordonnees[i].Y, lCoordonnees[++i].X, lCoordonnees[++i].Y); 
            }
            return distance;
        }

        public List<Coordonnees> lCoord
        {
            get { return lCoordonnees; }
        }
        public bool SurfaceSame(Polyline poly)
        {
            if (CalculSurface() == poly.CalculSurface())
                return true;
            else
                return false;
        }
        public double CalculSurface()
        {
            Coordonnees[] bBox = new Coordonnees[4]
            {

                new Coordonnees(lCoord.Min(Coordonnees=> Coordonnees.X),lCoord.Max(Coordonnees=> Coordonnees.Y)),       ///(xMin,yMax)
                new Coordonnees(lCoord.Min(Coordonnees=> Coordonnees.X),lCoord.Min(Coordonnees=> Coordonnees.Y)),       ///(xMin,yMin)
                new Coordonnees(lCoord.Max(Coordonnees=> Coordonnees.X),lCoord.Min(Coordonnees=> Coordonnees.Y)),       ///(xMax,yMin)
                new Coordonnees(lCoord.Max(Coordonnees=> Coordonnees.X),lCoord.Max(Coordonnees=> Coordonnees.Y)),       ///(xMax,yMax)

            };

            return Math.Abs(MathUtil.DistanceDeuxPoints(bBox[0].X, bBox[0].Y, bBox[1].X, bBox[1].Y) * MathUtil.DistanceDeuxPoints(bBox[1].X, bBox[1].Y, bBox[2].X, bBox[2].Y));
        }

    }
}
