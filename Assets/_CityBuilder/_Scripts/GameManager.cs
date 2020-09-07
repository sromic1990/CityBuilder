using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private IInputManager _inputManager;
    [SerializeField] private UiController _uiController;
    public UiController UiController
    {
        get { return _uiController; }
        set
        {
            _uiController = value;
        }
    }
    [SerializeField] private int _width, _length;
    [SerializeField] private CameraMovement _cameraMovement;
    public CameraMovement CameraMovement
    {
        get { return _cameraMovement; }
        set
        {
            _cameraMovement = value;
        }
    }

    private PlayerState _state;
    public PlayerState State => _state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    
    private GridStructure _grid;
    private int _cellSize = 3;

    private void Awake()
    {
        _grid = new GridStructure(_cellSize, _width, _length);
        
        selectionState = new PlayerSelectionState(this, _cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, _placementManager, _grid);
        _state = selectionState;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraMovement.SetCameraBounds(0,_width, 0, _length);
        _inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();

        _inputManager.AddListenerOnPointerDownEvent(HandleInput);
        _inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
        _inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        _inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
        // _inputManager.
        
        _uiController.AddListener_OnBuildAreaEvent(StartPlacementMode);
        _uiController.AddListener_OnCancelActionEvent(CancelAction);
    }

    private void HandlePointerChange(Vector3 position)
    {
        _state.OnInputPointerChange(position);
    }

    private void HandleInputCameraPanStop()
    {
        _state.OnInputPanUp();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        _state.OnInputPanChange(position);
    }

    private void HandleInput(Vector3 position)
    {
        _state.OnInputPointerDown(position);
    }

    private void StartPlacementMode()
    {
        TransitionToState(buildingSingleStructureState);
    }
    private void CancelAction()
    {
        _state.OnCancel();
    }

    public void TransitionToState(PlayerState newState)
    {
        this._state = newState;
        _state.EnterState();
    }
}
