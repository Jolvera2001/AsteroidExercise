using AsteroidsExercise.Scenes;
using IE_Lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.ImGuiNet;

namespace AsteroidsExercise;

public class Asteroids : Core
{
    public Asteroids() : base("Asteroids", 1280, 900, false)
    {

    }

    protected override void Initialize()
    {
        base.Initialize();
        s_screenManager.ShowScreen(new GameplayScreen(this));

#if DEBUG
        ImGuiRenderer = new ImGuiRenderer(this);
        ImGuiRenderer.RebuildFontAtlas();
#endif
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load game content here
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }
}
