using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildingPrefab;
    [SerializeField] private Transform _ground;

    public void CreateBuilding(Vector3 gridPosition, GridStructure grid)
    {
        GameObject newStructure = Instantiate(_buildingPrefab, _ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnTheGrid(newStructure, gridPosition);
    }
}
