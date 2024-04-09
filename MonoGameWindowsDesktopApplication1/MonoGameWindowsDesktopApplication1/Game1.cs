using Imora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGameWindowsDesktopApplication1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D playerTexture;
    private ObjectManager objectManager = new ObjectManager();
    private float screenWidth;
    private float screenHeight;

    private bool killed = false;

    public float ScreenWidth { get => screenWidth; set => screenWidth = value; }
    public float ScreenHeight { get => screenHeight; set => screenHeight = value; }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        screenWidth = _graphics.PreferredBackBufferWidth;
        screenHeight = _graphics.PreferredBackBufferHeight;
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
        playerTexture = Content.Load<Texture2D>("MuSprite");
        
        //Add objects here
        objectManager.AddEntity(new Character(playerTexture, ScreenWidth/2, 150, 4.0f));

        objectManager.Ready();

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        objectManager.Update(gameTime);
        if (gameTime.TotalGameTime.TotalSeconds >= 12 && !killed)
        {
            GameObject player = objectManager.GetGameObject(0);
            if (player != null)
            {
                player.Destroy();
                killed = true;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin(samplerState : SamplerState.PointClamp);
        objectManager.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}