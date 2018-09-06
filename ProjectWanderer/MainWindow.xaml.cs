using ProjectWanderer.Model;
using ProjectWanderer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectWanderer
{
    public partial class MainWindow : Window
    {
        Map map = new Map();
        CharacterList characterList = new CharacterList();

        Hero hero;
        Boss boss;
        Monster monster;
        Monster monster2;
        Monster monster3;
        Monster monster4;
        Monster monster5;
        
        HeroHUD playerHud;
        MonsterHUD monsterHud;
        Graphics graphics;

        public MainWindow()
        {
            SoundsPlayer.MusicPlayer(Sounds.music);

            hero = new Hero(map);
            boss = new Boss(map);
            monster = new Monster(map);
            monster2 = new Monster(map);
            monster3 = new Monster(map);
            monster4 = new Monster(map);
            monster5 = new Monster(map);

            playerHud = new HeroHUD(playerHudCanvas, hero.GetStatus());
            monsterHud = new MonsterHUD(monsterHudCanvas, characterList);
            graphics = new Graphics(map,hero);

            characterList.AddBoss(boss);
            characterList.AddMonster(monster5);
            characterList.AddMonster(monster4);
            characterList.AddMonster(monster3);
            characterList.AddMonster(monster2);
            characterList.AddMonster(monster);

            InitializeComponent();

            map.Read();
            map.DrawMap(canvas);

            characterList.SpawnAllMonster(canvas);

            hero.DrawHeroDown(canvas);

            playerHudCanvas.Children.Add(playerHud.playerStatus);
            monsterHudCanvas.Children.Add(monsterHud.monsterStatus);
        }
        public void Move(object sender, KeyEventArgs e)
        {
            canvas.Children.Clear();
            map.DrawMap(canvas);
            playerHud.RefreshPlayerStatus(hero.GetStatus());
            monsterHud.RefreshMonsterStatus(hero.PosY, hero.PosX, characterList);

            if (e.Key == Key.Space)
            {
                hero.keyTogglerCounter = 1;
                hero.DrawHeroDown(canvas);
                characterList.Battle(hero); 
            }
            characterList.MoveMonsters(canvas, hero);
            characterList.SamePos(canvas, characterList);

            if (e.Key == Key.Down)
            {
                hero.Move(canvas, 1);
                hero.StepCounter();
            }
            else if (e.Key == Key.Up)
            {
                hero.Move(canvas, 4);
                hero.StepCounter();
            }
            else if (e.Key == Key.Right)
            {
                hero.Move(canvas, 2);
                hero.StepCounter();
            }
            else if (e.Key == Key.Left)
            {
                hero.Move(canvas, 3);
                hero.StepCounter();
            }

            if (characterList.GetList().Count == 0)
            {
                GameUtilty.ReStartGame(canvas, map, characterList, hero, boss, monster, 
                                       monster2, monster3, monster4, monster5);
            }

            if (hero.IsAlive <= 0)
            {
                SoundsPlayer.EffectPlayer(Sounds.gameOver);
                GameUtilty.GameOver(canvas);               
            }
            
        }
    }
}