using UnityEngine;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    [Range(0.6f,5f)]public float size = 1f;

    public int gridScale;

    Material mat;
    float textureTillingValue;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material; 
    }

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
        for (float x = transform.position.x; x < transform.position.x + gridScale * 2; x += size)
        {
            for (float y = transform.position.y; y < transform.position.y + gridScale; y += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }

    }

    private void Update()
    {
        GridProp();
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void GridProp()
    {
        textureTillingValue = map(size, 0.6f, 4.6f, 7.67f, 1f);
        mat.SetFloat("_BothTilling", 0.04654941f + (300.8771f - 0.04654941f) / (1 + Mathf.Pow((size / 0.02499663f), 1.028633f)));
    }


}
