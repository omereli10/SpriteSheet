using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    class Animation : Drawer
    {
        #region Data
        public Character character { get; private set; }
        public State state { get; set; }
        public readonly int default_animation_speed = 8;
        public int animation_speed;
        Page page;
        int frame = 0, paste = 0;
        #endregion Data

        #region Constractors
        public Animation(Character character, State state, Vector2 position, Color color, Vector2 scale, float rotation = 0f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
                         : base(position, color, scale, rotation, effects, layerDepth)
        {
            this.character = character;
            this.state = state;
            animation_speed = default_animation_speed;
        }
        #endregion Constractors

        #region Methods
        public void Animate()
        {
            // If the state of the character have changed, change the page and restart the frames
            if (page != AnimationsDictionary.animationDictionary[this.character][this.state])
            {
                frame = 0;
                page = AnimationsDictionary.animationDictionary[this.character][this.state];
            }
            // Animate the character
            this.sourceRectangle = page.recs[frame];
            this.origin = page.origins[frame];
            this.Texture = page.Tex;
            paste++;
            if (paste % animation_speed == 0)
            {
                frame++;
                frame %= page.origins.Count;
            }
            base.Draw();
        }
        #endregion Methods
    }
}