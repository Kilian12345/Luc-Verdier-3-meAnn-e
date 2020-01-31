using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCounter : MonoBehaviour
{
    SpawnParticles spawnP;
    endBox endBox;
    public int numberOfParticle;
    int particle;

    bool counting;

    [Space(20)]
    public bool lostAll;
    public bool hasSome;

    // Start is called before the first frame update
    void Start()
    {
        spawnP = FindObjectOfType<SpawnParticles>();
        endBox = FindObjectOfType<endBox>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        particle = GameObject.FindGameObjectsWithTag("Particle").Length;

        numberOfParticle = spawnP.LeftToSpawn + particle;

        if (numberOfParticle <= 0)
        {
            if(endBox.numberParticle == 0) { lostAll = true; hasSome = false; }
            else { hasSome = true; lostAll = false;}
        }
        
    }
}
