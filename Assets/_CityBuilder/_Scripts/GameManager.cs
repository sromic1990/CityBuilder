using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private int _width, _length;

    private GridStructure _grid;
    private int _cellSize = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        _grid = new GridStructure(_cellSize, _width, _length);
        _inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (!_grid.IsCellTaken(gridPosition))
        {
            _placementManager.CreateBuilding(gridPosition, _grid);
        }
    }
}
