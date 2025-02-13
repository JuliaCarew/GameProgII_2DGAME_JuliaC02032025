﻿using GameProgII_2DGAME_JuliaC02032025.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

internal class Component // Abstract
{
    GameManager _gameManager;

    // ---------- VARIABLES ---------- //   
    public Texture2D texture;
    public Vector2 position;

    /*
    public Component(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
    }
    */

    // ---------- METHODS ---------- //
    // OnStart() - branch off GameObject AddComponent()
    public virtual void AddComponent(Component component)
    {
        //_player = new Player();
        _gameManager._gameObject._components.Add(component);
        Console.Write($"Added new Player to {_gameManager._gameObject._components}"); // another way to display debug for MonoGame?
        // add this to the list of Components (GObj has the list)
    }

    public virtual void Update(float deltaTime) { }    
    public virtual void Draw(SpriteBatch spriteBatch) { }
   
    public void OnDestroy()
    {
        // remove is from the list that GameObject has
    }
    
    public void Initialize()
    {
        // add to list of components in GameObject
    }
}
