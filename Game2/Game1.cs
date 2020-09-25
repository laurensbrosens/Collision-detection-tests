﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D myTexture;
        private Texture2D myTexture2;
        private Texture2D myTexture3;
        private Hero Player1;
        private Obstacle Ground;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Player1 = new Hero();
            Ground = new Obstacle();
            myTexture = Content.Load<Texture2D>("ball");
            myTexture2 = Content.Load<Texture2D>("square2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player1.Movement();
            if (Collision.Check())
            {
                Collision.Fix();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(myTexture, Player1.Position, Color.Aqua);
            _spriteBatch.Draw(myTexture2, new Vector2(Player1.CollisionRectangle.X,Player1.CollisionRectangle.Y), Color.White);
            if (myTexture3 == null)
            {
                myTexture3 = new Texture2D(_graphics.GraphicsDevice, 1, 1);
                myTexture3.SetData(new[] { Color.White });
            }
            _spriteBatch.Draw(myTexture3, Ground.CollisionRectangle, Color.Brown);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}