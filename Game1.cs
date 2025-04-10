﻿using GameProgII_2DGame_Julia_C02032025.Components;
using GameProgII_2DGame_Julia_C02032025.Components.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace GameProgII_2DGame_Julia_C02032025
{
    /// <summary>
    /// this fixes "Missing XML comment" warning
    /// </summary>
    public class Game1 : Game
    {
        // ---------- REFERENCES ---------- //
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Game1 instance;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
            IsMouseVisible = true;
            instance = this;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280; _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            Globals.GameInstance = this;

            base.Initialize();
        }

        /// <summary>
        /// Loads content for the game, including textures and initializing game objects.
        /// </summary>
        protected override void LoadContent()
        {
            Globals.Instance.GraphicsDevice = _graphics.GraphicsDevice;
            if (Globals.Instance.GraphicsDevice == null)
            {
                Debug.WriteLine("GAME1: GraphicsDevice is not initialized!");
            }
            else
            {
                Debug.WriteLine("GAME1: GraphicsDevice initialized successfully!");
            }
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.content = Content;

            AddMap();

            AddItems();

            AddPlayer();

            // ***** TURN MANAGER ***** //
            GameObject turnManagerObj = new GameObject();
            TurnManager turnManager = new TurnManager();

            Globals.Instance._turnManager = turnManager;
            turnManagerObj.AddComponent(turnManager);

            Globals.Instance._scene.AddGameObject(turnManagerObj);

            AddLevelManager();

            // ***** HUD ***** //
            GameObject hudObj = new GameObject();
            GameHUD hud = new GameHUD();
            Sprite hudSprite = new Sprite();

            hudObj.AddComponent(hud);
            hudObj.AddComponent(hudSprite);
            hudSprite.LoadSprite("emptyInvTexture");

            Globals.Instance._gameHUD = hud;
            Globals.Instance._scene.AddGameObject(hudObj);

            TurnManager.Instance?.ResetTurns();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float time = Globals.TimeScale;
            if(time == 0)
            {
                Globals.Instance._gameHUD.Update(time);
            }
            Globals.Instance._scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            // Draw all scene objects (including all GameObjects & thier Components)
            Globals.Instance._scene.Draw(Globals.spriteBatch);
            
            Globals.Instance._gameHUD.DrawInventoryHUD(); // draw inventory slots HUD
            Vector2 levelPos = new Vector2(640, 10);
            Globals.Instance._gameHUD.DrawLevelFont(levelPos); // level number
            Vector2 healthPos = new Vector2(640, 700);
            Globals.Instance._gameHUD.DrawHealth(healthPos); // player health

            // Drawing Menus
            Globals.Instance._gameHUD.DrawScreen();
            
            if (Globals.Instance._gameHUD.isWinMenu == true)
            {
                Globals.Instance._gameHUD.DrawWinScreen();
            }
            if (Globals.Instance._turnManager.isGameOver == true)
            {
                Globals.Instance._gameHUD.DrawGameOver();
            }

            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }

        #region adding gameobjects & components
        // ***** PLAYER ***** //
        void AddPlayer()
        {
            GameObject playerObject = new GameObject();
            Player player = new Player();
            Sprite playerSprite = new Sprite();
            HealthSystem playerHealth = new HealthSystem(
            maxHealth: 100,
            type: HealthSystem.EntityType.Player
            );

            playerObject.AddComponent(player);
            playerObject.AddComponent(playerSprite);
            playerObject.AddComponent(playerHealth);
            playerSprite.LoadSprite("player");

            Globals.Instance._player = player;
            Globals.Instance._scene.AddGameObject(playerObject);
        }

        // ***** MAP ***** //
        void AddMap()
        {
            // Create Map GameObject & MapSystem component
            GameObject mapObject = new GameObject();
            MapSystem mapSystem = new MapSystem();
            // Add components to Map GameObject        
            mapObject.AddComponent(mapSystem);
            // Add created GameObject to the scene
            Globals.Instance._scene.AddGameObject(mapObject);
        }
        void AddLevelManager()
        {
            GameObject lvlManagerobj = new GameObject();
            LevelManager levelManager = new LevelManager();

            lvlManagerobj.AddComponent(levelManager);

            Globals.Instance._scene.AddGameObject(lvlManagerobj);
        }
        // ***** ITEMS ***** //
        void AddItems()
        {
            // single item GameObject to handle all item
            GameObject itemsObject = new GameObject();
            Items itemsComponent = new Items();

            // Add the component to the game object
            itemsObject.AddComponent(itemsComponent);

            Globals.Instance._items = itemsComponent;

            // Add the items manager to the scene
            Globals.Instance._scene.AddGameObject(itemsObject);
            // Items component handles spawning items after it starts
            Debug.WriteLine("Game1: Items manager created and added to scene");
        }
        #endregion
    }
}

