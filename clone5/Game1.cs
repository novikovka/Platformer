﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace clone5
{    
    public enum Stat //состояния игры
    {
        SplashScreen,
        Scene1,
        Scene2,
        Scene3,
        YouWinner,
        GameOver
    }
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background1;
        Texture2D background2;
        Texture2D background3;
        Texture2D YouWinner;
        Texture2D GameOver;
       
        public static  Stat Stat = Stat.SplashScreen;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            background1 = Content.Load<Texture2D>("Layer0_0");
            background2 = Content.Load<Texture2D>("Layer0_1");
            background3 = Content.Load<Texture2D>("Layer0_2");
            
            
            Scene.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level2.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Level3.Init1(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            Tile.Texture2D = Content.Load<Texture2D>("Tile");
            Player.InRight = Content.Load<Texture2D>("frame-1");
            Player.InLeft = Content.Load<Texture2D>("frame-2");
            Gem.Texture2D = Content.Load<Texture2D>("Gem");
            Exit1.Texture2D = Content.Load<Texture2D>("Exit");
            Portal.Texture2D = Content.Load<Texture2D>("portal");
            Level3.Finish = Content.Load<Texture2D>("finish");
            YouWinner = Content.Load<Texture2D>("вы выиграли");
            GameOver = Content.Load<Texture2D>("вы проиграли 3");
            Text.Font = Content.Load<SpriteFont>("Score");

            SplashScreen.Texture2D = Content.Load<Texture2D>("заставка");
            SplashScreen.GameName = Content.Load<SpriteFont>("GameName");
            SplashScreen.Space = Content.Load<SpriteFont>("Score");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update(gameTime);
                    break;
                case Stat.Scene1:
                    Scene.Update(gameTime);
                    break;
                case Stat.Scene2:
                    Level2.Update(gameTime);
                    break;
                case Stat.Scene3:
                    Level3.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (Stat)
            {
                case Stat.SplashScreen:
                    _spriteBatch.Begin();
                    //_spriteBatch.Draw(background1, new Rectangle(0, 0, 800, 500), Color.White);
                    SplashScreen.Draw();
                    _spriteBatch.End();
                    break;
                case Stat.Scene1:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background1, new Rectangle(0, 0, 800, 500), Color.White);
                    Scene.Draw();
                    _spriteBatch.End();
                    break;
                case Stat.Scene2:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background2, new Rectangle(0, 0, 800, 500), Color.White);
                    Level2.Draw();
                    _spriteBatch.End();
                    break;
                case Stat.Scene3:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(background3, new Rectangle(0, 0, 800, 500), Color.White);
                    Level3.Draw();
                    _spriteBatch.End();
                    break;
                case Stat.YouWinner:
                    _spriteBatch.Begin();           
                    _spriteBatch.Draw(YouWinner, new Rectangle(0, 0, 800, 500), Color.White);
                    _spriteBatch.End();
                    break;
                case Stat.GameOver:
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(GameOver, new Rectangle(0, 0, 800, 500), Color.White);
                    _spriteBatch.End();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
