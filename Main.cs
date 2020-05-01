using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Main : Node2D
{
    private const int Height = 10;
    private const int Width = 10;
    private List<int> neighboars = new List<int>() { -1, 0, 1 };
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
        RandomiseGrid();
        // Play God and see which cell survies and which one dies
        VisitCells();
    }

    private void RandomiseGrid()
    {
        // TODO implement good random algorithm
        _grid.CellGrid[2, 5].IsAlive = true;
        _grid.CellGrid[2, 6].IsAlive = true;
        _grid.CellGrid[2, 7].IsAlive = true;
        _grid.CellGrid[3, 6].IsAlive = true;
        _grid.CellGrid[3, 7].IsAlive = true;
        _grid.CellGrid[3, 8].IsAlive = true;
        _grid.CellGrid[3, 9].IsAlive = true;
        _grid.CellGrid[3, 1].IsAlive = true;
        _grid.CellGrid[3, 2].IsAlive = true;
        _grid.CellGrid[3, 3].IsAlive = true;
    }

    private void VisitCells()
    {
        for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)

            {
                var cell = _grid.CellGrid[x, y];
                // get the 8 neighboaring cells
                var livingNeighboars = GetLivingNeighboars(cell);
                if (livingNeighboars == 2 || livingNeighboars == 3 && cell.IsAlive)
                {
                    // Any live cell with two or three live neighbors survives.
                    continue;
                }

                if (!cell.IsAlive && livingNeighboars == 3)
                {
                    // Any dead cell with three live neighbors becomes a live cell.
                    cell.IsAlive = true;
                    continue;
                }

                // All other live cells die in the next generation. Similarly, all other dead cells stay dead.
                cell.IsAlive = false;

                GD.Print($"Visiting: {cell.X},{cell.Y}, it has {livingNeighboars} alive neighboar cells");

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
                // calculate the 8 neigbouring cells coordinates
                var x = c.X + i;
                var y = c.Y + j;

                // if the coorinates are equal to the current cell, we simply continue
                if (i == 0 && j == 0)
                {
                    continue;
                }
                // check if we are widhing the screen && if the cell is "Alive"
                else if (x >= 0 && x <= Width - 1 && y >= 0 && y <= Height - 1 && this._grid.CellGrid[x, y].IsAlive)
                {
                    livingNeighboars++;
                }

            }
        }

        return livingNeighboars;
    }
}
