using UnityEditor;
using UnityEngine;

namespace MText.FontCreation
{
    public class MText_FontExporter
    {
        public void CreateFontFile(string prefabPath, string fontName)
        {
            MText_Font newFont = ScriptableObject.CreateInstance<MText_Font>();
            GameObject fontSet = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject)) as GameObject;

            newFont.UpdateCharacterList(fontSet);
            string scriptableObjectSaveLocation = EditorUtility.SaveFilePanel("Save font location", "", fontName, "asset");
            scriptableObjectSaveLocation = FileUtil.GetProjectRelativePath(scriptableObjectSaveLocation);
            AssetDatabase.CreateAsset(newFont, scriptableObjectSaveLocation);
            AssetDatabase.SaveAssets();
        }
    }
}
