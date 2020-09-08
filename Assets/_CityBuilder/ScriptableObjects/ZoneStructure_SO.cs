using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.SO
{
    [CreateAssetMenu(fileName = "New Zone Structure", menuName = "CityBuilder/StructureData/ZoneStructure")]
    public class ZoneStructure_SO : StructureBase_SO
    {
        public bool upgradable;
        public GameObject[] prefabVarients;
        public UpgradeType[] availableUpgrades;
        public ZoneType zoneType;
    }

    public enum ZoneType
    {
        Residential,
        Agricultural,
        Commercial,
    }

    [System.Serializable]
    public struct UpgradeType
    {
        public GameObject[] prefabVariates;
        public int happinessThreshold;
        public int newIncome;
        public int newUpkeep;
    }
}
