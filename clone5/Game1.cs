using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace clone5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           
            _graphics.PreferredBackBufferWidth = 1024; 
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.IsFullScreen = true; 
           // _graphics.ApplyChanges(); //вот это что то новенькое

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Layer1");
            Scene.Init(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Tile.Texture2D = Content.Load<Texture2D>("Tile");
            Player.Texture2D = Content.Load<Texture2D>("frame-1");
            Gem.Texture2D = Content.Load<Texture2D>("Gem");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
          
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
            Scene.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}