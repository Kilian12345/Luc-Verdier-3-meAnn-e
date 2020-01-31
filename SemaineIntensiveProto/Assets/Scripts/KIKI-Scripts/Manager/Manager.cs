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

    [SerializeField] Text text;

    [Space(10)]
    [Header("A remplir")]
    public int nbrOptiamlPiece;
    public int nbrMerdePiece;


    private void Update()
    {
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

        if(endGame == true)
        {
            FinalCalcul();
        }
    }

    void FinalCalcul()
    {
        coefEfficace = (1 - ((nbrPiecePose - nbrOptiamlPiece) / (nbrMerdePiece - nbrOptiamlPiece))) * 100;
        coefParticule = (float)((float)nbrParticleArrive / (float)nbrParticleDepart) * 100;
        Score = (coefEfficace * coefParticule) / 100;
        Score = Mathf.Round(Score);
        text.text = ("Score :" + Score.ToString());
    }

}
