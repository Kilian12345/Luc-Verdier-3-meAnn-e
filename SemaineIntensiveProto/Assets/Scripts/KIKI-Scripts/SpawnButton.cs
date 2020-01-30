using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    private Color mouseOverColor = Color.red;
    private Color originalColor = Color.white;
    SpawnParticles spawnPar;
    bool hasSpawned = false;

    private void Start()
    {
        spawnPar = GetComponentInParent<SpawnParticles>();
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        if (hasSpawned == false)
        {
            spawnPar.isSpawning = true;
            hasSpawned = true;
        }
    }


}
