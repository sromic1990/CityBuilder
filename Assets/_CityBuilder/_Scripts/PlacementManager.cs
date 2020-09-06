using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildingPrefab;
    [SerializeField] private Transform _ground;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateBuilding(Vector3 gridPosition)
    {
        Instantiate(_buildingPrefab, _ground.position + gridPosition, Quaternion.identity);
    }
}
