using ProjectWanderer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectWanderer.View
{
    public class Map : Window
    {
        static Random rnd = new Random();
        public string[] content;
        public List<string> mapList = new List<string>
        {
              @"./maps/Map1.txt",
              @"./maps/Map2.txt",
              @"./maps/Map3.txt",
              @"./maps/Map4.txt",
              @"./maps/Map5.txt",
              @"./maps/Map6.txt"
        };
        
        public void Read()
        {        
            content = File.ReadAllLines(mapList[rnd.Next(0,mapList.Count)]);
        }

        public void DrawMap(Canvas canvas)
        {           
            var tile = new Tile();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (content[i][j] == '0')
                    {
                        tile.Floor(canvas);
                    }
                    else
                    {
                        tile.Wall(canvas);
                    }
                    tile.PosX += 50;
                }
                tile.PosX -= 500;
                tile.PosY += 50;
            }
        }

        public bool MapIsWalkable(int Y,int X)
        {
            return content[Y][X] == '0';
        }
    }
}
