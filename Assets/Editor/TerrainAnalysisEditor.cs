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
        EditorGUILayout.LabelField("Dimensions", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Width", ta.width.ToString());
        EditorGUILayout.LabelField("Length", ta.length.ToString());

        EditorGUILayout.LabelField("Height Properties", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Min Height", ta.minHeight.ToString());
        EditorGUILayout.LabelField("Max Height", ta.maxHeight.ToString());
        EditorGUILayout.LabelField("Lowest Point", ta.highestPoint.ToString());
        EditorGUILayout.LabelField("Highest Point", ta.lowestPoint.ToString());

        EditorGUILayout.LabelField("Roughness Properties", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Arithmetic Average", ta.arithmeticAvg.ToString());
        EditorGUILayout.LabelField("Root Mean Squared", ta.rootMeanSquared.ToString());
        EditorGUILayout.LabelField("Skewness", ta.skewness.ToString());
        EditorGUILayout.LabelField("Kurtosis", ta.kurtosis.ToString());

        EditorGUILayout.LabelField("Material Properties", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Rock Exposure", ta.rockExposure.ToString());
        EditorGUILayout.LabelField("Soil Type", ta.soilType);

        EditorGUILayout.LabelField("Update Options", EditorStyles.boldLabel);
        ta.autoUpdate = EditorGUILayout.Toggle("Auto Update", ta.autoUpdate);
        if(GUILayout.Button("Refresh")) {
            ta.GetMetrics();
        }
    }
}


