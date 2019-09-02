using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : ActionBehaviour
{
    List<GameObject> nearbyBirds;

    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        speed = 3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
