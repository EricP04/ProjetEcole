using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ProjectLibraryClass;
namespace ProjetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            bool fin = false;
            while (!fin)
            {
                choix = Choix("Classe Coordonnee", "Classe POI", "Classe Polyline", "Classe Polygon", "Interface IIsPointClose",
                    "Interface IPointy", "Liste générique CartoObj", "Liste générique Polyline", "Classer liste d'objet CartObj",
                    "Quitter");
                switch (choix)
                {
                    case 1:
                        {
                            Console.WriteLine("Test de la classe Coordonnee");
                            Coordonnees coord = new Coordonnees();
                            Console.WriteLine("Test du constructeur par défault et de la surcharge ToString()");
                            Console.WriteLine(coord.ToString());
                            double x1 = 2, y1 = 4;
                            Coordonnees coord2 = new Coordonnees(x1, y1);
                            Console.WriteLine("Test du constructeur d'initialisation (et de l'operateur ToString()");
                            Console.WriteLine(coord2.ToString());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Test de la classe POI");
                            POI poi = new POI();
                            Console.WriteLine("Test du constructeur par défault et de la surcharge de l'opérateur ToString()");
                            Console.WriteLine(poi.ToString());
                            double x1 = 25.63987, y1 = 56.2235;
                            string tmp = "Classe de laboratoire";
                            Console.WriteLine("Test du constructeur d'initialisation et de la surcharge de l'opérateur ToString()");
                            POI poi2 = new POI(tmp, x1, y1);
                            Console.WriteLine(poi2.ToString());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Test de la classe Polyline");
                            Polyline poly1 = new Polyline();
                            Console.WriteLine("Test du constructeur par défault et de la surcharge de l'opérateur ToString()");
                            Console.WriteLine(poly1.ToString());
                            Console.WriteLine("Test de la fonction Draw()");
                            poly1.Draw();
                            Color cou = Colors.Cyan;
                            int epaisseur = 5;
                            Coordonnees coord1 = new Coordonnees(2.55, 2.669);
                            Coordonnees coord2 = new Coordonnees(4.569578, 97.59);
                            Coordonnees coord3 = new Coordonnees(588.2243, 6.20135);
                            Coordonnees[] tab = new Coordonnees[3];
                            tab[0] = coord1;
                            tab[1] = coord2;
                            tab[2] = coord3;
                            Polyline poly2 = new Polyline(epaisseur, cou, tab);
                            Console.WriteLine("Test du constructeur d'initialisation et de la surcharge de l'opérateur ToString()");
                            Console.WriteLine(poly2.ToString());
                            Console.WriteLine("Test de la fonction Draw()");
                            poly2.Draw();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Test de la classe Polygon");
                            Polygon poly1 = new Polygon();
                            Console.WriteLine("Test du constructeur par défault et de la surcharge de l'opérateur ToString()");
                            Console.WriteLine(poly1.ToString());
                            Console.WriteLine("Test de la fonction Draw()");
                            poly1.Draw();
                            Color rempl = Colors.Cyan;
                            Color cont = Colors.Orange;
                            double opa = 0.233;
                            Coordonnees coord1 = new Coordonnees(2.55, 2.669);
                            Coordonnees coord2 = new Coordonnees(4.569578, 97.59);
                            Coordonnees coord3 = new Coordonnees(588.2243, 6.20135);
                            Coordonnees[] tab = new Coordonnees[3];
                            tab[0] = coord1;
                            tab[1] = coord2;
                            tab[2] = coord3;
                            Polygon poly2 = new Polygon(tab, rempl, cont, opa);
                            Console.WriteLine("Test du constructeur d'initialisation et de la surcharge de l'opérateur ToString()");
                            Console.WriteLine(poly2.ToString());
                            Console.WriteLine("Test de la fonction Draw()");
                            poly2.Draw();
                            break;
                        }
                    case 5:
                        {
                            ///Test de l'interface IIsPointClose
                            ///Il faut le test avec POI, Polyline et Polygone
                            double precision, x, y;
                            bool isClose;
                            Console.WriteLine("Test de l'interface IIsPointClose");
                            int choix2 = Choix("POI", "Polyline", "Polygon");
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("POI");
                                        POI poi = new POI(2.035, 5.310);
                                        Console.WriteLine(poi.ToString());
                                        Console.WriteLine("Veuillez saisir des coordonnées : ");
                                        Console.WriteLine("X = "); x = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Y = "); y = Convert.ToDouble(Console.ReadLine());
                                        Coordonnees coordPerso = new Coordonnees(x, y);
                                        Console.WriteLine(coordPerso.ToString());
                                        Console.WriteLine("Veuillez saisir le taux de précision : "); precision = Convert.ToDouble(Console.ReadLine());
                                        isClose = poi.IsPointClose(coordPerso.X, coordPerso.Y, precision);
                                        Console.WriteLine("isClose = " + isClose);
                                        break;

                                    }
                                case 2:
                                    {

                                        Console.WriteLine("Polyline");
                                        Coordonnees[] tab = new Coordonnees[3];
                                        tab[0] = new Coordonnees(2.500, 2.500);
                                        tab[1] = new Coordonnees(5.000, 5.000);
                                        tab[2] = new Coordonnees(1.540, 1.540);
                                        Color white = Colors.White;
                                        Polyline poly = new Polyline(5, white, tab);
                                        Console.WriteLine(poly.ToString());
                                        Console.WriteLine("Veuillez saisir des coordonnées : ");
                                        Console.WriteLine("X = "); x = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Y = "); y = Convert.ToDouble(Console.ReadLine());
                                        Coordonnees coordPerso = new Coordonnees(x, y);
                                        Console.WriteLine(coordPerso.ToString());
                                        Console.WriteLine("Veuillez saisir le taux de précision : "); precision = Convert.ToDouble(Console.ReadLine());
                                        isClose = poly.IsPointClose(coordPerso.X, coordPerso.Y, precision);
                                        Console.WriteLine("isClose = " + isClose);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("Polygone");
                                        /*///Triangle Harcodé
                                        Coordonnees[] tab = new Coordonnees[3];
                                        tab[0] = new Coordonnees(1, 1);
                                        tab[1] = new Coordonnees(2, 3);
                                        tab[2] = new Coordonnees(3, 1);*/
                                        /*///Carré négatif hardcodé*/
                                        Coordonnees[] tab = new Coordonnees[4];
                                        tab[0] = new Coordonnees(1, -1);
                                        tab[1] = new Coordonnees(3, -1);
                                        tab[2] = new Coordonnees(3, -3);
                                        tab[3] = new Coordonnees(1, -3);
                                        Color inte = Colors.White;
                                        Color cont = Colors.Red;
                                        Polygon poly = new Polygon(tab, inte, cont, 0.5);
                                        Console.WriteLine(poly.ToString());
                                        Console.WriteLine("Veuillez saisir des coordonnées : ");
                                        Console.WriteLine("X = "); x = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Y = "); y = Convert.ToDouble(Console.ReadLine());
                                        Coordonnees coordPerso = new Coordonnees(x, y);
                                        Console.WriteLine(coordPerso.ToString());
                                        isClose = poly.IsPointClose(coordPerso.X, coordPerso.Y, 0);
                                        Console.WriteLine("isClose = " + isClose);
                                        break;
                                    }
                            }


                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Test de l'interface IIPointy");
                            int choix2 = Choix("Polyline", "Polygon", "Quitter");
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        double x, y;
                                        Console.WriteLine("---Polyline---");
                                        Coordonnees[] tab = new Coordonnees[3];
                                        tab[0] = new Coordonnees(0.5, 2.3597);
                                        tab[1] = new Coordonnees(5.6, 2.3597);
                                        tab[2] = new Coordonnees(3.5, 5);
                                        Color col = Colors.White;
                                        Polyline poly = new Polyline(2, col, tab);
                                        Console.WriteLine(poly);
                                        Console.WriteLine("Nombre de points = " + poly.nbPoint);
                                        Console.WriteLine("Veuillez saisir les coordonnées d'un nouveau points :");
                                        Console.Write("X = "); x = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
                                        Console.Write("Y = "); y = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
                                        poly.AddCoord(new Coordonnees(x, y));
                                        Console.WriteLine(poly);
                                        Console.WriteLine("Nombre de points = " + poly.nbPoint);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("---Polygon---");
                                        Coordonnees[] tab = new Coordonnees[3];
                                        tab[0] = new Coordonnees(0.5, 2.3597);
                                        tab[1] = new Coordonnees(5.6, 2.3597);
                                        tab[2] = new Coordonnees(3.5, 5);
                                        Color col = Colors.White;
                                        Color col2 = Colors.Red;
                                        Polygon poly = new Polygon(tab, col, col2, 0.5);
                                        Console.WriteLine("---Coordonnees---");
                                        Console.WriteLine(poly);
                                        Console.WriteLine("Nombre de points = " + poly.nbPoint);

                                        break;
                                    }
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("---Test de la liste générique CartoObj---");
                            Coordonnees[] cTab = new Coordonnees[4];
                            cTab[0] = new Coordonnees(1, 1);
                            cTab[1] = new Coordonnees(3, 1);
                            cTab[2] = new Coordonnees(3, 3);
                            cTab[3] = new Coordonnees(3, 1);

                            Coordonnees[] cTab2 = new Coordonnees[3];
                            cTab2[0] = new Coordonnees(1, 1);
                            cTab2[1] = new Coordonnees(4, 4);
                            cTab2[2] = new Coordonnees(7, 1);
                            ///J'implémente directement un objet de chaque sorte (hardcodé)
                            List<CartoObj> lCarto = new List<CartoObj>() {new Coordonnees(2.5013,5.6978), new POI("POIDansListeGénérique",
                                5.697236,60.348), new Polygon(cTab,Colors.Red, Colors.Green,0.5),new Polyline(2,Colors.DarkGray,cTab2)};
                            int choix2 = Choix("Afficher la liste complete", "Afficher les objets implémentant IPointy", "Afficher les objets n'implémentant pas IPointy", "Quitter");
                            switch (choix2)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("---Liste complete---");
                                        foreach (CartoObj co in lCarto)
                                        {
                                            Console.WriteLine(co);
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("---Liste des objets implémentant IPointy---");
                                        foreach (CartoObj co in lCarto)
                                        {
                                            if (co is IPointy)
                                                Console.WriteLine(co);
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("---Liste des objets n'implémentant pas IPointy---");
                                        foreach (CartoObj co in lCarto)
                                        {
                                            if (!(co is IPointy))
                                            {
                                                Console.WriteLine(co);
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("---Test de la liste générique Polyline---");
                            List<Polyline> lPoly = new List<Polyline>()
                            {
                                new Polyline(2,Colors.White,new Coordonnees[3]{new Coordonnees(2,3), new Coordonnees(4,5),
                                new Coordonnees(6,7)}),
                                new Polyline(1,Colors.Red,new Coordonnees[3]{new Coordonnees(0,0), new Coordonnees(2,10),
                                new Coordonnees(9,4)}),
                                new Polyline(3,Colors.DarkBlue,new Coordonnees[3]{new Coordonnees(0,5), new Coordonnees(3,10),
                                new Coordonnees(3,5)}),
                                new Polyline(5,Colors.Cyan,new Coordonnees[3]{new Coordonnees(5,1), new Coordonnees(10,5),
                                new Coordonnees(15,8)}),
                                new Polyline(9,Colors.GreenYellow,new Coordonnees[3]{new Coordonnees(10,3), new Coordonnees(7,9),
                                new Coordonnees(5,1)})

                            };
                            Console.WriteLine("---Affichage de la liste générique de polyline---");
                            foreach (Polyline pol in lPoly)
                            {
                                Console.WriteLine(pol);
                            }
                            ///Tri
                            lPoly.Sort();
                            Console.WriteLine("---Affichage de la liste générique de polyline trié sur leur longueur---");
                            foreach (Polyline pol in lPoly)
                            {
                                Console.WriteLine("Longueur : " + pol.LongueurPolyline().ToString());
                                Console.WriteLine(pol);
                            }
                            lPoly.Sort(new MyPolylineBoundingBoxComparer());
                            Console.WriteLine("---Affichage de la liste générique du polyline trié sur leur surface---");
                            foreach (Polyline po1 in lPoly)
                            {
                                Console.WriteLine("Surface : " + po1.CalculSurface()); ///Temporaire, juste pour vérifier la valeur des surfaces 
                                Console.WriteLine(po1);
                            }
                            ConsoleKeyInfo cki;
                            do
                            {
                                Console.WriteLine("Souhaitez-vous tester la fonctionnalité de recherche de polyline ayant la même" +
                                    "surface qu'un polyline de référence (que vous saisirez-vous même) ? [y/n]");
                                cki = Console.ReadKey();
                            } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);
                            if (cki.Key == ConsoleKey.Y)
                            {
                                Console.WriteLine();
                                ///Je ne fais saisir que 3 coordonnées
                                Coordonnees[] lCoordU = new Coordonnees[3];
                                for (int i = 0; i < 3; i++)
                                {
                                    lCoordU[i] = new Coordonnees();
                                    Console.WriteLine("Veuillez saisir la " + (i + 1) + "e coordonnées ");
                                    Console.Write("X = "); lCoordU[i].X = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Y = "); lCoordU[i].Y = Convert.ToDouble(Console.ReadLine());
                                }

                                Polyline polyU = new Polyline(10, Colors.White, lCoordU);
                                List<Polyline> lPolyResult = lPoly.FindAll(polyU.SurfaceSame);
                                if (lPolyResult.Count > 0)
                                {
                                    Console.WriteLine("Polyline possédant la même surface");
                                    foreach (Polyline pol in lPolyResult)
                                    {
                                        Console.WriteLine(polyU.CalculSurface());
                                        Console.WriteLine(pol);
                                    }
                                    Console.WriteLine("Rappel du polyline de référence");
                                    Console.WriteLine(polyU.CalculSurface());
                                    Console.WriteLine(polyU);
                                }
                                else
                                    Console.WriteLine("Aucun polyline dans la liste ne possède la même surface que le polyline de référence");
                            }
                            do
                            {
                                Console.WriteLine("Souhaitez-vous tester la fonctionnalité de recherche de polyline " +
                                    "proche d'un point dont vous passez les paramètres ? [y/n]");
                                cki = Console.ReadKey();
                            } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);
                            if (cki.Key == ConsoleKey.Y)
                            {
                                double prec;
                                ///Saisie des coordonnées par l'utilisateur
                                double x, y;
                                Console.Write("X = "); x = Convert.ToDouble(Console.ReadLine()); Console.WriteLine();
                                Console.Write("Y = "); y = Convert.ToDouble(Console.ReadLine()); Console.WriteLine();
                                Console.Write("Precision = "); prec = Convert.ToDouble(Console.ReadLine()); Console.WriteLine();
                                ///Recherche d'une certaines proximités avec un des polylines composant la liste
                                List<Polyline> lPolyProche = new List<Polyline>();
                                foreach (Polyline pol in lPoly)
                                {
                                    if (pol.IsPointClose(x, y, prec))
                                    {
                                        lPolyProche.Add(pol);
                                    }
                                }
                                if (lPolyProche.Count > 0)
                                {
                                    foreach (Polyline pol in lPolyProche)
                                    {
                                        Console.WriteLine(pol);
                                    }
                                }
                                else
                                    Console.WriteLine("Aucun polyline présent dans la liste n'est proche du point rentrée en paramètre");

                                Console.WriteLine("Rappel des coordonnées : (" + x + "," + y + ")");


                            }


                            break;
                        }
                    case 9:
                        {
                            ///Trier liste d'objet CartObj
                            Console.WriteLine("---Trier une liste d'objet CartObj---");
                            ///Ici les polyline sont un peu hardcodé n'importe comment, je cherche juste a créer plusieurs polyline/polygone 
                            ///ayant un nombre de coordonnées différentes afin de tester le tri via la fonction Compare
                            List<CartoObj> lCarto = new List<CartoObj>()
                            {
                                new Polyline(2,Colors.White,new Coordonnees[4]{new Coordonnees(2,3), new Coordonnees(4,5),
                                new Coordonnees(6,7),new Coordonnees(0,5)}),
                                new Polyline(1,Colors.Red,new Coordonnees[3]{new Coordonnees(0,0), new Coordonnees(2,10),
                                new Coordonnees(9,4)}),
                                new Polyline(3,Colors.DarkBlue,new Coordonnees[6]{new Coordonnees(0,5), new Coordonnees(3,10),
                                new Coordonnees(3,5), new Coordonnees(5,10), new Coordonnees(15,20),new Coordonnees(0,0)}),
                                new Polyline(5,Colors.Cyan,new Coordonnees[3]{new Coordonnees(5,1), new Coordonnees(10,5),
                                new Coordonnees(15,8)}),
                                new Polyline(9,Colors.GreenYellow,new Coordonnees[3]{new Coordonnees(10,3), new Coordonnees(7,9),
                                new Coordonnees(5,1)}),
                                new Polygon(new Coordonnees[5]{new Coordonnees(0,0), new Coordonnees(0, 3), new Coordonnees(3,3),new Coordonnees(2,5),new Coordonnees(3,0)},Colors.Red,Colors.Black,1),
                                new Polygon(new Coordonnees[3]{new Coordonnees(0,0), new Coordonnees(0, 3), new Coordonnees(3,3)},Colors.Red,Colors.Black,1),
                                new Polygon(new Coordonnees[4]{new Coordonnees(0,0), new Coordonnees(0, 3), new Coordonnees(3,3),new Coordonnees(3,0)},Colors.Red,Colors.Black,1),



                            };
                            Console.WriteLine("Affichage de la liste non trié");
                            foreach (CartoObj co in lCarto)
                            {
                                Console.WriteLine(co.ToString());
                            }
                            Console.WriteLine("Trie de la liste CartoObj");
                            lCarto.Sort(new CartoObjComparer());
                            Console.WriteLine("Affichage de la liste trié");
                            foreach (CartoObj co in lCarto)
                            {
                                Console.WriteLine(co.ToString());
                            }

                            break;
                        }
                    default:
                        fin = true;
                        break;
                }
            }


        }

        static int Choix(params string[] pos)
        {
            int choix;
            int i = 1;
            foreach (string c in pos)
            {
                Console.WriteLine(i + ") " + c);
                i++;
            }
            do
            {
                Console.WriteLine("Veuillez saisir votre choix : ");
                choix = Convert.ToInt32(Console.ReadLine());
            } while (choix < 1 && choix >= i);

            return choix;
        }
    }
}
