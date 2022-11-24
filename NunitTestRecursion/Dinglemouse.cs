using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestRecursion
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Dinglemouse
    {
        public static bool AllAlone(char[][] house)
        {
            // Your code here
            Point potus = default;

            for (int i = 0; i < house.GetLength(0); i++)
            {
                for (int j = 0; j < house[i].Length; j++)
                {
                    if (house[i][j] == 'X')
                    {
                        potus = new Point(i, j);
                    }
                }
            }

            // tworzymy pustą listę zeskanowanych punktów
            var scannedPoints = new List<Point>();
            var isNotAllone = Scan(potus, house, scannedPoints);

            return !isNotAllone;
        }

        public static bool Scan(Point point, char[][] house, List<Point> scannedPoints)
        {
            // czy w tej liście znajduje się dany punkt po to żeby się nie zapętlić
            if (scannedPoints.Contains(point))
            {
                return false;
            }

            scannedPoints.Add(point);

            // czy pod daną wartością kryje się elf albo ściana
            if (house[point.X][point.Y] == 'o')
            {
                // prezydent nie jest sam
                return true;
            }

            if (house[point.X][point.Y] == '#')
            {
                return false;
            }

            // jeśli dany punkt nie jest elfem ani ścianą to musimy sprawdzić jego 4-rech sąsiadów
            var pointUp = new Point(point.X, point.Y - 1);
            var pointDown = new Point(point.X, point.Y + 1);
            var pointLeft = new Point(point.X - 1, point.Y);
            var pointRight = new Point(point.X + 1, point.Y);

            // mając 4 punkty wywołujemy rekurencyjnie metodę Scan i jeśli zwróci wartość true to znacyz ze prezydent nie jest sam
            return Scan(pointUp, house, scannedPoints) ||
                   Scan(pointDown, house, scannedPoints) ||
                   Scan(pointLeft, house, scannedPoints) ||
                   Scan(pointRight, house, scannedPoints);
        }
    }

}
