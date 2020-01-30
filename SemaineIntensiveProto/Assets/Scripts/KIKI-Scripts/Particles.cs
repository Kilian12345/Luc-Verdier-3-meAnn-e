using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public float speed;
    public float baseSpeed;
    public float maxSpeed = 10;
    public float speedIncreaseRate = 0.1f;
    public Vector2 dir;

    [Space(10)]
    public float boostSecond;
    public bool colliding;

    [SerializeField] GameObject particleEffect;
    private void Start()
    {
        baseSpeed = speed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.Translate(dir * step);

        if(colliding == true && speed < maxSpeed)
        {
            StartCoroutine(SetBoostTime());
        }
        if (colliding == false && speed > baseSpeed)
        {
            speed -= speedIncreaseRate;
        }
        if(speed < baseSpeed)
        {
            speed = baseSpeed;
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slider")
        {
            dir = collision.gameObject.GetComponent<Slider>().facingDirection;
            colliding = true;
        }

        if (collision.gameObject.tag == "Static")
        {
            if (collision.gameObject.GetComponent<StaticSilder>().hasDirection == true)
            {
                dir = collision.gameObject.GetComponent<StaticSilder>().facingDirection;
                colliding = true;
            }
            else
            {
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        /*else
        {
            colliding = false;
        }*/

    }

  /*  private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slider")
        {
            colliding = true;
        }
        else
        {
            colliding = false;
        }

    }*/

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Slider")
        {
            colliding = false;
        }
        
    }

    IEnumerator SetBoostTime ()
    {
        speed = maxSpeed;
        yield return new WaitForSeconds(boostSecond);
        colliding = false;
    }
}
