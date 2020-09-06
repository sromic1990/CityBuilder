using UnityEngine;

namespace Sourav.Utilities.Extensions
{
    public static class GameObjectExtensions
    {
        public static void Show(this GameObject gObj)
        {
            if (gObj != null)
            {
                gObj.SetActive(true);
            }
        }
        
        public static void Hide(this GameObject gObj)
        {
            if (gObj != null)
            {
                gObj.SetActive(false);
            }
        }
    }
}
