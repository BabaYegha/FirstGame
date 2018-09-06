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
    class MonsterHUD
    {
        public TextBlock monsterStatus = new TextBlock();

        public MonsterHUD(Canvas canvas, CharacterList monsterList)
        {
            monsterStatus.Text = "";
            monsterStatus.Foreground = Brushes.Red;
            monsterStatus.FontSize = 13;
        }
        public string RefreshMonsterStatus(int y, int x, CharacterList monsterList)
        {
            foreach (var monster in monsterList.GetList())
            {
                if (monster.PosY == y && monster.PosX == x)
                {
                    return monsterStatus.Text = monster.GetStatus();
                }
            }
            return "";
        }
    }
}
