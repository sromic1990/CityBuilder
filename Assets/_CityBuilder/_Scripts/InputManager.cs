using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseInputMask;
    [SerializeField] private Camera _inputCamera;

    private Action<Vector3> onPointerDownHandler;
    
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = _inputCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, _mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
                // Debug.Log(position);
                if (onPointerDownHandler != null)
                {
                    onPointerDownHandler.Invoke(position);
                }
            }
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        onPointerDownHandler += listener;
    }
    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener)
    {
        onPointerDownHandler -= listener;
    }
}


