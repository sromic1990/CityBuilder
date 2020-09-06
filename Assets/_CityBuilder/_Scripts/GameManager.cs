using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private IInputManager _inputManager;
    [SerializeField] private UiController _uiController;
    [SerializeField] private int _width, _length;

    private GridStructure _grid;
    private int _cellSize = 3;
    private bool _buildingModeActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        _grid = new GridStructure(_cellSize, _width, _length);
        _inputManager.AddListenerOnPointerDownEvent(HandleInput);
        _uiController.AddListener_OnBuildAreaEvent(StartPlacementMode);
        _uiController.AddListener_OnCancelActionEvent(CancelAction);
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (_buildingModeActive && !_grid.IsCellTaken(gridPosition))
        {
            _placementManager.CreateBuilding(gridPosition, _grid);
        }
    }

    private void StartPlacementMode()
    {
        _buildingModeActive = true;
    }
    private void CancelAction()
    {
        _buildingModeActive = false;
    }
}
