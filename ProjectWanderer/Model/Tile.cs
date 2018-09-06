using ProjectWanderer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectWanderer.Model
{
    class Tile
    {
        private Canvas canvas;

        public void Floor(int xPos,int yPos)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/floor.png" , xPos, yPos);
        }
        public void Wall(int xPos, int yPos)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/wall.png" , xPos, yPos);
        }
    }
}
