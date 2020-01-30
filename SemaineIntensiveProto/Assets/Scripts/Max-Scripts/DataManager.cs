using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int score;

    [Header("Pieces Management")]

    public int usedPieces;

    public int maxPieces;
    public int minPieces;

    private int effCoef;

    [Header("Particules Management")]

    public int savedParticules;

    public int initialParticules;

    private int partCoef;

    [Header("Experimentation Levels Stats")]

    public int numberOfTries;

    public float totalTime;
    public float timeBeforeFirstPiece;

    [Header("One-Try Levels Stats")]

    public int someData;

    public int EfficiencyCoefficient(int used, int min, int max)
    {
        return (1 - ((used - min) / (max - min))) * 100;
    }

    public int ParticuleCoefficient(int saved, int initial)
    {
        return (saved / initial) * 100;
    }

    public int Score(int eCoef, int pCoef, bool selective) // false is the basic calculation
    {
        if (selective) return (eCoef + pCoef) / 2;
        else return eCoef * pCoef;
    }
}

[CreateAssetMenu(fileName = "New DataManager", menuName = "Scriptable Object/DataManager")]
public class DataManager : ScriptableObject
{
    [HideInInspector] public List<LevelData> levelDatas = new List<LevelData>(5);

    public int mentalValue;
    public int experimentValue;

    public int anticipationValue;

    public void PlayerStatsForExpLevel(int tries, float tTime, float fPTime, int score)
    {
        if (tries == 1 && (fPTime / tTime) < 0.5f) mentalValue += score;

        else if (tries == 1) { mentalValue += 1; experimentValue += 1; }

        else experimentValue += score;
    }

    public void PlayerStatsForOneTryLevel()
    {

    }
}
