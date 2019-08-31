using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    enum Character { Saiyan, Ralick, Camila, Android17, Android18 }
    enum State { Stand, Walk, Punch, Kick, Power, Power_Attack, Fade }
    static class Globals
    {
        public static ContentManager cm;
        public static SpriteBatch sb;
        public static KeyboardState keyboard;
        public static void Init(ContentManager cm, SpriteBatch sb)
        {
            Globals.cm = cm;
            Globals.sb = sb;
        }

        public static void Update()
        {
            keyboard = Keyboard.GetState();
        }
    }
}