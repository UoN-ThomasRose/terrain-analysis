using UnityEngine;
using System;

public class TerrainAnalysis : MonoBehaviour {

    // Terrain Basic Data
    public float width;
    public float length;
    public float minHeight;
    public float maxHeight;

    // Terrain Roughness 
    public float lowestPoint;
    public float highestPoint;
    public float arithmeticAvg; 
    public float rootMeanSquared;
    public float skewness;
    public float kurtosis;

    // Terrain Material
    public float rockExposure; // TODO: Review this! Should this be implemented? Is it general enough?
    public string soilType = null; // TODO: Review this! Should this be implemented through a data structure or class or left out completely?!

    // Program Data
    public bool autoUpdate = false;
    public Terrain terrainMesh;

	public void GetMetrics() {

        // Get the terrain data
        terrainMesh = GetComponent<Terrain>();
        TerrainData td = terrainMesh.terrainData;

        // Get the heightmap and store it in a 2D float array
        float[,] heightmap = td.GetHeights(0, 0, (int)width, (int)length);

        /*
         * ===========================================
         * ======= DIMENSIONS AND HEIGHT RANGE =======
         * ===========================================
        */

        // Return length (x) and width (y)
        width = td.size.x;
        length = td.size.z;

        // Return height range
        minHeight = 0; // TODO: Isn't this always the case? Is this neccessary?
        maxHeight = td.size.y;
        
        /*
         * ============================================
         * ==== HIGHEST/LOWEST POINT AND ROUGHNESS ====
         * ============================================
        */ 

        float tempMaxHeight = 0;
        float tempMinHeight = td.size.y;
        float heightSum = 0;
        float squaredHeightSum = 0;
        float cubedHeightSum = 0;
        float quartedHeightSum = 0;

        // loop through the whole heightmap
        for (int x = 0; x < heightmap.GetLength(0); x++) {
            for (int y = 0; y < heightmap.GetLength(1); y++) {
                if (heightmap[x, y] > tempMaxHeight) // high check
                    tempMaxHeight = heightmap[x, y];
                if (heightmap[x, y] < tempMinHeight) // low check
                    tempMinHeight = heightmap[x, y];
                heightSum += heightmap[x, y] * td.size.y;
                squaredHeightSum += (float) Math.Pow(heightmap[x, y] * td.size.y, 2);
                cubedHeightSum += (float) Math.Pow(heightmap[x, y] * td.size.y, 3);
                quartedHeightSum += (float) Math.Pow(heightmap[x, y] * td.size.y, 4);

            }
        }

        int n = heightmap.GetLength(0) * heightmap.GetLength(1);

        // assign the values
        lowestPoint = tempMaxHeight * td.size.y;
        highestPoint = tempMinHeight * td.size.y;
        arithmeticAvg = heightSum / n;
        rootMeanSquared = (float) Math.Sqrt(squaredHeightSum / n);
        skewness = cubedHeightSum / (n * (float) Math.Pow(rootMeanSquared, 3));
        kurtosis = quartedHeightSum / (n * (float) Math.Pow(rootMeanSquared, 4));


        /*
         * ==========================
         * ======== MATERIAL ========
         * ==========================
        */

        // TODO: Add this!

        /*
         *  Rock Exposure (RE) | Rockiness Factor (rf) | Slope (s)
         *  re = rf * s ?
         *  
         *  Soil Type represented by a class (class could contain textures)?
        */
    }
}

