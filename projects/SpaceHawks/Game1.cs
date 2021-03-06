﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceHawks
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D spaceship;
        Vector2 shipPosition;
        float shipSpeed;

        Texture2D enemy;
        Vector2 enemyPosition;
        Vector2 enemySpeed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spaceship = Content.Load<Texture2D>("nave");
            shipPosition = new Vector2(300, 400);
            shipSpeed = 200;

            enemy = Content.Load<Texture2D>("enemigo1a");
            enemyPosition = new Vector2(50, 70);
            enemySpeed = new Vector2(150, 50);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back 
                    == ButtonState.Pressed 
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Player movement
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                shipPosition.X -= shipSpeed * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Right))
                shipPosition.X += shipSpeed *
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Enemy movement
            enemyPosition.X += enemySpeed.X *
                (float)gameTime.ElapsedGameTime.TotalSeconds;
            enemyPosition.Y += enemySpeed.Y *
                (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((enemyPosition.X < 20) || (enemyPosition.X > 700))
                enemySpeed.X = -enemySpeed.X;
            if ((enemyPosition.Y < 20) || (enemyPosition.Y > 400))
                enemySpeed.Y = -enemySpeed.Y;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(spaceship,
                new Rectangle(
                    (int) shipPosition.X, (int)shipPosition.Y, 
                    spaceship.Width, spaceship.Height),
                Color.White);
            spriteBatch.Draw(enemy,
                new Rectangle(
                    (int)enemyPosition.X, (int)enemyPosition.Y,
                    enemy.Width, enemy.Height),
                Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
