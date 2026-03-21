using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public record Spawn(Entity Entity);

public class Ship : Entity
{
    const float RotationSpeed = 5.25f;
    const float ThrustSpeed = 62.0f;
    const float MaxSpeed = 150.0f;

    private InputManager _input;
    private Texture2DRegion _bulletTextureCache;

    public Ship(Texture2DRegion shipRegion, Texture2DRegion bulletRegion)
    {
        Sprite = new Sprite(shipRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };

        _bulletTextureCache = bulletRegion;
        _input = Core.Input;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        ReadInput(gameTime);
        ApplyVelocity(gameTime);
    }

    private void ReadInput(GameTime gameTime)
    {
        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_input.Keyboard.IsKeyDown(Keys.W) || _input.Keyboard.IsKeyDown(Keys.Up))
        {
            Velocity += Orientation.ToDirection() * ThrustSpeed * delta;
        }

        if (_input.Keyboard.IsKeyDown(Keys.S) || _input.Keyboard.IsKeyDown(Keys.Down))
        {
            Velocity -= Orientation.ToDirection() * ThrustSpeed * delta;
        }
        
        if (_input.Keyboard.IsKeyDown(Keys.A) || _input.Keyboard.IsKeyDown(Keys.Left))
        {
            Orientation -= RotationSpeed * delta;
        }
        
        if (_input.Keyboard.IsKeyDown(Keys.D) || _input.Keyboard.IsKeyDown(Keys.Right))
        {
            Orientation += RotationSpeed * delta;
        }

        if (_input.Keyboard.IsKeyDown(Keys.Space))
        {
            Core.EventBus.Raise(new Spawn(new Bullet(_bulletTextureCache, Position, Orientation.ToDirection())));
        }
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta = gameTime.ElapsedGameTime.TotalSeconds;
        Position.X += (float)(Velocity.X * delta);
        Position.Y += (float)(Velocity.Y * delta);

        Velocity = Velocity.Clamp(MaxSpeed);
    }
}
