using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionState : PlayerState
{
    private CameraMovement _cameraMovement;
    
    public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager)
    {
        this._cameraMovement = cameraMovement;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerChange(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerUp()
    {
        return;
    }

    public override void OnInputPanChange(Vector3 panPosition)
    {
        _cameraMovement.MoveCamera(panPosition);
    }

    public override void OnInputPanUp()
    {
        _cameraMovement.StopCameraMovement();
    }

    public override void OnCancel()
    {
        return;
    }
}
