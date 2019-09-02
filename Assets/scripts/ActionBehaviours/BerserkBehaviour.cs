using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkBehaviour : ActionBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (user != null )
        {
            transform.position = user.transform.position;
        }
    }
}
