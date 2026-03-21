using System;
using IE_Lib.Abstracts;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public class Asteroid : Entity
{
    const float BaseRotation = 25.0f;
    private const float BaseSpeed = 15.0f;

    private AsteroidSize _size;
    private float _rotationSpeed;

    public Asteroid(Texture2DRegion asteroidRegion, Vector2 position, AsteroidSize size)
    {
        Sprite = new Sprite(asteroidRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };
        Position = position;
        _size = size;

        SetRandomSpeed();
        SetRandomRotation();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    private void SetRandomSpeed()
    {
        Velocity = new Vector2(Random.Shared.NextSingle() * BaseSpeed, Random.Shared.NextSingle() * BaseSpeed);
    }

    private void SetRandomRotation()
    {
        _rotationSpeed = Random.Shared.NextSingle() * BaseRotation;
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta= gameTime.ElapsedGameTime.TotalSeconds;
        Position.X += (float)(Velocity.X * delta);
        Position.Y += (float)(Velocity.Y * delta);
    }
}

public enum AsteroidSize
{
    Small,
    Medium,
    Large
}