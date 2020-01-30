using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBoy
{
    public int amount;
    public GameObject sliderObject;
}

public class Level
{
    public int tiles; // square tile size of the map ; 10 for 10x10 map, etc.
    public List<SliderBoy> sliderBoys;

    //public int entryTileRef
    //public int exitTileRef
}

public class GameManager : MonoBehaviour
{
    bool endLevel = false;

    public DataManager dataManager;

    [Header("Scene Objects References")]
    public GameObject particleSpawner;
    public GameObject endDoor;

    [Header("UI References")]
    public GameObject endDisplay;

    [Header("Level Info")]
    public int levelIndex;

    [HideInInspector] public bool hasBeenPlaced = false;
    [HideInInspector] public int placedSliders = 0;

    public int minimumSliders;
    public int maximumSliders;

    public int particleQuantity; // must be referenced by ParticleSpawner script

    private LevelData currentLevel;

    private int scoreToDisplay;
    private int starScore;

    private float timeT;
    private float timeBFP;

    void Start()
    {
        currentLevel = dataManager.levelDatas[levelIndex];

        DataSetup();
    }

    void Update()
    {
        if (endLevel)
        {
            //Scoring
            ScoreData();

            //Player Stats
            PlayerSecretData(levelIndex);

            DisplayEnding();
        }

        else
        {
            timeT += Time.deltaTime;

            if (!hasBeenPlaced) timeBFP += Time.deltaTime;
        }
    }

    void DataSetup()
    {
        currentLevel.initialParticules = particleQuantity; //particleSpawner.GetComponent<SpawnParticles>().spawnNumbers;
        currentLevel.minPieces = minimumSliders;
        currentLevel.maxPieces = maximumSliders;
    }

    void ScoreData()
    {
        currentLevel.usedPieces = 0;
        currentLevel.savedParticules = endDoor.GetComponent<endBox>().numberParticle;

        scoreToDisplay = currentLevel.Score(
            currentLevel.EfficiencyCoefficient(currentLevel.usedPieces, currentLevel.minPieces, currentLevel.maxPieces),
            currentLevel.ParticuleCoefficient(currentLevel.savedParticules, currentLevel.initialParticules),
            false
            );

        if (scoreToDisplay > 29) starScore = 2;

        else if (scoreToDisplay > 70) starScore = 3;
    }

    void PlayerSecretData(int lvl)
    {
        if (lvl == 1 || lvl == 2) // Data for Experimentation Levels
        {
            currentLevel.numberOfTries = 0;
            currentLevel.totalTime = timeT;
            currentLevel.timeBeforeFirstPiece = timeBFP;
        }

        else if (lvl == 3 || lvl == 4) // Data for One Try Levels
        {

        }
    }

    void DisplayEnding()
    {

    }

    /*
    void GenerateLevel(int nTile, List<Slider> sAmount)
    {
        // Generate Level map with nTile tiles
        // Kilian code


    }
    */
}
