﻿#region Using
using GameProgII_2DGAME_JuliaC02032025.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameProgII_2DGAME_JuliaC02032025.Components.Enemies;

#endregion

/// <summary>
/// Manages the game state, including handling the scene and game objects.
/// </summary>
internal class Globals
{
    public static Globals _instance {  get; private set; }
    public static Globals Instance => _instance ??= new Globals();

    public static ContentManager content;
    public static SpriteBatch spriteBatch;

    public MapSystem _mapSystem { get;  set; }
    public Component _component;
    public HealthSystem _healthSystem;
    public Player _player;
    public Sprite _sprite;
    public GameObject _gameObject;
    public TileMap _tileMap;
    public Enemy _enemy;

    public Scene _scene;
    public Globals()
    {
        _instance = this;
        _scene = new Scene();
        _gameObject = new GameObject();
    }   
}