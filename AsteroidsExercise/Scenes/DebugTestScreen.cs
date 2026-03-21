using IE_Lib.Abstracts;
using Microsoft.Xna.Framework;

namespace AsteroidsExercise.Scenes;

public class DebugTestScreen(Game game): BaseScreen(game)
{
    protected override bool UseDockedLayout => true;

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    protected override void LoadAssets()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnUnload()
    {
        throw new System.NotImplementedException();
    }
}