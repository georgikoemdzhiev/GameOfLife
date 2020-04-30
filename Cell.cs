using Godot;
using System;

public class Cell : Control
{
    private ColorRect _colorRect;
    private Label _label;

    private bool _isAlive;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _colorRect = GetNode<ColorRect>("ColorRect");
        _label = GetNode<Label>("Label");
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

    public void SetLabelText(string str)
    {
        _label.Text = str;
    }

}
