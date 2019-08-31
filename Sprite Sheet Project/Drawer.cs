using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    class Drawer
    {
        #region Data
        public Texture2D Texture { get; set; }
        protected Vector2 position;
        public Rectangle? sourceRectangle { get; set; }
        Color color;
        float rotation;
        public Vector2 origin { get; set; }
        Vector2 scale;
        public SpriteEffects effects { get; set; }
        float layerDepth;
        #endregion Data

        #region Constractors
        public Drawer(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.Texture = texture;
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layerDepth = layerDepth;
        }
        public Drawer(Vector2 position, Color color, Vector2 scale, float rotation = 0, SpriteEffects effects=SpriteEffects.None, float layerDepth=0)
        {
            this.position = position;
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.effects = effects;
            this.layerDepth = layerDepth;
        }
        #endregion Constractors

        #region Methods
        public void Draw()
        {
            Globals.sb.Draw(Texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }
        #endregion Methods
    }
}