﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pulsarc.Gameplay;
using Pulsarc.Skinning;
using Pulsarc.Utils;
using System;
using System.Diagnostics;

namespace Pulsarc
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pulsarc : Game
    {
        static public GraphicsDeviceManager graphics;
        static public SpriteBatch spriteBatch;
        static public GameplayEngine gameplayEngine;


        //temp
        int previousScrollValue;
        Stopwatch fpsWatch;
        static public int frames;

        public Pulsarc()
        {
            graphics = new GraphicsDeviceManager(this);

            // Set the game in fullscreen (according to the user monitor)
            // TODO : Read from config file for user preference
            graphics.PreferredBackBufferHeight =(int) (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 1.2f);
            graphics.PreferredBackBufferWidth = (int) (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1.2f);
            //graphics.IsFullScreen = true;
            graphics.SynchronizeWithVerticalRetrace = false;
            base.IsFixedTimeStep = false;

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
            base.Initialize();

            Skin.LoadSkin("DefaultSkin");

            KeyboardInputManager.StartThread();
            gameplayEngine = new GameplayEngine();

            //////

            fpsWatch = new Stopwatch();
            fpsWatch.Start();
            previousScrollValue = 0;
            frames = 0;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO : Load all menu images etc
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here (Skin)
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !gameplayEngine.isActive())
                gameplayEngine.Init("0 - Noone - Test (Adri)", "Noone - Test [test] (Adri)");

            if (Keyboard.GetState().IsKeyDown(Keys.Delete))
                gameplayEngine.Reset();

            if (Keyboard.GetState().IsKeyDown(Keys.P))
                gameplayEngine.Pause();

            if (Keyboard.GetState().IsKeyDown(Keys.O))
                gameplayEngine.Continue();

            var currentMouseState = Mouse.GetState();

            if (currentMouseState.ScrollWheelValue < previousScrollValue)
            {
                gameplayEngine.deltaTime(-10);
            }
            else if (currentMouseState.ScrollWheelValue > previousScrollValue)
            {
                gameplayEngine.deltaTime(10);
            }
            previousScrollValue = currentMouseState.ScrollWheelValue;

            if (gameplayEngine.isActive())
            {
                gameplayEngine.handleInputs();
                gameplayEngine.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

            if (gameplayEngine.isActive())
            {
                frames++;
                gameplayEngine.Draw();

                if(fpsWatch.ElapsedMilliseconds > 1000)
                {
                    Console.WriteLine(frames + " fps");
                    frames = 0;
                    fpsWatch.Restart();
                }
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }

        static public Vector2 getDimensions()
        {
            return new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
        }
    }
}