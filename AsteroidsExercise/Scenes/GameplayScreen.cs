using System;
using System.Collections.Generic;
using System.ComponentModel;
using AsteroidsExercise.Entities;
using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.interfaces;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;

namespace AsteroidsExercise.Scenes;

public class GameplayScreen : BaseScreen
{
    private readonly List<IGameObject> _gameObjects = new();

    public GameplayScreen(Game game) : base(game) { }

    protected override void LoadAssets()
    {
        LoadAtlas("sprites", "Ast_SpritesSheet_atlas");

        var ship = new Ship(GetAtlasRegion("sprites", "ship"));
        _gameObjects.Add(ship);
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var gameObject in _gameObjects) gameObject.Update(gameTime);
        _gameObjects.RemoveAll(o => o is Entity entity && entity.IsExpired);
    }

    public override void Draw(GameTime gameTime)
    {
        Core.SpriteBatch.Begin();
        foreach (var gameObject in _gameObjects) gameObject.Draw(gameTime, Core.SpriteBatch);
        Core.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
