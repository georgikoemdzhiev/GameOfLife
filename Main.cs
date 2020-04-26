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
        var aliveNeighboursCount = 0;
        var deadNeighboursCount = 0;
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

                    if (n is Cell north)
                        if (north.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (e is Cell east)
                        if (east.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (s is Cell south)
                        if (south.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (w is Cell west)
                        if (west.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (nw is Cell northWest)
                        if (northWest.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (ne is Cell northEast)
                        if (northEast.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (sw is Cell southWest)
                        if (southWest.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    if (se is Cell southEest)
                        if (southEest.IsAlive) aliveNeighboursCount++; else deadNeighboursCount++;

                    GD.Print($"Visiting: {x},{y}");
                }
                catch (Exception exception)
                {
                    GD.Print(exception.Message);
                    // Here I am using Try-Catch to avoid having 8 if statements to check for edge cells
                }

                // reset counts for next cell
                aliveNeighboursCount = 0;
                deadNeighboursCount = 0;

            }

        }
    }
}
