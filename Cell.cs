using Godot;
using System;

public class Cell : Control
{
    private ColorRect _colorRect;

    private bool _isAlive;
    private SizeConstants _sizeConstants = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _sizeConstants = GetNode<SizeConstants>("/root/SizeConstants");
        _colorRect = GetNode<ColorRect>("ColorRect");
        // set teh size of the cell to the one defined in the constants file
        _colorRect.SetSize(new Vector2(_sizeConstants.CellSize, _sizeConstants.CellSize));
    }

    public int X { get; set; }
    public int Y { get; set; }
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
