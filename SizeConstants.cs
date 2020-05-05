using Godot;

public class SizeConstants : Godot.Node
{

    public int CellSize { get; set; } = 40;
    public int Width { get; set; } = 80;
    public int Height { get; set; } = 80;
    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        // Width = (int) (root.GetViewport().GetVisibleRect().Size.x) / CellSize;
        // Height = (int) (root.GetViewport().GetVisibleRect().Size.y) / CellSize;
        // GD.Print($"Width: {Width}, Height: {Height}");
    }
}