using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField] ScripaztbleObj scriptObj;

    private float finalCVal;
    private float finalEVal;

    public GameObject conceptObj;
    public GameObject expObj;

    // Start is called before the first frame update
    void Start()
    {
        foreach(LevelData data in scriptObj.levelDatas)
        {
            finalCVal += data.conceptValue;

            finalEVal += data.experimentValue;
        }

        finalCVal = finalCVal / scriptObj.levelDatas.Count;

        finalEVal = finalEVal / scriptObj.levelDatas.Count;

        Vector3 k = conceptObj.transform.localScale;
        k.x = (finalCVal * 5)/100;
        conceptObj.transform.localScale = k;

        Debug.Log(finalCVal);

        Vector3 w = expObj.transform.localScale;
        w.x = (finalEVal * 5) / 100;
        expObj.transform.localScale = w;

        Debug.Log(finalEVal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
