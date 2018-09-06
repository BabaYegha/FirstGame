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
    class Hero : Character
    {
        int heroPosX = 0;
        int heroPosY = 0;
 
        public int keyTogglerCounter;

        public Hero(Map map)
          : base(map, 10 + (3 * GameUtilty.Rnd6()), 10 + (3 * GameUtilty.Rnd6()),
                2 * GameUtilty.Rnd6() - 2 , 3 + GameUtilty.Rnd6(), 1)
        {

        }
        public void LevelUp()
        {
            this.maxHealthPoint += GameUtilty.Rnd3();
            this.defPoint += GameUtilty.Rnd3();
            this.strikePoint += GameUtilty.Rnd3();
            this.level++;
        }
        public void EnteringNextArea()
        {
            var rnd = new Random();
            int chance = rnd.Next(1, 100);

            if (chance < 10)
            {
                this.currentHealthPoint = this.maxHealthPoint;
            }
            else if (chance < 50)
            {
                this.currentHealthPoint += this.maxHealthPoint / 3;
            }
            else
            {
                this.currentHealthPoint += ((this.maxHealthPoint / 100) * 10);
            }
        }
        public override void GetStriked(Character character)
        {
            int damage = character.StrikeValue - this.defPoint;

            if (character.StrikeValue > this.defPoint)
            {
                this.currentHealthPoint -= damage;
            }
        }

        /// Graphic of Hero

        public override void Move(Canvas canvas, int path)
        {

            if (path == 1 && heroPosY < 9 && map.MapIsWalkable(heroPosY + 1 ,heroPosX))
            {
                PosY += 50;
                heroPosY++;
                DrawHeroDown(canvas);
            }
            else if (path == 2 && heroPosX < 9 && map.MapIsWalkable(heroPosY, heroPosX + 1))
            {
                PosX += 50;
                heroPosX++;
                DrawHeroRight(canvas);
            }
            else if (path == 3 && heroPosX > 0 && map.MapIsWalkable(heroPosY, heroPosX - 1))
            {
                PosX -= 50;
                heroPosX--;
                DrawHeroLeft(canvas);
            }
            else if (path == 4 && heroPosY > 0 && map.MapIsWalkable(heroPosY - 1,heroPosX))
            {
                PosY -= 50;
                heroPosY--;
                DrawHeroUp(canvas);
            }
            else
            {
                DrawHeroDown(canvas);
            }
        }
        public void DrawHeroDown(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/hero-down.png", PosX, PosY);
        }

        public void DrawHeroRight(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/hero-right.png", PosX, PosY);
        }

        public void DrawHeroLeft(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/hero-Left.png", PosX, PosY);
        }

        public void DrawHeroUp(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/hero-Up.png", PosX, PosY);
        }

        public override Point GetPosition(int x, int y)
        {
            return new Point(x, y);
        }
        public int StepCounter()
        {
            return keyTogglerCounter++;
        }

        public override void SpawnCharacter(Canvas canvas)
        {
            heroPosX = 0;
            heroPosY = 0;
            var foxDraw = new FoxDraw(canvas);
            foxDraw.AddImage("images/images/hero-down.png", PosX, PosY);
        }
        public override string GetStatus()
        {
            return "Stage Level | " + GameUtilty.GetStageLevel() + " | \n" +
                   "Hero Level | " + this.level + " |"+"\n" + 
                   "HP: | " + this.currentHealthPoint + " | " +  this.maxHealthPoint + " | " + "\n" + 
                   "Damage: " + this.strikePoint + "\n" + 
                   "Armor: " + this.defPoint;
            
        }
    }
}
