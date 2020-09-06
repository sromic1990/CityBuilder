using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private InputManager _inputManager;

    private GridStructure grid;
    private int cellSize = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridStructure(cellSize);
        _inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        position = grid.CalculateGridPosition(position);
        _placementManager.CreateBuilding(position);
    }
}
