using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Créer une interface IIsPointClose implémentée par tous les objets
cartographiques. Cette interface contient une méthode IsPointClose
permettant de déterminer si un point dont les coordonnées (type
double) passées en paramètre est proche (précision en paramètre) ou
non de l’objet cartographique. Dans le cas du point d’intérêt, révisez
Pythagore ☺. Dans le cas de la ligne, nous considérerons qu’un point
se trouve proche de la ligne si elle est proche d’un de ses points ou si la
distance qui sépare le point d’un des segments de celle-ci est inférieure
la précision (voir paramètre ci-dessus). Dans le cas d’un Polygone, on
utilise le point doit se trouver à l’intérieur de la bounding box (voir
§2.3.2)englobant le polygone. L’objectif de cette interface est de
pouvoir sélectionner un objet cartographique par clic sur une carte.
TESTER tous les cas possibles*/
namespace ProjectEcole1
{
    interface IIsPointClose
    {
        bool IsPointClose(double x, double y, double precision);
    }
    interface IPointy
    {
        int nbPoint
        {
            get;
        }
        
    }
}
