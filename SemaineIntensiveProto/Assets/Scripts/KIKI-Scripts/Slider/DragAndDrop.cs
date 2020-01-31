using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DragAndDrop : MonoBehaviour
{
    Manager mana;
    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    Material mat;
    private Grid grid;
    RaycastHit hitInfo;
    Ray ray;

    [SerializeField] bool isAboveStatic;
    public bool hasBeenPlaced;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        mat = GetComponent<Material>();
        mana = FindObjectOfType<Manager>();

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
        hasBeenPlaced = true; // Data manger
        dragging = false;

        PlaceCubeNear(ray.GetPoint(distance));

        if (isAboveStatic == true)
        {
            PlaceCubeNear(ray.GetPoint(distance) + new Vector3(1, 0, 0));

        }
    }

        void Update()
        {
            if(mana.startGame == true)
            {
                dragging = false;
            }

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

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Static")
            {
                isAboveStatic = true;
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Static")
            {
                isAboveStatic = false;
            }
        }
    

}
