using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.SO
{
    public abstract class StructureBase_SO : ScriptableObject
    {
        public string buildingName;
        public GameObject prefab;
        public int placementCost;
        public int upkeepCost;
        public int income;
        public bool requireRoadAccess;
        public bool requireWaterAccess;
        public bool requirePowerAccess;
    }
}
