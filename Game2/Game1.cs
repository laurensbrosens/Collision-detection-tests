using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        private Obstacle Box;

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
            Ground = new Obstacle(-10,450,1000,20);
            Box = new Obstacle(300, 40, 100, 300);
            myTexture = Content.Load<Texture2D>("ball");
            myTexture2 = Content.Load<Texture2D>("square2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.R)) //Reset position character
            {
                Player1.Position = new Vector2(250, 10);
                Player1.CollisionRectangle = new Rectangle((int)Math.Round(Player1.Position.X), (int)Math.Round(Player1.Position.Y), 40, 40);
                Player1.PlayerPhysics.VelocityX = 0;
                Player1.PlayerPhysics.VelocityY = 0;
            }
            // TODO: Add your update logic here
            Player1.PositionOld = Player1.CollisionRectangle.Center;
            Player1.Position += Player1.PlayerPhysics.Movement(gameTime,Player1.PlayerState); //Deze en volgende regel moeten nog ergens in een klasse komen
            Player1.CollisionRectangle = new Rectangle((int)Math.Round(Player1.Position.X), (int)Math.Round(Player1.Position.Y), 40, 40);
            Collision.Handler(Player1, Box); //Check collision op alle objecten
            Collision.Handler(Player1, Ground);
            Player1.PlayerState.StateCheck(Player1, Player1.Compensation);
            Player1.Position += Player1.Compensation; //Compenseer Movement() zodat je niet door objecten kan gaan
            Player1.Compensation = new Vector2(0, 0);
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
            _spriteBatch.Draw(myTexture3, Box.CollisionRectangle, Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
