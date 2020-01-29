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
    public int tiles;
    public List<Slider> sliders;

    //public int entryTileRef
    //public int exitTileRef
}

public class GameManager : MonoBehaviour
{
    [Header("Level Generator")]
    public List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateLevel(int nTile)
    {

    }
}
