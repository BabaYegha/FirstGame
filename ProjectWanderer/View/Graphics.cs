using ProjectWanderer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectWanderer.View
{
    class Graphics
    {
        Map map;
        Hero hero;

        static string[] playerDown = new string[]
        {
            "images/AnimationImages/HeroDown1.png",
            "images/AnimationImages/HeroDown2.png",
            "images/AnimationImages/HeroDown3.png"
        };
        public Graphics(Map map, Hero hero)
        {
            this.hero = hero;
            this.map = map;

        }


        public async void AnimateHero(Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);
            int timeBetweenFrames = 250;

            await Task.Delay(timeBetweenFrames);
            foxDraw.AddImage(playerDown[0], hero.PosX, hero.PosY);

            await Task.Delay(timeBetweenFrames);
            foxDraw.AddImage(playerDown[1], hero.PosX, hero.PosY);

            await Task.Delay(timeBetweenFrames);
            foxDraw.AddImage(playerDown[2], hero.PosX, hero.PosY);

            AnimateHero(canvas);
        }
    }
}
