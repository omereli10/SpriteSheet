using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    public class Game1 : Game
    {
        GameObject sayian, ralick, camila, android17, android18;
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.Init(Content, spriteBatch);
            AnimationsDictionary.Init();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sayian = new GameObject(Character.Saiyan, State.Stand, new Vector2(100), Color.White, new Vector2(2f), new UserKeyboard(Keys.D, Keys.A, Keys.W, Keys.S, Keys.LeftShift, Keys.F, Keys.G, Keys.E, Keys.None, Keys.R));
            android18 = new GameObject(Character.Android18, State.Stand, new Vector2(500), Color.White, new Vector2(2f), new UserKeyboard(Keys.Right, Keys.Left, Keys.Up, Keys.Down, Keys.RightShift, Keys.N, Keys.M, Keys.OemComma, Keys.OemPeriod, Keys.OemQuestion));
            android17 = new GameObject(Character.Android17, State.Stand, new Vector2(300), Color.White, new Vector2(2f), new BotKeyboard());
            ralick = new GameObject(Character.Ralick, State.Stand, new Vector2(300), Color.White, new Vector2(2f), new BotKeyboard());
            camila = new GameObject(Character.Camila, State.Stand, new Vector2(200), Color.White, new Vector2(2f), new BotKeyboard());
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.Update(); // Update keyboard press state
            sayian.Update();
            android18.Update();
            android17.moveAfterUser(android18);
            ralick.moveAfterUser(sayian);
            camila.moveAfterUser(ralick);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            sayian.Animate();
            android17.Animate();
            android18.Animate();
            ralick.Animate();
            camila.Animate();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}