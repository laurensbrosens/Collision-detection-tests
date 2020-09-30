using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Game2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D myTexture;
        private Texture2D myTexture2;
        private Texture2D myTexture3;
        private Camera Camera1;
        private Hero Player1;
        private Obstacle Ground;
        private Obstacle Box;
        public static int ScreenHeight;
        public static int ScreenWidth;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Camera1 = new Camera();
            Player1 = new Hero();
            Ground = new Obstacle(-10,450,1000,20);
            Box = new Obstacle(300, 350, 100, 100);
            myTexture = Content.Load<Texture2D>("ball");
            myTexture2 = Content.Load<Texture2D>("StickFigure");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.R)) //Reset position character
            {
                Player1.Position = new Vector2(250, 10);
                Player1.CollisionRectangle = new Rectangle((int)Math.Round(Player1.Position.X), (int)Math.Round(Player1.Position.Y), 30, 40);
                Player1.PlayerPhysics.VelocityX = 0;
                Player1.PlayerPhysics.VelocityY = 0;
            }
            // TODO: Add your update logic here
            Player1.PositionOld = Player1.CollisionRectangle.Center;
            Player1.Position += Player1.PlayerPhysics.Movement(gameTime,Player1.PlayerState); //Deze en volgende regel moeten nog ergens in een klasse komen
            Player1.CollisionRectangle = new Rectangle((int)Math.Round(Player1.Position.X), (int)Math.Round(Player1.Position.Y), 30, 40);
            Collision.Handler(Player1, Box); //Check collision op alle objecten
            Collision.Handler(Player1, Ground);
            Player1.PlayerState.StateCheck(Player1, Player1.Compensation);
            Player1.Position += Player1.Compensation; //Compenseer Movement() zodat je niet door objecten kan gaan
            Player1.Compensation = new Vector2(0, 0);

            //Debug.Print($"{Camera1.Position}");
            Camera1.Update(Player1);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: Camera1.Transform);
            _spriteBatch.Draw(myTexture2, Player1.Position, null, Color.White, 0f, new Vector2(0,0), 1.3f, SpriteEffects.None, 0f);
            //_spriteBatch.Draw(myTexture2, new Vector2(Player1.CollisionRectangle.X,Player1.CollisionRectangle.Y), Color.White);
            if (myTexture3 == null)
            {
                myTexture3 = new Texture2D(_graphics.GraphicsDevice, 1, 1);
                myTexture3.SetData(new[] { Color.White });
            }
            _spriteBatch.Draw(myTexture3, Ground.CollisionRectangle, Color.Brown);
            _spriteBatch.Draw(myTexture3, Box.CollisionRectangle, Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
