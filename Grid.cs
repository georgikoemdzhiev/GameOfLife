using Godot;

public class Grid : GridContainer
{
    private PackedScene cell;
    private SizeConstants _sizeConstants = null;

    public Cell[,] CellGrid;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _sizeConstants = GetNode<SizeConstants>("/root/SizeConstants");
        CellGrid = new Cell[_sizeConstants.Width, _sizeConstants.Height];

        // set the number of columns to the constant's value
        this.Columns = _sizeConstants.Width;

        cell = ResourceLoader.Load("res://Cell.tscn") as PackedScene;

        for (int x = 0; x < CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < CellGrid.GetLength(1); y++)

            {
                var cell = this.cell.Instance() as Cell;
                // set the cells X and Y
                cell.X = x;
                cell.Y = y;
                // add the cell to the grid
                CellGrid[x, y] = cell;
                // add the cell to the GridContainer
                AddChild(cell);
            }

        }
    }

    public Cell[,] CloneCellGrid()
    {

        var cellGridClone = new Cell[_sizeConstants.Width, _sizeConstants.Height];

        for (int x = 0; x < CellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < CellGrid.GetLength(1); y++)

            {
                Cell cell = CellGrid[x, y];
                var deepClone = (Cell)cell.Clone();
                cellGridClone[x, y] = deepClone;
            }

        }
        return cellGridClone;
    }
}
