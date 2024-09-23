using System;

namespace GamePublic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

public class FNAGame : Game
{
    private KeyboardState keyboardPrev = new KeyboardState();
    private MouseState mousePrev = new MouseState();
    private GamePadState gpPrev = new GamePadState();
    private SpriteBatch? batch;
    private Texture2D? texture;

    public FNAGame()
    {
        GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

        // Typically you would load a config here...
        gdm.PreferredBackBufferWidth = 1280;
        gdm.PreferredBackBufferHeight = 720;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;

        // All content loaded will be in a "Content" folder
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        /* This is a nice place to start up the engine, after
         * loading configuration stuff in the constructor
         */
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load textures, sounds, and so on in here...
        // Create the batch...
        batch = new SpriteBatch(GraphicsDevice);

        // ... then load a texture from ./Content/FNATexture.png
        texture = Content.Load<Texture2D>("FNATexture");

        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        // Clean up after yourself!
        batch.Dispose();
        texture.Dispose();

        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        // Run game logic in here. Do NOT render anything here!
        // Poll input
        KeyboardState keyboardCur = Keyboard.GetState();
        MouseState mouseCur = Mouse.GetState();
        GamePadState gpCur = GamePad.GetState(PlayerIndex.One);

        // Check for presses
        if (keyboardCur.IsKeyDown(Keys.Space) && keyboardPrev.IsKeyUp(Keys.Space))
        {
            System.Console.WriteLine("Space bar was pressed!");
        }
        if (mouseCur.RightButton == ButtonState.Released && mousePrev.RightButton == ButtonState.Pressed)
        {
            System.Console.WriteLine("Right mouse button was released!");
        }
        if (gpCur.Buttons.A == ButtonState.Pressed && gpPrev.Buttons.A == ButtonState.Pressed)
        {
            System.Console.WriteLine("A button is being held!");
        }

        // Current is now previous!
        keyboardPrev = keyboardCur;
        mousePrev = mouseCur;
        gpPrev = gpCur;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Draw the texture to the corner of the screen
        batch.Begin();
        batch.Draw(texture, Vector2.Zero, Color.White);
        batch.End();
        
        base.Draw(gameTime);
    }
}
