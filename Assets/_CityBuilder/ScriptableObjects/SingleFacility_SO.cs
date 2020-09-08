using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.SO
{
    [CreateAssetMenu(fileName = "New Facility", menuName = "CityBuilder/StructureData/Facility")]
    public class SingleFacility_SO : SingleStructureBase_SO
    {
        public int maxCustomers;
        public int upkeepPerCustomer;
    }
}

