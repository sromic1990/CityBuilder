using UnityEngine;

public class Cell
{
    private GameObject _structureModel = null;
    private bool _isTaken = false;

    public bool IsTaken => _isTaken;

    public void SetContruction(GameObject structureModel)
    {
        if(structureModel == null)
            return;
        
        this._structureModel = structureModel;
        this._isTaken = true;
    }

    public GameObject GetStructure()
    {
        return _structureModel;
    }

    public void RemoveStructure()
    {
        _structureModel = null;
        _isTaken = false;
    }
}