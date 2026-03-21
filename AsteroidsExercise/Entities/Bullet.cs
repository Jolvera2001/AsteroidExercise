using System;
using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.Utils;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public class Bullet : Entity
{
    const float Speed = 250.0f;

    public Bullet(Texture2DRegion bulletRegion, Vector2 startPosition, Vector2 direction)
    {
        Sprite = new Sprite(bulletRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };

        Position = startPosition;
        Velocity = direction * Speed;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        ApplyVelocity(gameTime);
        CheckBounds();
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta = gameTime.ElapsedGameTime.TotalSeconds;
        Position.X += (float)(Velocity.X * delta);
        Position.Y += (float)(Velocity.Y * delta); 
    }

    private void CheckBounds()
    {
        if (!Position.IsInBounds(Core.Instance.Window.ClientBounds.Width, Core.Instance.Window.ClientBounds.Width))
        {
            IsExpired = true;
            Console.WriteLine("Disappeared!");
        }
    }
}