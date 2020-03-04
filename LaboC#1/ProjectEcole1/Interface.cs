using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibraryClass
{
    public interface IIsPointClose
    {
        bool IsPointClose(double x, double y, double precision);
    }
    public interface IPointy
    {
        int nbPoint
        {
            get;
        }
        
    }
}
