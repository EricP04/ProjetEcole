using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MathUtilLibrary;

/**
 * Créer une classe Polygon qui hérite de CartoObj et décrite par
• Une collection de coordonnées (références d’objets
Coordonnees),
• Une couleur de remplissage,
• Une couleur de contour,
• Un niveau d’opacité (double compris entre 0 et 1)
• Un constructeur par défaut
• Un constructeur d’initialisation
• La surcharge de la méthode ToString()
• La redéfinition de la méthode Draw() qui affiche les
informations concernant l’objet polygon dans la console
• TESTER LA CLASSE*/
namespace ProjectLibraryClass
{
    
   public  class Polygon : CartoObj,IIsPointClose,IPointy
    {
        private List<Coordonnees> lCoordonnees;
        private Color remplissage;
        private Color contour;
        private double opacite;
        public Polygon() : base()
        {
            
               lCoordonnees = new List<Coordonnees>();

            remplissage = Colors.Green;
            contour = Colors.Red;
            opacite = 0.5;
        }
        public Polygon(Coordonnees[] co, Color rempli, Color cont, double op) : this()
        {
            for(int i=0;i<co.Length;i++)
            {
                lCoordonnees.Add(co[i]);
            }
            remplissage = rempli;
            contour = cont;
            opacite = op;
        }
        public override string ToString()
        {  
            string tmp = "---------------------------------------------" + Environment.NewLine;
            tmp += "Polygon " + base.ToString() + Environment.NewLine+ "Couleur de remplissage : " + remplissage.ToString() + " Couleur de contour : " + contour.ToString() + " Opacite : " + opacite.ToString() + Environment.NewLine;
            for(int i=0;i<lCoordonnees.Count(); i++)
            {
                tmp += lCoordonnees[i].ToString();
                tmp += Environment.NewLine;
            }
            tmp += "---------------------------------------------" + Environment.NewLine;
            return tmp;
        }
        public override void Draw()
        {
            this.ToString();
        }
        public override int nbPoint
        {
            get { return lCoordonnees.Count; }
        }
        public bool IsPointClose(double x, double y, double precision)
        {
            ///D'abord on regarde si le point X Y appartient a la bouding box du polygone
            ///(Sinon ca ne sert à rien d'être plus précis)
            bool appartient = false;
            {
                double Xmax, Xmin, Ymax, Ymin;
                Xmax = lCoord.Max(Coordonnees => Coordonnees.X);
                Xmin = lCoord.Min(Coordonnees => Coordonnees.X);
                Ymax = lCoord.Max(Coordonnees => Coordonnees.Y);
                Ymin = lCoord.Min(Coordonnees => Coordonnees.Y);
                if (x < Xmin || x > Xmax || y > Ymax || y < Ymin)
                    return false;
            }

            ///Le point est AU MOINS dans la bouding box
            ///Maintenant l'on va être plus précis
            int i = 0;
            if(lCoordonnees.Count %2 == 0) /// ¨Pair, on repete
            {
                while(i<lCoordonnees.Count)
                {
                    if (i == lCoordonnees.Count - 2)
                    {
                        
                        appartient = MathUtil.IsInTriangle(lCoordonnees[i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, lCoordonnees[0].X,lCoordonnees[0].Y, x, y);
                        ++i;
                    }
                    else
                        appartient = MathUtil.IsInTriangle(lCoordonnees[i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, x,y);

                    if (appartient)
                        return appartient;
                }

                return appartient;
            }
            else /// Impair on ne repete pas
            {
                while(i<lCoordonnees.Count)
                {
                    if (i == lCoordonnees.Count - 2)
                        appartient = MathUtil.IsInTriangle(lCoordonnees[i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, lCoordonnees[0].X,lCoordonnees[0].Y, x, y);
                    else
                       appartient = MathUtil.IsInTriangle(lCoordonnees[i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, lCoordonnees[++i].X,lCoordonnees[i].Y, x, y);
                    if (appartient)
                        return appartient;
                    ++i;///On ne repete pas C
                    
                }
                return appartient;

            }

        }
        public List<Coordonnees> lCoord
        {
            get { return lCoordonnees; }
        }
    }
}
