using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace clone5
{
    
    public enum Stat //состояния игры
    {
        Scene1,
        Scene2,
        Scene3,
    }
    

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        /*
        private SpriteBatch level1_spriteBatch;
        private SpriteBatch level2_spriteBatch;
        private SpriteBatch level3_spriteBatch;
        */
        private SpriteBatch _spriteBatch;
        Texture2D background;
        //static readonly Player player;


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
            /*
            level1_spriteBatch = new SpriteBatch(GraphicsDevice);
            level2_spriteBatch = new SpriteBatch(GraphicsDevice);
            level3_spriteBatch = new SpriteBatch(GraphicsDevice);
            */

            background = Content.Load<Texture2D>("Layer1");
            /*
            switch (Stat)
            {
                case Stat.Scene1:
                    Scene.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);                   
                    break;
                case Stat.Scene2:
                    Level2.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);                   
                    break;
                case Stat.Scene3:
                    Level3.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                    break;
            }
            */

            
            Scene.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level2.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level3.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            /*
            Scene.Init1(level1_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level2.Init1(level2_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level3.Init1(level3_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            */
            Tile.Texture2D = Content.Load<Texture2D>("Tile");
            Player.Texture2D = Content.Load<Texture2D>("frame-1");
            Gem.Texture2D = Content.Load<Texture2D>("Gem");
            Exit1.Texture2D = Content.Load<Texture2D>("Exit");
            Portal.Texture2D = Content.Load<Texture2D>("Black Hole");
            Level3.Finish = Content.Load<Texture2D>("finish");

            Text.Font = Content.Load<SpriteFont>("Score");
            //Level2.Font = Content.Load<SpriteFont>("Score");



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Scene.Update(gameTime);
            Level2.Update(gameTime);
            Level3.Update(gameTime);

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
                case Stat.Scene3:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Level3.Draw();
                    _spriteBatch.End();
                    break;
            }


            base.Draw(gameTime);
        }
    }
}
/*
 * switch (Stat)
            {
                case Stat.Scene1:
                    level1_spriteBatch.Begin();
                    level1_spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Scene.Draw();
                    level1_spriteBatch.End();
                    break;
                case Stat.Scene2:
                    level2_spriteBatch.Begin();
                    level2_spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Level2.Draw();
                    level2_spriteBatch.End();
                    break;
                case Stat.Scene3:
                    level3_spriteBatch.Begin();
                    level3_spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);
                    Level3.Draw();
                    level3_spriteBatch.End();
                    break;
            }
 */