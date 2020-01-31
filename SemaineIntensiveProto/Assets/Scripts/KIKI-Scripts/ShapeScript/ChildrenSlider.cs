using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenSlider : MonoBehaviour
{
    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    private Grid grid;
    RaycastHit hitInfo;
    Ray ray;

    [SerializeField] bool isAboveStatic;
    public bool hasBeenPlaced;
    [HideInInspector] public bool Placing;
    [HideInInspector] public bool Dragging;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();


    }

    private void Update()
    {

        if(Dragging == true)
        {
            GetComponent<Renderer>().material.color = mouseOverColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = originalColor;
        }

    }


}
