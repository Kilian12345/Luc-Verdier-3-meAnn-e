﻿using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = transform.position.x; x < transform.position.x + 40; x += size)
        {
            for (float y = transform.position.y; y < transform.position.y + 40; y += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }
    }
}