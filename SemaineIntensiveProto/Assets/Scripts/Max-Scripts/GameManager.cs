using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider
{
    public int amount;
    public GameObject sliderObject;
}

public class Level
{
    public int tiles; // square tile size of the map ; 10 for 10x10 map, etc.
    public List<Slider> sliders;

    //public int entryTileRef
    //public int exitTileRef
}

public class GameManager : MonoBehaviour
{
    [Header("Level Generator")]
    public List<Level> levels;

    bool endLevel = false;

    public DataManager dataManager;

    public int levelIndex;

    void Start()
    {
        dataManager.levelDatas[levelIndex].intialParticules = 0;
        dataManager.levelDatas[levelIndex].minPieces = 0;
        dataManager.levelDatas[levelIndex].maxPieces = 0;
    }

    void Update()
    {
        if (endLevel)
        {
            //Player Stats
            

            
            //Scoring

        }
    }

    /*
    void GenerateLevel(int nTile, List<Slider> sAmount)
    {
        // Generate Level map with nTile tiles
        // Kilian code


    }
    */
}
