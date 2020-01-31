using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField] ScripaztbleObj scriptObj;

    private float finalCVal;
    private float finalEVal;

    // Start is called before the first frame update
    void Start()
    {
        foreach(LevelData data in scriptObj.levelDatas)
        {
            finalCVal += data.conceptValue;

            finalEVal += data.experimentValue;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
