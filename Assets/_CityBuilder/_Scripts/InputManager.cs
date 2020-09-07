using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInputManager
{
    void AddListenerOnPointerDownEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
    void AddListenerOnPointerUpEvent(Action listener);
    void RemoveListenerOnPointerUpEvent(Action listener);
    void AddListenerOnPointerChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondUpEvent(Action listener);
    void RemoveListenerOnPointerSecondUpEvent(Action listener);
}

public class InputManager : MonoBehaviour, IInputManager
{
    [SerializeField] private LayerMask _mouseInputMask;
    [SerializeField] private Camera _inputCamera;

    private Action<Vector3> onPointerDownHandler;
    private Action onPointerUpHandler;
    private Action<Vector3> onPointerChangeHandler;
    private Action<Vector3> onPointerSecondChangeHandler;
    private Action onPointerSecondUpHandler;
    
    private void Update()
    {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CallActionOnPointerMethod(onPointerDownHandler);
        }

        if (Input.GetMouseButton(0))
        {
            CallActionOnPointerMethod(onPointerChangeHandler);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (onPointerUpHandler != null)
            {
                onPointerUpHandler.Invoke();
            }
        }
    }

    private void CallActionOnPointerMethod(Action<Vector3> action)
    {
        Vector3? position = GetMousePosition();

        if (position.HasValue)
        {
            if (action != null)
            {
                action.Invoke(position.Value);
            }
        }
    }
    
    private Vector3? GetMousePosition()
    {
        var ray = _inputCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3? position = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, _mouseInputMask))
        {
            position = hit.point - transform.position;
        }
        return position;
    }

    private void GetPanningPointer()
    {
        if (Input.GetMouseButton(1))
        {
            var position = Input.mousePosition;
            if (onPointerSecondChangeHandler != null)
            {
                onPointerSecondChangeHandler.Invoke(position);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (onPointerSecondUpHandler != null)
            {
                onPointerSecondUpHandler.Invoke();
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
    public void AddListenerOnPointerUpEvent(Action listener)
    {
        onPointerUpHandler += listener;
    }
    public void RemoveListenerOnPointerUpEvent(Action listener)
    {
        onPointerUpHandler -= listener;
    }
    
    public void AddListenerOnPointerChangeEvent(Action<Vector3> listener)
    {
        onPointerChangeHandler += listener;
    }
    public void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener)
    {
        onPointerChangeHandler -= listener;
    }
    
    public void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener)
    {
        onPointerSecondChangeHandler += listener;
    }
    public void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener)
    {
        onPointerSecondChangeHandler -= listener;
    }
    
    public void AddListenerOnPointerSecondUpEvent(Action listener)
    {
        onPointerSecondUpHandler += listener;
    }
    public void RemoveListenerOnPointerSecondUpEvent(Action listener)
    {
        onPointerSecondUpHandler -= listener;
    }
}


