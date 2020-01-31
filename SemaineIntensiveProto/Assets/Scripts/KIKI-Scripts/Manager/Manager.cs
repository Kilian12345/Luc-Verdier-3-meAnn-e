using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int nbrPiecePose;
    public int nbrPiecePoseP;
    public int nbrPiecePoseC;
    int nbrPieceExistanteParent;
    int nbrPieceExistanteChild;
    ParentDragAndDrop[] PieceExistanteParent;
    DragAndDrop[] PieceExistanteChild;

    public int nbrParticleArrive;
    public int nbrParticleDepart;

    float coefEfficace;
    float coefParticule;
    float Score;
    public bool endGame;
    public bool startGame;
    private bool elonLeVrer;

    public float conceptVal;
    public float expVal;

    [SerializeField] Text text;

    [Space(10)]
    [Header("Timing")]
    public float timePlacementPremier;
    public float timePlay;
    public float time;
    bool placedFirst = false;
    bool StartGameOfficial = false;


    [Space(10)]
    [Header("A remplir")]
    public int nbrOptiamlPiece;
    public int nbrMerdePiece;

    [Space(10)]
    [Header("Data center")]
    [SerializeField] ScripaztbleObj script;
    public int scriptIndex;

    private void Update()
    {

        time += Time.deltaTime;

        nbrPieceExistanteParent = GameObject.FindObjectsOfType<ParentDragAndDrop>().Length;
        nbrPieceExistanteChild = GameObject.FindObjectsOfType<DragAndDrop>().Length;
        PieceExistanteParent = FindObjectsOfType<ParentDragAndDrop>();
        PieceExistanteChild = FindObjectsOfType<DragAndDrop>();

        int pp = 0;
        int pc = 0;

        for (int i = 0; i < nbrPieceExistanteParent; i++)
        {           

            if(PieceExistanteParent[i].transform.localPosition.x <= 1.6f && PieceExistanteParent[i].hasBeenPlaced == true)
            {
                pp += 1;
            }

            nbrPiecePoseP = pp;
        }

        for (int i = 0; i < nbrPieceExistanteChild; i++)
        {
            if (PieceExistanteChild[i].transform.localPosition.x <= 1.6f && PieceExistanteChild[i].hasBeenPlaced == true)
            {
                pc += 1;
            }

            nbrPiecePoseC = pc;
        }

        nbrPiecePose = nbrPiecePoseC + nbrPiecePoseP;


        if (nbrPiecePose == 1 && placedFirst == false)
        {
            placedFirst = true;
            timePlacementPremier = time;
        }
        if (startGame == true && StartGameOfficial == false)
        {
            StartGameOfficial = true;
            timePlay = time;
        }

        if (endGame == true && !elonLeVrer)
        {
            FinalCalcul();

            PlayerSecretStats();

            elonLeVrer = true;
        }
    }

    void FinalCalcul()
    {
        if (nbrPiecePose < nbrOptiamlPiece) nbrPiecePose = nbrOptiamlPiece;
        else if (nbrPiecePose > nbrMerdePiece) nbrPiecePose = nbrMerdePiece;

        coefEfficace = (1 - ((nbrPiecePose - nbrOptiamlPiece) / (nbrMerdePiece - nbrOptiamlPiece))) * 100;
        coefParticule = (float)((float)nbrParticleArrive / (float)nbrParticleDepart) * 100;
        Score = (coefEfficace * coefParticule) / 100;
        Score = Mathf.Round(Score);
        text.text = ("Score :" + Score.ToString());

        script.levelDatas[scriptIndex].score = Score;
        script.levelDatas[scriptIndex].TimeFirstPlace = timePlacementPremier;
        script.levelDatas[scriptIndex].TimeFirstPlay = timePlay;
    }

    void PlayerSecretStats()
    {
        if ((timePlay - timePlacementPremier) < 120f) conceptVal += Score;

        else if (Score == 30) { conceptVal += 20; expVal += 10; }

        else { conceptVal += 10; expVal += 10; }

        script.levelDatas[scriptIndex].conceptValue = conceptVal;
        script.levelDatas[scriptIndex].experimentValue = expVal;
    }
}
