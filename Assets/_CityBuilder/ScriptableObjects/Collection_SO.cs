using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.SO
{
    [CreateAssetMenu(fileName = "New Collection", menuName = "CityBuilder/StructureData/CollectionSO")]
    public class Collection_SO : ScriptableObject
    {
        public RoadStructure_SO roadStructure;
        public List<SingleStructureBase_SO> singleStructureList;
        public List<ZoneStructure_SO> zonesList;
    }
}
