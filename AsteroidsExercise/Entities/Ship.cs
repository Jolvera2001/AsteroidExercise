using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public class Ship : Entity
{
    const float ROTATION_SPEED = 5.25f;
    const float THRUST_SPEED = 62.0f;
    const float MAX_SPEED = 150.0f;

    private InputManager _input;

    public Ship(Texture2DRegion shipRegion)
    {
        Sprite = new Sprite(shipRegion)
        {
            OriginNormalized = new Vector2(0.5f, 0.5f)
        };

        _input = Core.Input;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        ReadInput(gameTime);
        ApplyVelocity(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }

    private void ReadInput(GameTime gameTime)
    {
        var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_input.Keyboard.IsKeyDown(Keys.W) || _input.Keyboard.IsKeyDown(Keys.Up))
        {
            Velocity += Orientation.ToDirection() * THRUST_SPEED * delta;
        }

        if (_input.Keyboard.IsKeyDown(Keys.S) || _input.Keyboard.IsKeyDown(Keys.Down))
        {
            Velocity -= Orientation.ToDirection() * THRUST_SPEED * delta;
        }
        
        if (_input.Keyboard.IsKeyDown(Keys.A) || _input.Keyboard.IsKeyDown(Keys.Left))
        {
            Orientation -= ROTATION_SPEED * delta;
        }
        
        if (_input.Keyboard.IsKeyDown(Keys.D) || _input.Keyboard.IsKeyDown(Keys.Right))
        {
            Orientation += ROTATION_SPEED * delta;
        }

        if (_input.Keyboard.IsKeyDown(Keys.Space))
        {
            Core.EventBus.Raise(new ShipShoot(Position, Orientation.ToDirection()));
        }
    }

    private void ApplyVelocity(GameTime gameTime)
    {
        var delta = gameTime.ElapsedGameTime.TotalSeconds;
        Position.X += (float)(Velocity.X * delta);
        Position.Y += (float)(Velocity.Y * delta);

        Velocity = Velocity.Clamp(MAX_SPEED);
    }
}

public record ShipShoot(Vector2 position, Vector2 direction);