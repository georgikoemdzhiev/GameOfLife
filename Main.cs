using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Main : Node2D
{
    private const int Height = 10;
    private const int Width = 10;
    // here we skip "0" as this is the current cell
    private List<int> neighboars = Enumerable.Range(-1, 2).Where(i => i != 0).ToList();
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
        for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)

            {
                try
                {
                    var cell = _grid.CellGrid[x, y];
                    // get the 8 neighboaring cells
                    var livingNeighboars = GetLivingNeighboars(cell);

                    GD.Print($"Visiting: {cell.X},{cell.Y}, it has {livingNeighboars} neighboars");
                }
                catch (Exception exception)
                {
                    GD.Print(exception.Message);
                    // Here I am using Try-Catch to avoid having 8 if statements to check for edge cells
                }

            }

        }
    }

    private int GetLivingNeighboars(Cell c)
    {
        var livingNeighboars = 0;
        foreach (var i in neighboars)
        {
            foreach (var j in neighboars)
            {
                var x = c.X + i;
                var y = c.Y + j;

                if (this._grid.CellGrid[x, y].IsAlive && x >= 0 && x <= Width - 1 && y >= 0 && y <= Height - 1)
                {
                    livingNeighboars++;
                }

            }
        }

        return livingNeighboars;
    }
}
