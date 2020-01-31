using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StaticSilder : MonoBehaviour
{
    public bool hasDirection;
    public Vector2 facingDirection;

    Grid grid;
    RaycastHit hitInfo;
    Ray ray;
    private float distance;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();

        PlaceCubeNear(transform.position);
    }

    private void Update()
    {
        SliderScale();
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
