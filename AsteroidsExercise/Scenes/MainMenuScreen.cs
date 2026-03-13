using System;
using IE_Lib.Abstracts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Scenes;

public class MainMenuScreen : BaseScreen
{
    private Texture2DAtlas _atlas;

    public MainMenuScreen(Game game) : base(game)
    {

    }

    public override void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }

    protected override void LoadAssets()
    {
        
    }
}
