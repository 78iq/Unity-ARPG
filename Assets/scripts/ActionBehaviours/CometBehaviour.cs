using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBehaviour : ActionBehaviour
{


    IEnumerator DelayedDestroy(float time, GameObject g)
    {
        yield return new WaitForSeconds(time);
        Destroy(g);
    }

    private Vector3 destination;
    public void SetDestination(Vector3 d)
    { destination = d; }    

    private bool collidedWithEnvironment;


    void Start()
    {        
        collidedWithEnvironment = false;
    }

    void Update()
    {
        if (!collidedWithEnvironment)
        {
            transform.position += Vector3.Normalize(destination - transform.position) * Time.deltaTime * 60;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)   //8 = environment
        {
            collidedWithEnvironment = true;
            //guarantee no desync in location
            transform.position = destination;
            //stop the trail
            transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
            //start the aftershock animation
            transform.GetChild(2).GetComponent<ParticleSystem>().Play();


            StartCoroutine(DelayedDestroy(0.2f, transform.GetChild(0).gameObject));
            StartCoroutine(DelayedDestroy(0.2f, transform.GetChild(3).gameObject));
            StartCoroutine(DelayedDestroy(0.5f, gameObject));
        }
    }

    internal void Impact(GameObject other)
    {
        if (user != null)
        {
            if (user.tag == "Player")
            {
                if (other.tag == "Enemy")
                {
                    Debug.Log("Enemy hit by Player");
                }
            }
        }
    }
}
