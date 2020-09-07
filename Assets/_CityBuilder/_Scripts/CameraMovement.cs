using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3? _basePointerPosition = null;
    [SerializeField] private float _cameraMovementSpeed = 0.05f;
    [ReadOnly][SerializeField] private int _cameraXMin;
    [ReadOnly][SerializeField] private int _cameraXMax;
    [ReadOnly][SerializeField] private int _cameraZMin;
    [ReadOnly][SerializeField] private int _cameraZMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(Vector3 pointerPosition)
    {
        if (_basePointerPosition.HasValue == false)
        {
            _basePointerPosition = pointerPosition;
        }
        Vector3 newPosition = pointerPosition - _basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);
        transform.Translate(newPosition * _cameraMovementSpeed);
        LimitPositionInsideCameraBounds();
    }

    private void LimitPositionInsideCameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _cameraXMin, _cameraXMax),
            0,
            Mathf.Clamp(transform.position.z, _cameraZMin, _cameraZMax));
    }

    public void StopCameraMovement()
    {
        _basePointerPosition = null;
    }

    public void SetCameraBounds(int xMin, int xMax, int zMin, int zMax)
    {
        this._cameraXMin = xMin;
        this._cameraXMax = xMax;
        this._cameraZMin = zMin;
        this._cameraZMax = zMax;
    }
}
