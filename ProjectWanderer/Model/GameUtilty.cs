using ProjectWanderer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectWanderer.Model
{
    class GameUtilty
    {
        static int stageLevel = 1;

        static public int Rnd6()
        {
            var rnd = new Random(); 
            return rnd.Next(1, 7);
        }
        static public int Rnd10()
        {
            var rnd = new Random();
            return rnd.Next(1, 11);
        }
        static public int Rnd3()
        {
            var rnd = new Random();
            return rnd.Next(1, 4);
        }
        static public void StageLevelIncrease()
        {
            stageLevel++;
        }
        static public int GetStageLevel()
        {
            return stageLevel;
        }
        static public int RndPosSpawnMonster()
        {
            var rnd = new Random();
            return  rnd.Next(0,10);
        }
        public static void ReStartGame(Canvas canvas,Map map, CharacterList characterList, Hero hero,
                              Boss boss, Monster monster, Monster monster2, Monster monster3,
                              Monster monster4, Monster monster5)
        {
            map.Read();
            map.DrawMap(canvas);

            StageLevelIncrease();
            hero.EnteringNextArea();

            boss = new Boss(map);
            monster = new Monster(map);
            monster2 = new Monster(map);
            monster3 = new Monster(map);
            monster4 = new Monster(map);
            monster5 = new Monster(map);

            characterList.AddBoss(boss);
            characterList.AddMonster(monster);
            characterList.AddMonster(monster2);
            characterList.AddMonster(monster3);
            characterList.AddMonster(monster4);
            characterList.AddMonster(monster5);
            
            characterList.SpawnAllMonster(canvas);

            hero.PosX = 0;
            hero.PosY = 0;
            hero.SpawnCharacter(canvas);
        }
        public static void GameOver(Canvas canvas)
        {
            TextBlock gameOver = new TextBlock();
            var foxDraw = new FoxDraw(canvas);

            gameOver.Text = "GAME OVER";
            gameOver.FontSize = 40;
            gameOver.Foreground = Brushes.Red;

            canvas.Children.Clear();
            canvas.Children.Add(gameOver);
            
        }
       
    }
}
