using ProjectWanderer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectWanderer.Model
{
    class Boss : Character
    {

        public Boss(Map map) : base(map, GetCurrentHp(), GetMaxHp(), GetDefPoint(), GetStrikePoint(), GetMonsterLevel())
        {

        }
        public override void GetStriked(Character character)
        {
            int damage = character.StrikeValue - this.defPoint;

            if (character.StrikeValue > this.defPoint)
            {
                this.currentHealthPoint -= damage;
            }
        }
        public static int GetCurrentHp()
        {
            return (2 * GameUtilty.GetStageLevel()) *  (GameUtilty.Rnd6() + GameUtilty.Rnd6());
        }
        public static int GetMaxHp()
        {
            return (2 * GameUtilty.GetStageLevel()) * (GameUtilty.Rnd6() + GameUtilty.Rnd6());
        }
        public static int GetDefPoint()
        {
            return ((GameUtilty.GetStageLevel() / 2) * GameUtilty.Rnd6()) + (GameUtilty.Rnd6() / 2);
        }
        public static int GetStrikePoint()
        {
            return (GameUtilty.GetStageLevel() * GameUtilty.Rnd6()) + GameUtilty.GetStageLevel();
        }
        public static int GetMonsterLevel()
        {
            return GameUtilty.GetStageLevel();
        }

        // Graphics Boss

        public override void SpawnCharacter(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            
            while ('0' != map.content[PosY / 50][PosX / 50] || PosX == 0 && PosY == 0)
            {
                PosY = Monster.rnd.Next(0, 10) * 50;
                PosX = Monster.rnd.Next(0, 10) * 50;
            }
            foxDraw.AddImage("images/images/boss.png", PosX, PosY);
        }
        public override void Move(Canvas canvas, int path)
        {
            FoxDraw foxDraw = new FoxDraw(canvas);

            if (path == 1 && PosY / 50 < 9 && map.content[PosY / 50 + 1][PosX / 50] == '0')
            {
                PosY += 50;
            }
            if (path == 2 && PosX / 50 < 9 && map.content[PosY / 50][PosX / 50 + 1] == '0')
            {
                PosX += 50;
            }
            if (path == 3 && PosY / 50 > 0 && map.content[PosY / 50 - 1][PosX / 50] == '0')
            {
                PosY -= 50;
            }
            if (path == 4 && PosX / 50 > 0 && map.content[PosY / 50][PosX / 50 - 1] == '0')
            {
                PosX -= 50;
            }
            foxDraw.AddImage("images/images/boss.png", PosX, PosY);
        }
        public override Point GetPosition(int x, int y)
        {
            return new Point(x, y);
        }
        public override string GetStatus()
        {
            return "HP " + this.currentHealthPoint + " | " +
                           this.maxHealthPoint + "\n" + "Damage: " +
                           this.strikePoint + "\n" + "Armor: " +
                           this.defPoint;
        }
    }
}
