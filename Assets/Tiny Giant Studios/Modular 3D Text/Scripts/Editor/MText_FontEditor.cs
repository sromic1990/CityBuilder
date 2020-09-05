using System;
using UnityEngine;
using UnityEditor;


namespace MText
{
    [CustomEditor(typeof(MText_Font))]
    public class MText_FontEditor : Editor
    {
        MText_Font myTarget;
        SerializedObject soTarget;

        SerializedProperty rotationFix;
        SerializedProperty positionFix;
        SerializedProperty scaleFix;
        SerializedProperty fontSet;
        SerializedProperty overwriteOldSet;
        SerializedProperty characters;
        SerializedProperty monoSpaceFont;
        SerializedProperty useUpperCaseLettersIfLowerCaseIsMissing;
        SerializedProperty emptySpaceSpacing;
        SerializedProperty characterSpacing;

        void OnEnable()
        {
            myTarget = (MText_Font)target;
            soTarget = new SerializedObject(target);

            rotationFix = soTarget.FindProperty("rotationFix");
            positionFix = soTarget.FindProperty("positionFix");
            scaleFix = soTarget.FindProperty("scaleFix");

            fontSet = soTarget.FindProperty("fontSet");
            overwriteOldSet = soTarget.FindProperty("overwriteOldSet");
            monoSpaceFont = soTarget.FindProperty("monoSpaceFont");
            useUpperCaseLettersIfLowerCaseIsMissing = soTarget.FindProperty("useUpperCaseLettersIfLowerCaseIsMissing");
            emptySpaceSpacing = soTarget.FindProperty("emptySpaceSpacing");
            characterSpacing = soTarget.FindProperty("characterSpacing");

            characters = soTarget.FindProperty("characters");
        }

        public override void OnInspectorGUI()
        {
            soTarget.Update();
            EditorGUI.BeginChangeCheck();

            GetFontSet();
            GUILayout.Space(20);
            FixSettings();
            GUILayout.Space(20);
            CreateCharacterList();


            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
            }
        }


        void FixSettings()
        {
            EditorGUILayout.LabelField("Incase this specific font doesnt have proper transform");

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rotation Fix", GUILayout.MaxWidth(70));
            EditorGUILayout.PropertyField(rotationFix, GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Position Fix", GUILayout.MaxWidth(70));
            EditorGUILayout.PropertyField(positionFix, GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Scale Fix", GUILayout.MaxWidth(70));
            EditorGUILayout.PropertyField(scaleFix, GUIContent.none);
            GUILayout.EndHorizontal();
        }

        void GetFontSet()
        {
            EditorGUILayout.LabelField("Font - Set object");
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            EditorGUILayout.PropertyField(fontSet);
            EditorGUILayout.PropertyField(overwriteOldSet);


            if (GUILayout.Button("Create/Recreate characters"))
            {
                myTarget.UpdateCharacterList();
                EditorUtility.SetDirty(target);
            }
            GUILayout.Space(5);

            EditorGUILayout.PropertyField(monoSpaceFont);
            GUIContent useUpperCase = new GUIContent("Use UpperCase If LowerCase Is Missing", "Use UpperCase If LowerCase Is Missing");
            EditorGUILayout.PropertyField(useUpperCaseLettersIfLowerCaseIsMissing, useUpperCase);
            EditorGUILayout.PropertyField(emptySpaceSpacing);
            EditorGUILayout.PropertyField(characterSpacing);
        }

        void CreateCharacterList()
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Char -", GUILayout.MaxWidth(45));
            EditorGUILayout.LabelField("Spacing -", GUILayout.MaxWidth(65));
            EditorGUILayout.LabelField("Prefab -", GUILayout.MaxWidth(55));
            EditorGUILayout.LabelField("or Mesh Asset");

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            for (int i = 0; i < myTarget.characters.Count; i++)
            {
                GUILayout.BeginHorizontal();

                if (characters.arraySize > 0)
                    EditorGUILayout.PropertyField(characters.GetArrayElementAtIndex(i), GUIContent.none);

                if (GUILayout.Button("-", GUILayout.MaxWidth(30)))
                {
                    myTarget.characters.RemoveAt(i);
                }

                GUILayout.EndHorizontal();
            }
            if (GUILayout.Button("+"))
            {
                MText_Character character = new MText_Character();
                myTarget.characters.Add(character);
                EditorUtility.SetDirty(target);
            }
        }
    }
}
