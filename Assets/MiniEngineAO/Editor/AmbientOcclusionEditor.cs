using UnityEngine;
using UnityEditor;

namespace MiniEngineAO
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AmbientOcclusion))]
    public class AmbientOcclusionEditor : Editor
    {
        SerializedProperty _noiseFilterTolerance;
        SerializedProperty _blurTolerance;
        SerializedProperty _upsampleTolerance;
        SerializedProperty _rejectionFalloff;
        SerializedProperty _strength;
        SerializedProperty _debug;

        static internal class Labels
        {
            public static readonly GUIContent filterTolerance = new GUIContent("Filter Tolerance");
            public static readonly GUIContent denoise = new GUIContent("Denoise");
            public static readonly GUIContent blur = new GUIContent("Blur");
            public static readonly GUIContent upsample = new GUIContent("Upsample");
        }

        void OnEnable()
        {
            _noiseFilterTolerance = serializedObject.FindProperty("_noiseFilterTolerance");
            _blurTolerance = serializedObject.FindProperty("_blurTolerance");
            _upsampleTolerance = serializedObject.FindProperty("_upsampleTolerance");
            _rejectionFalloff = serializedObject.FindProperty("_rejectionFalloff");
            _strength = serializedObject.FindProperty("_strength");
            _debug = serializedObject.FindProperty("_debug");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField(Labels.filterTolerance);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_noiseFilterTolerance, Labels.denoise);
            EditorGUILayout.PropertyField(_blurTolerance, Labels.blur);
            EditorGUILayout.PropertyField(_upsampleTolerance, Labels.upsample);
            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(_rejectionFalloff);
            EditorGUILayout.PropertyField(_strength);
            EditorGUILayout.PropertyField(_debug);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
