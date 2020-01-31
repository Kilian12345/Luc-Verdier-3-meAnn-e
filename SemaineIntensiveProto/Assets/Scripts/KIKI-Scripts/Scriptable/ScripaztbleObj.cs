using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelData
{
    public float score;
    public float TimeFirstPlace;
    public float TimeFirstPlay;

    public float conceptValue;
    public float experimentValue;
}

[CreateAssetMenu(fileName = "New Scriptable", menuName = "Scriptable Object")]
public class ScripaztbleObj : ScriptableObject
{
    public List<LevelData> levelDatas;
}
