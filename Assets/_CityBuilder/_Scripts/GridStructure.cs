using System;
using UnityEngine;

public class GridStructure
{
    private int _cellSize;
    private Cell[,] _grid;
    private int _width, _length;

    public GridStructure(int cellSize, int width, int length)
    {
        this._cellSize = cellSize;
        this._width = width;
        this._length = length;
        _grid = new Cell[_width, _length];
        
        for (int row = 0; row < _grid.GetLength(0); row++)
        {
            for (int col = 0; col < _grid.GetLength(1); col++)
            {
                _grid[row, col] = new Cell();
            }
        }
    }
    
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float) inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt((float) inputPosition.z / _cellSize);

        x = Mathf.Max(x, 0);
        z = Mathf.Max(z, 0);
        
        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

    private Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / _cellSize), (int)(gridPosition.z / _cellSize));
    }

    public bool IsCellTaken(Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);

        if (CheckIndexValidity(cellIndex))
        {
            return _grid[cellIndex.y, cellIndex.x].IsTaken;
        }
        throw new IndexOutOfRangeException(($"No index in {cellIndex} in grid"));
    }

    public void PlaceStructureOnTheGrid(GameObject structure, Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        
        if (CheckIndexValidity(cellIndex))
        {
            _grid[cellIndex.y, cellIndex.x].SetContruction(structure);
        }
    }

    private bool CheckIndexValidity(Vector2Int cellIndex)
    {
        if(cellIndex.x >= 0 && cellIndex.x < _grid.GetLength(1) &&
           (cellIndex.y >= 0 && cellIndex.y < _grid.GetLength(0)))
        {
            return true;
        }
        return false;
    }
}