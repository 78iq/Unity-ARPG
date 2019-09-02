using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometImpactTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        transform.parent.gameObject.GetComponent<CometBehaviour>().Impact(other.gameObject);
    }
}
