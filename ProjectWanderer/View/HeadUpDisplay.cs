using ProjectWanderer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectWanderer.View
{
    public class HeadUpDisplay
    {
        public TextBlock playerStatus = new TextBlock();
        public TextBlock monsterStatus = new TextBlock();
        private Canvas canvas;

        public HeadUpDisplay(Canvas canvas,string status)
        {
            playerStatus.Text = status;

            playerStatus.Foreground = Brushes.Teal;
            playerStatus.FontSize = 13;

            monsterStatus.Text = status;
            monsterStatus.Foreground = Brushes.Red;
            monsterStatus.FontSize = 13;
            
        }
        public void RefreshPlayerStatus(string status)
        {
            playerStatus.Text = status;
        }
        public void RefreshMonsterStatus(string status)
        {
            monsterStatus.Text = status;
        }
        public void GameOver()
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/game-over.jpg", 0, 0);
        }
    }
}
