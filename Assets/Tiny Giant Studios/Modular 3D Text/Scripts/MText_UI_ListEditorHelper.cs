using UnityEngine;

namespace MText
{
    //this script exists only to update the ui list in editor. Is not relevant anywhere else
    [ExecuteInEditMode]
    public class MText_UI_ListEditorHelper : MonoBehaviour
    {
        MText_UI_List list => GetComponent<MText_UI_List>();

        void OnEnable()
        {
#if UNITY_EDITOR           
            if (UnityEditor.EditorApplication.isPlaying)            
                this.enabled = false;            
#else
            this.enabled = false;
#endif
        }

#if UNITY_EDITOR
        void Update()
        {
            list.UpdateList();
        }
#endif
    }
}