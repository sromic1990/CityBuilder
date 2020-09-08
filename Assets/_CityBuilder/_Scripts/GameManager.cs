using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    private BuildingManager _buildingManager;
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

    [SerializeField] private LayerMask _inputMask;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    public PlayerRemoveBuildingState demolishState;
    
    private int _cellSize = 3;

    private void Awake()
    {
        _buildingManager = new BuildingManager(_cellSize, _width, _length, _placementManager);

        selectionState = new PlayerSelectionState(this, _cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, _buildingManager);
        demolishState = new PlayerRemoveBuildingState(this, _buildingManager);
        
        _state = selectionState;

#if (UNITY_EDITOR && TEST) //&& !(UNITY_IOS || UNITY_ANDROID)
        _inputManager = gameObject.AddComponent<InputManager>();
#endif
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        PrepareGameComponents();
        AssignInputListeners();
        AssignUiControllerListeners();
    }

    private void PrepareGameComponents()
    {
        _inputManager.MouseInputMask = _inputMask;
        _cameraMovement.SetCameraBounds(0, _width, 0, _length);
    }

    private void AssignUiControllerListeners()
    {
        _uiController.AddListener_OnBuildAreaEvent(StartPlacementMode);
        _uiController.AddListener_OnCancelActionEvent(CancelAction);
        _uiController.AddListener_OnDemolishActionEvent(StartDemolishMode);
    }

    private void AssignInputListeners()
    {
        _inputManager.AddListenerOnPointerDownEvent(HandleInput);
        _inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPan);
        _inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        _inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
    }

    private void StartDemolishMode()
    {
        TransitionToState(demolishState);
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
