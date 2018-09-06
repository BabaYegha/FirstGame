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
    abstract class Character
    {
        public int PosX = 0;
        public int PosY = 0;

        protected Map map;

        protected int currentHealthPoint;
        protected int maxHealthPoint;
        protected int defPoint;
        protected int strikePoint;
        protected int level;
        public int IsAlive { get { return currentHealthPoint; } }

        public int StrikeValue { get => 2 * GameUtilty.Rnd6() + strikePoint; }

        protected Character(Map map, int currentHealthPoint, int maxHealthPoint, int defPoint, int strikePoint, int level)
        {
            this.currentHealthPoint = currentHealthPoint;
            this.maxHealthPoint = maxHealthPoint;
            this.defPoint = defPoint;
            this.strikePoint = strikePoint;
            this.level = level;
            this.map = map;
        }
        public abstract void GetStriked(Character character);
        public abstract Point GetPosition(int x, int y);
        public abstract string GetStatus();
        public abstract void SpawnCharacter(Canvas canvas);
        public abstract void Move(Canvas canvas, int path);
    }
}
