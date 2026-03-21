using System;
using IE_Lib;
using IE_Lib.Abstracts;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public record OnDestroy(int Points);

public class Asteroid : Entity
{
    const float BaseRotation = 25.0f;
    private const float BaseSpeed = 15.0f;

    private AsteroidSize _size;
    private float _rotationSpeed;
    private int _health;
    private int _points;

    public Asteroid(Texture2DRegion asteroidRegion, Vector2 position, AsteroidSize size)
    {
        Sprite = new Sprite(asteroidRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };
        Position = position;
        _size = size;
        (_health, _points) = SetStats();

        SetRandomSpeed();
        SetRandomRotation();
    }

    public override void Update(GameTime gameTime)
    {
        ApplyVelocity(gameTime);

        // TODO: can add something like a particle effect when destroyed
        if (_health <= 0)
        {
            Core.EventBus.Raise(new OnDestroy(_points));
            // TODO: Simplify the spawning for an asteroid after it's destroyed 
            IsExpired = true;
        }
    }

    private void SetRandomSpeed()
    {
        Velocity = new Vector2(Random.Shared.NextSingle() * BaseSpeed, Random.Shared.NextSingle() * BaseSpeed);
    }

    private void SetRandomRotation()
    {
        _rotationSpeed = Random.Shared.NextSingle() * BaseRotation;
    }

    private (int, int) SetStats()
    {
        return _size switch
        {
            AsteroidSize.Small => (1, 25),
            AsteroidSize.Medium => (2, 75),
            AsteroidSize.Large => (3, 150),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta = gameTime.ElapsedGameTime.TotalSeconds;
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