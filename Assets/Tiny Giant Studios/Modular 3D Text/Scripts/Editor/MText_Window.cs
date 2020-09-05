/// Created by Ferdowsur Asif @ Tiny Giant Studios

using UnityEngine;
using UnityEditor;
using MText.FontCreation;

namespace MText
{
    public class MText_Window : EditorWindow
    {
        SerializedObject soTarget;

        public MText_Settings settings;
        private string selectedTab = "Getting Started";
        //private bool neverStartedBefore = true;

        GUIStyle tabStyle;

        void OnEnable()
        {
            if (settings && soTarget == null)
            {
                soTarget = new SerializedObject(settings);
            }
        }

        [MenuItem("Tools/Tiny Giant Studios/Modular 3D Text", false, 100)]
        public static void ShowWindow()
        {
            if (Application.isPlaying)
            {
                Debug.Log("");
                Application.Quit();
            }

            EditorWindow editorWindow = EditorWindow.GetWindow(typeof(MText_Window), false, "Modular 3D Text");
            editorWindow.Show();
        }

        void OnGUI()
        {
            if (settings && soTarget == null)
            {
                soTarget = new SerializedObject(settings);
            }


            GenerateStyle();
            EditorGUI.BeginChangeCheck();



            GUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");

            Tabs();
            DrawUILine(Color.gray);

            GUILayout.Space(10);

            if (selectedTab == "Customization")
                Preference();
            else if (selectedTab == "Feedback")
                Feedback();
            else if (selectedTab == "Font Creation")
                FontCreation();
            else
                GeneralInformation();


            GUI.backgroundColor = Color.white;
            EditorGUILayout.EndVertical();

            GUILayout.Space(5f);
            DrawUILine(Color.grey, 1, 2);
            ProductInformation();
            GUILayout.Space(5f);


            if (EditorGUI.EndChangeCheck())
            {
                if (soTarget != null) soTarget.ApplyModifiedProperties();
                EditorUtility.SetDirty(settings);
            }
        }

        void GenerateStyle()
        {
            if (tabStyle == null)
            {
                tabStyle = new GUIStyle(GUI.skin.button);
                tabStyle.margin = new RectOffset(0, 0, tabStyle.margin.top, tabStyle.margin.bottom);
            }
        }
        bool LeftButton(GUIContent content)
        {
            bool clicked = false;
            Rect rect = GUILayoutUtility.GetRect(20, 20);
            GUI.BeginGroup(rect);
            if (GUI.Button(new Rect(0, 0, rect.width + tabStyle.border.right, rect.height), content, tabStyle))
                clicked = true;

            GUI.EndGroup();
            return clicked;
        }
        bool MidButton(GUIContent content)
        {
            bool clicked = false;
            Rect rect = GUILayoutUtility.GetRect(20, 20);
            GUI.BeginGroup(rect);
            if (GUI.Button(new Rect(-tabStyle.border.left, 0, rect.width + tabStyle.border.left + tabStyle.border.right, rect.height), content, tabStyle))
                clicked = true;
            GUI.EndGroup();
            return clicked;
        }
        bool RightButton(GUIContent content)
        {
            bool clicked = false;
            Rect rect = GUILayoutUtility.GetRect(20, 20);
            GUI.BeginGroup(rect);
            if (GUI.Button(new Rect(-tabStyle.border.left, 0, rect.width + tabStyle.border.left, rect.height), content, tabStyle))
                clicked = true;
            GUI.EndGroup();
            return clicked;
        }

        void Tabs()
        {
            Color originalBackgroundColor = GUI.backgroundColor;
            GUILayout.BeginHorizontal();

            if (selectedTab == "Getting Started")
            {
                if (settings)
                    GUI.backgroundColor = settings.thirdBackgroundColor;
                else
                    GUI.backgroundColor = Color.grey;
            }
            GUIContent gettingStarted = new GUIContent("Getting Started");
            if (LeftButton(gettingStarted))
            {
                selectedTab = "Getting Started";

                if (settings)
                    settings.selectedTab = selectedTab;
            }
            GUI.backgroundColor = originalBackgroundColor;




            if (selectedTab == "Customization")
            {
                if (settings)
                    GUI.backgroundColor = settings.thirdBackgroundColor;
                else
                    GUI.backgroundColor = Color.grey;
            }
            GUIContent Customization = new GUIContent("Customization");
            if (MidButton(Customization))
            {
                selectedTab = "Customization";

                if (settings)
                    settings.selectedTab = selectedTab;
            }
            GUI.backgroundColor = originalBackgroundColor;



            if (selectedTab == "Font Creation")
            {
                if (settings)
                    GUI.backgroundColor = settings.thirdBackgroundColor;
                else
                    GUI.backgroundColor = Color.grey;
            }
            GUIContent fontCreation = new GUIContent("Font Creation");
            if (MidButton(fontCreation))
            {
                selectedTab = "Font Creation";

                if (settings)
                    settings.selectedTab = selectedTab;
            }
            GUI.backgroundColor = originalBackgroundColor;

            if (selectedTab == "Feedback")
            {
                if (settings)
                    GUI.backgroundColor = settings.thirdBackgroundColor;
                else
                    GUI.backgroundColor = Color.grey;
            }
            GUIContent Feedback = new GUIContent("Feedback");
            if (RightButton(Feedback))
            {
                selectedTab = "Feedback";

                if (settings)
                    settings.selectedTab = selectedTab;
            }

            GUI.backgroundColor = originalBackgroundColor;
            GUILayout.EndHorizontal();
        }

        void GeneralInformation()
        {
            StartInfo();
            DrawUILine(Color.gray);

            EditorGUILayout.LabelField("Offline documentation is in asset directory");
            HorizontalButtonURL("Online Documentation", "https://docs.google.com/document/d/11Mb2H-b6QX79MpnHkNb-1Bcc7zm-A7wrMdZcEkis8UY");
            HorizontalButtonURL("(Unity) Forum", "https://forum.unity.com/threads/modular-3d-text-3d-texts-for-your-3d-game.821931/");

            GUILayout.BeginHorizontal();
            HorizontalButtonURL("How to make fonts (video)", "https://youtu.be/2ixgOJ_sXtI");
            HorizontalButtonURL("How to make fonts (written)", "https://docs.google.com/document/d/11Mb2H-b6QX79MpnHkNb-1Bcc7zm-A7wrMdZcEkis8UY/edit#heading=h.vw07a3ihsmyb");
            GUILayout.EndHorizontal();

            //HorizontalButtonURL("Rate the asset", "https://assetstore.unity.com/packages/3d/props/tools/modular-3d-text-159508");
        }
        void StartInfo()
        {
            EditorGUILayout.LabelField("Welcome to Modular 3D Text.");

            GUILayout.Space(5f);

            EditorGUILayout.LabelField("To create 3D UIs,", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Right click in your scene hierarchy, \n3D Objects > Modular 3D Text > Your UI ELement.", MessageType.Info);

            GUILayout.Space(5f);
        }

        void Preference()
        {
            if (settings)
            {
                GUILayout.Label("Default values", EditorStyles.boldLabel);


                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Font", GUILayout.MaxWidth(120));
                EditorGUILayout.PropertyField(soTarget.FindProperty("defaultFont"), GUIContent.none);
                if (GUILayout.Button("Apply to scene", GUILayout.MaxWidth(100)))
                {
                    ApplyDefaultFontToScene();
                }
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(5f);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Text Size", GUILayout.MaxWidth(120));
                EditorGUILayout.PropertyField(soTarget.FindProperty("defaultTextSize"), GUIContent.none);
                if (GUILayout.Button("Apply to scene", GUILayout.MaxWidth(100)))
                {
                    ApplyDefaultTextSizeToScene();
                }
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(5f);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Text Material", GUILayout.MaxWidth(120));
                EditorGUILayout.PropertyField(soTarget.FindProperty("defaultTextMaterial"), GUIContent.none);
                if (GUILayout.Button("Apply to scene", GUILayout.MaxWidth(100)))
                {
                    ApplyDefaultTextMaterialToScene();
                }
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(5f);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Background Material", GUILayout.MaxWidth(120));
                EditorGUILayout.PropertyField(soTarget.FindProperty("defaultBackgroundMaterial"), GUIContent.none);
                if (GUILayout.Button("Apply to scene", GUILayout.MaxWidth(100)))
                {
                    ApplyDefaultBackgroundMaterialToScene();
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.HelpBox("Under Construction. Expect a LOT more options in the future.", MessageType.Info);

        }
        void Feedback()
        {
            HorizontalButtonURL("(Unity) Forum", "https://forum.unity.com/threads/modular-3d-text-3d-texts-for-your-3d-game.821931/");
            string forumMsg = "Join the conversation in Unity Forum.Submit any feature requests, issues you have run into. I always try my best to help with anything I can.";
            EditorGUILayout.HelpBox(forumMsg, MessageType.Info);

            GUILayout.Space(15f);
            HorizontalButtonURL("Rate the asset", "https://assetstore.unity.com/packages/3d/props/tools/modular-3d-text-159508");
            EditorGUILayout.HelpBox("As a new asset publisher without any marketing skill, reviews are primary method of getting discovered.\nPlease leave a review if you have the time and help me continuously improve the asset.", MessageType.Info);

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Feel free to contact directly via mail. Always happy to help.");
            GUILayout.Label("Support: Asifno13@gmail.com", EditorStyles.boldLabel);
        }
        void ProductInformation()
        {
            GUILayout.Label("Modular 3D Text \nVersion: 1.5.04", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Created by Ferdowsur Asif @ Tiny Giant Studios.", EditorStyles.miniBoldLabel);
        }

        void ApplyDefaultFontToScene()
        {
            string notice = "Are you sure you want to apply '" + settings.defaultFont.name + "' font to every text in the scene?" +
                "You can't press Undo for this action.";
            if (EditorUtility.DisplayDialog("Confirmation", notice, "Apply", "Do not apply"))
            {
                Modular3DText[] modular3DTexts = FindObjectsOfType<Modular3DText>();
                for (int i = 0; i < modular3DTexts.Length; i++)
                {
                    modular3DTexts[i].font = settings.defaultFont;
                    modular3DTexts[i].UpdateText();
                }
            }
        }
        void ApplyDefaultTextSizeToScene()
        {
            string notice = "Are you sure you want to apply '" + settings.defaultTextSize + "' font size to every text in the scene?" +
                "You can't press Undo for this action.";
            if (EditorUtility.DisplayDialog("Confirmation", notice, "Apply", "Do not apply"))
            {
                Modular3DText[] modular3DTexts = FindObjectsOfType<Modular3DText>();
                for (int i = 0; i < modular3DTexts.Length; i++)
                {
                    modular3DTexts[i].fontSize = settings.defaultTextSize;
                    modular3DTexts[i].UpdateText();
                }

                MText_UI_Button[] buttons = FindObjectsOfType<MText_UI_Button>();
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].normalFontSize = settings.defaultTextSize;
                }
            }
        }
        void ApplyDefaultTextMaterialToScene()
        {
            string notice = "Are you sure you want to apply '" + settings.defaultTextMaterial.name + "' material to every button in the scene?" +
                "You can't press Undo for this action.";
            if (EditorUtility.DisplayDialog("Confirmation", notice, "Apply", "Do not apply"))
            {
                Modular3DText[] modular3DTexts = FindObjectsOfType<Modular3DText>();
                for (int i = 0; i < modular3DTexts.Length; i++)
                {
                    modular3DTexts[i].material = settings.defaultTextMaterial;
                    modular3DTexts[i].UpdateText();
                }

                MText_UI_Button[] buttons = FindObjectsOfType<MText_UI_Button>();
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].normalFontMaterial = settings.defaultTextMaterial;
                }
            }
        }
        void ApplyDefaultBackgroundMaterialToScene()
        {
            string notice = "Are you sure you want to apply '" + settings.defaultBackgroundMaterial.name + "' to every text in the scene?" +
                "You can't press Undo for this action.";
            if (EditorUtility.DisplayDialog("Confirmation", notice, "Apply", "Do not apply"))
            {
                MText_UI_Button[] buttons = FindObjectsOfType<MText_UI_Button>();
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].normalBackgroundMaterial = settings.defaultBackgroundMaterial;
                }
            }
        }

        void FontCreation()
        {
            Color normalColor = GUI.backgroundColor;
            GUI.backgroundColor = settings.thirdPropertyFieldColor;
            if (GUILayout.Button("Create Font", GUILayout.MinHeight(50)))
            {
                CreateFont();
            }
            GUI.backgroundColor = normalColor;
            GUILayout.Space(15);


            CharacterInput(normalColor);
            GUILayout.Space(15);
            FontSettings(normalColor);
            GUILayout.Space(15);
            MeshExportSettings();
        }

        private void MeshExportSettings()
        {
            GUILayout.BeginHorizontal();
            GUIContent exportStyle = new GUIContent("Export As", "Which way you want mesh to be saved as.");
            EditorGUILayout.LabelField(exportStyle, GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("meshExportStyle"), GUIContent.none);
            GUILayout.EndHorizontal();
        }

        void CharacterInput(Color normalColor)
        {
            GUI.backgroundColor = settings.thirdBackgroundColor;
            GUILayout.BeginVertical("Box");
            GUILayout.Label("Character Range:");
            DrawUILine(Color.gray);

            GUI.backgroundColor = normalColor;

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Start", GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("startChar"), GUIContent.none);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("End", GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("endChar"), GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.Label("Leave it to '!' & '~' for English");
            GUILayout.BeginHorizontal();
            HorizontalButtonURL("Get character list", "https://unicode-table.com/en/");
            HorizontalButtonURL("How it works", "https://youtu.be/JN_DSmdiRSI"); //to-do make a video with the unity editor
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
        void FontSettings(Color normalColor)
        {
            GUI.backgroundColor = settings.thirdBackgroundColor;
            GUILayout.BeginVertical("Box");
            GUILayout.Label("Model Settings:");
            DrawUILine(Color.gray);

            GUI.backgroundColor = normalColor;

            GUILayout.BeginHorizontal();
            GUIContent vertexDensity = new GUIContent("Vertex Density", "How many verticies should be used. Has very little impact other than calculation time if changed, since mesh automatically gets simplified after creation.");
            EditorGUILayout.LabelField(vertexDensity, GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("vertexDensity"), GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUIContent sizeXY = new GUIContent("Size XY", "Base font size.");
            EditorGUILayout.LabelField(sizeXY, GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("sizeXY"), GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUIContent sizeZ = new GUIContent("Size Z/Depth", "Base depth");
            EditorGUILayout.LabelField(sizeZ, GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("sizeZ"), GUIContent.none);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUIContent smoothingAngle = new GUIContent("Smoothing Angle", "Any verticies with lower angle will be smooth.");
            EditorGUILayout.LabelField(smoothingAngle, GUILayout.MaxWidth(120));
            EditorGUILayout.PropertyField(soTarget.FindProperty("smoothingAngle"), GUIContent.none);
            GUILayout.EndHorizontal();

            EditorGUILayout.HelpBox("Keep these values to 1 unless you really need to change it. \nSmoothing angle by default is 30 degrees (Same as blender). Lower value will give a flat looking font and higher is smoother.", MessageType.Info);

            GUILayout.EndVertical();
        }
        void CreateFont()
        {
            GameObject gameObject = new GameObject();

            bool exportAsObj = true;
            if (settings.meshExportStyle != MText_Settings.MeshExportStyle.exportAsObj) exportAsObj = false;

            MText_FontCreator fontCreator = new MText_FontCreator();
            fontCreator.CreateFont(gameObject, settings.startChar, settings.endChar, settings.sizeXY, settings.sizeZ, settings.vertexDensity, settings.smoothingAngle, settings.defaultTextMaterial, exportAsObj);

            EditorUtility.DisplayProgressBar("Creating font", "Mesh creation started", 75 / 100);
            if (gameObject.transform.childCount > 0)
            {
                if (exportAsObj)
                {
                    MText_ObjExporter objExporter = new MText_ObjExporter();
                    string prefabPath = objExporter.DoExport(gameObject, true);
                    if (string.IsNullOrEmpty(prefabPath))
                    {
                        Debug.Log("Object save failed");
                        EditorUtility.ClearProgressBar();
                        return;
                    }
                    MText_FontExporter fontExporter = new MText_FontExporter();
                    fontExporter.CreateFontFile(prefabPath, gameObject.name);
                }
                else
                {
                    MText_MeshAssetExporter meshAssetExporter = new MText_MeshAssetExporter();
                    meshAssetExporter.DoExport(gameObject);
                }
            }

            EditorUtility.ClearProgressBar();
            if (Application.isPlaying) Destroy(gameObject);
            else DestroyImmediate(gameObject);
        }


        void HorizontalButtonURL(string text, string url)
        {
            if (GUILayout.Button(text, GUILayout.MinHeight(25)))
            {
                Application.OpenURL(url);
            }
        }

        public static void DrawUILine(Color color, int thickness = 1, int padding = 1)
        {
            Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            r.height = thickness;
            r.y += padding / 2;
            r.x -= 2;
            r.width += 6;
            EditorGUI.DrawRect(r, color);
        }
    }
}