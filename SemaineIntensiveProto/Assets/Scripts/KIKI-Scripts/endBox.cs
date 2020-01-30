using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class endBox : MonoBehaviour
{
    public int numberParticle;
    Grid grid;
    RaycastHit hitInfo;
    Ray ray;
    private float distance;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        numberParticle = 0;
        PlaceCubeNear(transform.position);
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

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        transform.position = new Vector3(finalPosition.x, finalPosition.y, 0);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }
}
