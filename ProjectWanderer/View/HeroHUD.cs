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
    public class HeroHUD
    {
        public TextBlock playerStatus = new TextBlock();

        public HeroHUD(Canvas canvas,string status)
        {
            playerStatus.Text = status;
            playerStatus.Foreground = Brushes.Teal;
            playerStatus.FontSize = 13;
  
        }
        public void RefreshPlayerStatus(string status)
        {
            playerStatus.Text = status;
        }

    }
}
