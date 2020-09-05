using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public LayerMask mouseInputMask;
    public Camera inputCamera;

    // public GameObject buildingPrefab;
    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = inputCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
            }
        }
    }

    // private void CreateBuilding(Vector3 gridPosition)
    // {
    //     Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
    // }
}


