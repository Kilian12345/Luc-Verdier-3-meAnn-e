using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    Material mat;
    private Grid grid;
    RaycastHit hitInfo;
    Ray ray;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        mat = GetComponent<Material>();

        //distance = transform.position;
        PlaceCubeNear(transform.position);
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
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;

        PlaceCubeNear(ray.GetPoint(distance));
        
    }

    void Update()
    {
        if (dragging)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, rayPoint.y, 0);
        }

        SliderScale();
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        transform.position = new Vector3(finalPosition.x, finalPosition.y, 0);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }

    void SliderScale()
    {
        transform.localScale = new Vector3(grid.size, grid.size, grid.size);
    }
}
