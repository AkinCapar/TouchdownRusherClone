namespace CurioAssets
{
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    [CustomEditor(typeof(CurveControl))]
    public class CurveControlEdior : Editor
    {
        private CurveControl instance;

        public CurveType CurveMode
        {
            get
            {
                return instance.CurveMode;
            }
            set
            {
                if (instance.CurveMode == value)
                    return;
                instance.CurveMode = value;
                instance.RefreshValues();
            }
        }

        void OnEnable()
        {
            instance = (CurveControl)target;
        }
        public override void OnInspectorGUI()
        {
            CustomUI();
            if (GUI.changed)
                DirtyEditor();
        }
        public static void DirtyEditor()
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
        void CustomUI()
        {
            EditorGUILayout.Space();
            CurveMode = (CurveType)EditorGUILayout.EnumPopup("Curve Style", CurveMode);
            EditorGUILayout.Space();
            instance.CurveOn = EditorGUILayout.BeginToggleGroup("Enable Curve/ Bend", instance.CurveOn);
            EditorGUILayout.Space();
            instance.pos = (Transform)EditorGUILayout.ObjectField("Curve Around", instance.pos, typeof(Transform), true);
            EditorGUILayout.Space();
            switch (CurveMode)
            {
                default:
                case CurveType.Basic:
                    instance.Curve1 = EditorGUILayout.Slider("Curve X", instance.Curve1, -100, 100);
                    instance.Curve2 = EditorGUILayout.Slider("Curve Y", instance.Curve2, -100, 100);
                    EditorGUILayout.Space();
                    instance.FlatMargin = EditorGUILayout.Slider("Flat Margin", instance.FlatMargin, 0, 50);
                    break;
                case CurveType.Globe:
                    instance.Curvature = EditorGUILayout.Slider("Curve Intensity", instance.Curvature, -100, 100);
                    EditorGUILayout.Space();
                    instance.SlantX = EditorGUILayout.Slider("Slant X", instance.SlantX, 0.2f, 2f);
                    instance.SlantZ = EditorGUILayout.Slider("Slant Z", instance.SlantZ, 0.2f, 2f);
                    EditorGUILayout.Space();
                    instance.FlatMargin = EditorGUILayout.Slider("Flat Margin", instance.FlatMargin, 0, 50);
                    break;
                case CurveType.Planer:
                    instance.Curvature = EditorGUILayout.Slider("Curve Intensity", instance.Curvature, -100, 100);
                    instance.Curve1 = EditorGUILayout.Slider("Curve X", instance.Curve1, -1, 1);
                    EditorGUI.indentLevel++;
                    instance.FlatMargin = EditorGUILayout.Slider("Flat Margin X", instance.FlatMargin, 0, 50);
                    EditorGUI.indentLevel--;
                    instance.Curve2 = EditorGUILayout.Slider("Curve Z", instance.Curve2, -1, 1);
                    EditorGUI.indentLevel++;
                    instance.FlatMargin2 = EditorGUILayout.Slider("Flat Margin Z", instance.FlatMargin2, 0, 50);
                    EditorGUI.indentLevel--;
                    break;
            }
            EditorGUILayout.EndToggleGroup();
            EditorGUILayout.Space();
        }
    }
}