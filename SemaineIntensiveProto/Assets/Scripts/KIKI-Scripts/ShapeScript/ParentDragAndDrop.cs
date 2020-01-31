﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    public Material[] mat;
    public ChildrenSlider[] sliders;
    private Grid grid;
    RaycastHit hitInfo;
    Ray ray;
    Manager mana;

    [SerializeField] bool isAboveStatic;
    public bool hasBeenPlaced;

    private void Start()
    {
        mana = FindObjectOfType<Manager>();
        grid = FindObjectOfType<Grid>();
        PlaceCubeNear(transform.position);
    }

    void OnMouseEnter()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].Dragging = true; ;
        }
    }

    void OnMouseExit()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].Dragging = false; 
        }
    }

    void OnMouseDown()
    {
        dragging = true;

        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].Placing = false;
        }

        hasBeenPlaced = false;
    }

    void OnMouseUp()
    {
        dragging = false;

        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].Placing = true;
        }

        if (mana.startGame == false)
        {
            hasBeenPlaced = true;
            PlaceCubeNear(ray.GetPoint(distance));
        }
    }

    void Update()
    {

        if (mana.startGame == true)
        {
            dragging = false;
        }

        if (dragging)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            transform.position = new Vector3(rayPoint.x, rayPoint.y, 0);
        }

        //SliderScale();
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
