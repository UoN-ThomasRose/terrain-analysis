using UnityEngine;
using System.Collections;

public class TerrainAnalysis : MonoBehaviour {

    public float width;
    public float length;
    public float maxHeight;
    public float minHeight;
    public float roughness;
    public bool autoUpdate = false;
    public Terrain terrainMesh;

    public TerrainAnalysis() {
        terrainMesh = GetComponent<Terrain>();
    }

	public void GetMetrics() {

        // Get the terrain data
        TerrainData td = terrainMesh.terrainData;

        // Get the heightmap and store it in a 2D float array
        float[,] heightmap = td.GetHeights(0, 0, (int)width, (int)length);

        /*
         * ==========================
         * ======= DIMENSIONS =======
         * ==========================
        */

        // Return length (x) and width (y)
        width = td.size.x;
        length = td.size.z;
        
        /*
         * ==========================
         * ==== MAX & MIN HEIGHT ====
         * ==========================
        */ 

        float tempMaxHeight = 0;
        float tempMinHeight = td.size.y; // TODO: See if this actually works as intended

        // loop through the whole heightmap
        for(int x = 0; x < heightmap.GetLength(0); x++) {
            for (int y = 0; y < heightmap.GetLength(1); y++) {
                try {
                    if (heightmap[x, y] > tempMaxHeight) // high check
                        tempMaxHeight = heightmap[x, y];
                    if (heightmap[x, y] < tempMinHeight) // low check
                        tempMinHeight = heightmap[x, y];
                } catch (System.Exception e) {
                    Debug.Log(e);
                    Debug.Log("X: " + x + ". Y: " + y + ".");
                }
            }
        }

        // assign the values
        maxHeight = tempMaxHeight * td.size.y;
        minHeight = tempMinHeight * td.size.y;

        /*
         * ===========================
         * ======== ROUGHNESS ========
         * ===========================
        */

        // TODO: Add this!
    }
}

