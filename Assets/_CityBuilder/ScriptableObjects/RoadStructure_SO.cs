using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.SO
{
    [CreateAssetMenu(fileName = "New Road Structure", menuName = "CityBuilder/StructureData/RoadStructure")]
    public class RoadStructure_SO : StructureBase_SO
    {
        [Tooltip("Road Facing Up And Right")]
        public GameObject cornerPrefab;
        [Tooltip("Road Facing Up, Right and Down")]
        public GameObject threeWayPrefab;
        public GameObject fourWayPrefab;
    }
}

