using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public class Bullet : Entity
{
    const float SPEED = 175.0f;

    public Bullet(Texture2DRegion bulletRegion, Vector2 startPosition, Vector2 direction)
    {
        Sprite = new Sprite(bulletRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };

        Position = startPosition;
        Velocity = direction * SPEED;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        ApplyVelocity(gameTime);
        CheckBounds();
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta = gameTime.ElapsedGameTime.Seconds;
        Position.X += Velocity.X * delta;
        Position.Y += Velocity.Y * delta; 
    }

    private void CheckBounds()
    {
        if (!Position.IsInBounds(Core.Instance.Window.ClientBounds.Width, Core.Instance.Window.ClientBounds.Width))
        {
            IsExpired = true;
        }
    }
}