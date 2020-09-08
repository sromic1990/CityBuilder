using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    private GridStructure _grid;
    private PlacementManager _placementManager;

    public BuildingManager(int cellSize, int width, int length, PlacementManager placementManager)
    {
        _grid = new GridStructure(cellSize, width, length);
        this._placementManager = placementManager;
    }

    public void PlaceStructureAt(Vector3 inputPosition)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(inputPosition);
        
        if (!_grid.IsCellTaken(gridPosition))
        {
            _placementManager.CreateBuilding(gridPosition, _grid);
        }
    }

    public void RemoveBuilding(Vector3 position)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        
        if (_grid.IsCellTaken(gridPosition))
        {
            _placementManager.RemoveBuilding(gridPosition, _grid);
        }
    }
}
