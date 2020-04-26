using Godot;
using System;

public class Cell : Control
{
    private ColorRect _colorRect;

    private bool _isAlive;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _colorRect = GetNode<ColorRect>("ColorRect");
    }


    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {

            if (value)
            {
                _colorRect.Color = Color.ColorN("Black");
            }
            else
            {
                _colorRect.Color = Color.ColorN("White");
            }
            _isAlive = value;
        }
    }

}
