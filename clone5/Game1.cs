using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace clone5
{
    
    public enum Stat //состояния игры
    {
        Scene1,
        Scene2,
    }
    

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        

        public static  Stat Stat = Stat.Scene1;

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

            
            Scene.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level2.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            

            Tile.Texture2D = Content.Load<Texture2D>("Tile");
            Player.Texture2D = Content.Load<Texture2D>("frame-1");
            Gem.Texture2D = Content.Load<Texture2D>("Gem");
            Scene.Exit = Content.Load<Texture2D>("Exit");
            Portal.Texture2D = Content.Load<Texture2D>("Black Hole");

            Text.Font = Content.Load<SpriteFont>("Score");
            //Level2.Font = Content.Load<SpriteFont>("Score");



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Scene.Update(gameTime);
            Level2.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (Stat)
            {
                case Stat.Scene1:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Scene.Draw();
                    _spriteBatch.End();
                    break;
                case Stat.Scene2:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Level2.Draw();
                    _spriteBatch.End();
                    break;
            }


            base.Draw(gameTime);
        }
    }
}