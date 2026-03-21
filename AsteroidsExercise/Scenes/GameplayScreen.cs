using System.Collections.Generic;
using AsteroidsExercise.Entities;
using IE_Lib;
using IE_Lib.Abstracts;
using IE_Lib.interfaces;
using ImGuiNET;
using Microsoft.Xna.Framework;

namespace AsteroidsExercise.Scenes;

public class GameplayScreen : BaseScreen
{
    private readonly List<IGameObject> _gameObjects = new();
    private readonly List<IGameObject> _pendingObjectsAdd = new();

    protected override bool UseDockedLayout => false;

    public GameplayScreen(Game game) : base(game)
    {
        Core.EventBus.Listen<Spawn>(OnShoot);
    }

    protected override void DrawImGui(GameTime gameTime)
    {
        ImGui.Begin("Inspector");
        ImGui.Text("hello");
        ImGui.End();
    }

    protected override void DrawGame(GameTime gameTime)
    {
        Core.SpriteBatch.Begin();
        foreach (var gameObject in _gameObjects) gameObject.Draw(gameTime, Core.SpriteBatch);
        Core.SpriteBatch.End();
    }

    protected override void LoadAssets()
    {
        LoadAtlas("sprites", "Ast_SpritesSheet_atlas");

        var ship = new Ship(GetAtlasRegion("sprites", "ship"), GetAtlasRegion("sprites", "bullet"));
        _gameObjects.Add(ship);
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var gameObject in _gameObjects) gameObject.Update(gameTime);
        _gameObjects.RemoveAll(o => o is Entity { IsExpired: true });

        foreach (var entity in _pendingObjectsAdd) _gameObjects.Add(entity);
        _pendingObjectsAdd.Clear();
    }

    public override void Draw(GameTime gameTime)
    {
        Core.SpriteBatch.Begin();
        foreach (var gameObject in _gameObjects) gameObject.Draw(gameTime, Core.SpriteBatch);
        Core.SpriteBatch.End();

        base.Draw(gameTime);
    }

    private void OnShoot(Spawn eventArgs)
    {
        _pendingObjectsAdd.Add(eventArgs.Entity);
    }

    protected override void OnUnload()
    {
        Core.EventBus.Unlisten<Spawn>(OnShoot);
    }
}
