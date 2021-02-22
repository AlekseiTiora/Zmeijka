using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeijka
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int xDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= xDown; y++)
            {
                Point p = new Point(x, y, sym,ConsoleColor.White);
                pList.Add(p);
               
            }


        }
    }

}



