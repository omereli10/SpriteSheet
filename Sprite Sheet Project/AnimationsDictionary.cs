using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Sprite_Sheet_Project
{
    static class AnimationsDictionary
    {
        public static Dictionary<Character,Dictionary<State, Page>> animationDictionary = new Dictionary<Character, Dictionary<State, Page>>();
        public static void Init()
        {
            foreach (Character character in Enum.GetValues(typeof(Character)))
            {
                Dictionary<State, Page> characterDictionary = new Dictionary<State, Page>();
                foreach (State state in Enum.GetValues(typeof(State)))
                {
                    string appPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
                    string filePath = appPath + @"Content\bin\Windows\Content\" + character.ToString() + @"\" + state.ToString() + @".xnb";
                    if (File.Exists(filePath))
                    {
                        Page page = new Page(character, state);
                        characterDictionary.Add(state, page);
                    }
                }
                animationDictionary.Add(character, characterDictionary);
            }
        }
    }
}