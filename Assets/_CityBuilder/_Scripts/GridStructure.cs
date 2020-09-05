using UnityEngine;

public class GridStructure
{
    private int cellSize;

    public GridStructure(int cellSize)
    {
        this.cellSize = cellSize;
    }
    
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float) inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float) inputPosition.z / cellSize);

        x = Mathf.Max(x, 0);
        z = Mathf.Max(z, 0);
        
        return new Vector3(x * cellSize, 0, z * cellSize);
    }
}