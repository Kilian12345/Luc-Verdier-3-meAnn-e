using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Des());
    }

    IEnumerator Des()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
