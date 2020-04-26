using Godot;
using System;
using System.Collections.Generic;

public class Main : Node2D
{

    private Grid _grid;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _grid = GetNode<GridContainer>("Grid") as Grid;
    }

    /*
    * Called when a when an epoch passes    
    */
    private void OnEpochEnd()
    {
        // Play God and see which cell survies and which one dies
        VisitCells();
    }

    private void VisitCells()
    {
        var aliveList = new List<Cell>();
        var deadList = new List<Cell>();
        for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)

            {
                try
                {
                    // get the 8 neighboaring cells
                    var n = _grid.CellGrid[x, y - 1];
                    var e = _grid.CellGrid[x + 1, y];
                    var s = _grid.CellGrid[x, y + 1];
                    var w = _grid.CellGrid[x - 1, y];
                    var nw = _grid.CellGrid[x - 1, y - 1];
                    var ne = _grid.CellGrid[x + 1, y - 1];
                    var sw = _grid.CellGrid[x - 1, y + 1];
                    var se = _grid.CellGrid[x + 1, y + 1];

                    GD.Print($"Visiting: {x},{y}");
                }
                catch (Exception _)
                {
                    // Here I am using Try-Catch to avoid having 8 if statements to check for edge cells
                }

            }
        }
    }
}
