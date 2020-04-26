using Godot;
using System;

public class Grid : GridContainer
{
    private PackedScene cell;
    private const int Num_Of_Columns = 10;
    private const int Num_Of_Cells = 100;

    public Cell[,] CellGrid = new Cell[Num_Of_Columns, Num_Of_Columns];

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cell = ResourceLoader.Load("res://Cell.tscn") as PackedScene;

        for (int x = 0; x < CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < CellGrid.GetLength(1); y++)
            {
                var cell = this.cell.Instance() as Cell;
                // add the cell to the grid
                CellGrid[x, y] = cell;
                // add the cell to the GridContainer
                AddChild(cell);
            }
        }

    }
}
