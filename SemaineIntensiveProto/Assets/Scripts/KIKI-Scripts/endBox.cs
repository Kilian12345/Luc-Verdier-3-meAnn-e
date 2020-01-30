using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class endBox : MonoBehaviour
{
    public int numberParticle;
    Grid grid;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        numberParticle = 0;
    }

    private void Update()
    {
        SliderScale();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Particle")
        {
            numberParticle += 1;
            Destroy(collision.gameObject);
        }
    }

    void SliderScale()
    {
        transform.localScale = new Vector3(grid.size, grid.size, grid.size);
    }
}
