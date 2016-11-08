using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(TerrainAnalysis))]
public class TerrainAnalysisEditor : Editor {

    public TerrainAnalysis ta;

	public override void OnInspectorGUI() {

        // Get the Terrain Analysis class
        ta = (TerrainAnalysis)target;

        // If auto-update is turned on get the terrain metrics
        if(ta.autoUpdate)
            ta.GetMetrics();

        // Custom GUI
        EditorGUILayout.LabelField("Width", ta.width.ToString());
        EditorGUILayout.LabelField("Length", ta.length.ToString());
        EditorGUILayout.LabelField("Lowest Point", ta.minHeight.ToString());
        EditorGUILayout.LabelField("Highest Point", ta.maxHeight.ToString());
        EditorGUILayout.LabelField("Roughness", ta.roughness.ToString());
        ta.autoUpdate = EditorGUILayout.Toggle("Auto Update", ta.autoUpdate);
        if(GUILayout.Button("Refresh")) {
            ta.GetMetrics();
        }
    }
}


