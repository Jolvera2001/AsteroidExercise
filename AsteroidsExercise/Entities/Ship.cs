using System;
using IE_Lib.Abstracts;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Entities;

public class Ship: Entity
{
    public Ship(Texture2DRegion shipRegion)
    {
        Sprite = new Sprite(shipRegion);
    }
}
