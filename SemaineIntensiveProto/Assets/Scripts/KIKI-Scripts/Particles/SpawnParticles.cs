using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{

    public GameObject particle;
    public int spawnNumbers;
    public float frequence;

    [Header("Spawn Attributes")]
    public Vector2 SpawnDirection;
    public float SpawnWidth;

    [Header("Particles Attributes")]
    public float particleSpeed;
    [Range(1, 5)] public float particleSize;
    [Range(1,5)]public float particleColliderSize;

    [HideInInspector] public bool isSpawning;
    [HideInInspector] public int LeftToSpawn;


    GameObject spawnObject;


    // Update is called once per frame
    void Update()
    {
        if (isSpawning == true)
        {
            LeftToSpawn = spawnNumbers;
            StartCoroutine(SpawnRate());
            isSpawning = false;
        }
    }

    IEnumerator SpawnRate()
    {
        for (int i = 1; i <= spawnNumbers; i++)
        {

            yield return new WaitForSeconds(frequence);
            LeftToSpawn -= 1;
            spawnObject = Instantiate(particle, new Vector3(Random.Range(transform.position.x - SpawnWidth, transform.position.x + SpawnWidth), transform.position.y, transform.position.z), Quaternion.identity, transform);
            spawnObject.GetComponent<Particles>().speed = particleSpeed;
            spawnObject.GetComponent<Particles>().dir = SpawnDirection;
            spawnObject.GetComponent<BoxCollider2D>().size *= Random.Range(1, particleColliderSize);
            spawnObject.transform.localScale *= Random.Range(1, particleSize);

        }
    }
}
