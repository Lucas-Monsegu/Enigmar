//
// Procedural Lightning for Unity
// (c) 2015 Digital Ruby, LLC
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
//

#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9

#define UNITY_4

#endif

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

using System;
using System.Reflection;

namespace DigitalRuby.ThunderAndLightning
{
    [CustomEditor(typeof(LightningBoltScript), true)]
    public class LightningBoltEditor : UnityEditor.Editor
    {
        private GUIContent[] sortingLayerNames;
        private string layerName;
        private int orderInLayer;
        private int chosenIndex;
        private LightningBoltScript inspectorTarget;

        private void OnEnable()
        {
            inspectorTarget = target as LightningBoltScript;

            //Get the layer names
            string[] layerNames = GetSortingLayerNames();

            //Put them in a GUIContent variable, so that we can display a tooltip later
            sortingLayerNames = new GUIContent[layerNames.Length];
            string currentSortLayerName = (inspectorTarget.SortLayerName ?? string.Empty);

            for (int i = 0; i < sortingLayerNames.Length; i++)
            {
                sortingLayerNames[i] = new GUIContent(layerNames[i] ?? string.Empty);
                if (currentSortLayerName == layerNames[i])
                {
                    chosenIndex = i;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            //2D settings toggle on and off depending if the target camera is orthographic
            if ((inspectorTarget.Camera != null && inspectorTarget.Camera.orthographic) ||
                (inspectorTarget.Camera == null && Camera.main != null && Camera.main.orthographic))
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("2D Settings:");

                GUIContent layerTip = new GUIContent("Sorting Layer", "Layer name for custom sorting");
                chosenIndex = EditorGUILayout.Popup(layerTip, chosenIndex, sortingLayerNames);
                layerName = (sortingLayerNames[chosenIndex] == null ? null : sortingLayerNames[chosenIndex].text);

                GUIContent orderTip = new GUIContent("Sort Order", "Sort order in the sort layer");
                orderInLayer = EditorGUILayout.IntField(orderTip, inspectorTarget.SortOrderInLayer);

                EditorGUILayout.EndVertical();
            }

            //Draw the rest of the inspector. The fields above are marked not to be drawn in the default inspector so that we don't have duplicates
            DrawDefaultInspector();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(inspectorTarget, "Edit Lightning");
                inspectorTarget.SortLayerName = layerName;
                inspectorTarget.SortOrderInLayer = orderInLayer;
                EditorUtility.SetDirty(inspectorTarget);
            }
        }

        // Get the sorting layer names
        public string[] GetSortingLayerNames()
        {
            Type internalEditorUtilityType = typeof(InternalEditorUtility);
            PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
            string[] results = (string[])sortingLayersProperty.GetValue(null, new object[0]);
            return results;
        }
    }
}