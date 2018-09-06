using ProjectWanderer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectWanderer.Model
{
    class CharacterList
    {
        public List<Character> characters;

        public CharacterList()
        {
            characters = new List<Character>();
        }
        public void AddHero(Hero hero)
        {
            characters.Add(hero);
        }
        public void AddMonster(Monster monster)
        {
            characters.Add(monster);
        }
        public void AddBoss(Boss boss)
        {
            characters.Add(boss);
        }
        public void SpawnAllMonster(Canvas canvas)
        {
            foreach (var monster in characters)
            {
                monster.SpawnCharacter(canvas);
            }
        }
        public void SamePos(Canvas canvas, CharacterList charList)
        {
            Random rnd = new Random();

            foreach (var actualChar in characters)
            {
                foreach (var character in charList.GetList())
                {
                    while (actualChar.PosX == character.PosX && actualChar.PosY == character.PosY && actualChar != character)
                    {
                        character.Move(canvas, rnd.Next(1, 5));
                    }
                }

               actualChar.SpawnCharacter(canvas);
            }
        }
        public void MoveMonsters(Canvas canvas, Hero hero)
        {
            Random rnd = new Random();

            if (hero.keyTogglerCounter % 2 == 0)
            {
                foreach (var monster in characters)
                {
                    monster.Move(canvas, rnd.Next(1, 5));
                }
            }
            else
            {
                foreach (var monster in characters)
                {
                    monster.SpawnCharacter(canvas);
                }
            }

        }

        public List<Character> GetList()
        {
            return characters;
        }

        public void RemoveFromList(Character character)
        {
            characters.Remove(character);
        }

        public void Battle(Hero hero)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].GetPosition(characters[i].PosX, characters[i].PosY) ==
                    hero.GetPosition(hero.PosX, hero.PosY))
                {
                    SoundsPlayer.EffectPlayer(Sounds.slamEffect);
                    characters[i].GetStriked(hero);
                    hero.GetStriked(characters[i]);

                    if (characters[i].IsAlive <= 0)
                    {
                        SoundsPlayer.EffectPlayer(Sounds.monsterDeath);
                        hero.LevelUp();
                        characters.Remove(characters[i]);
                    }
                }
            }
        }

    }
}
