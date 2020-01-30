using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endBox : MonoBehaviour
{
    public int numberParticle;

    private void Start()
    {
        numberParticle = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Particle")
        {
            numberParticle += 1;
            Destroy(collision.gameObject);
        }
    }
}
