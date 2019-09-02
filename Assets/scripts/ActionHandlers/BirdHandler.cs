using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHandler : SpellHandler
{
    private GameObject BirdPrefab;


    void Awake()
    {
        baseCooldown = 0.0f;
        baseActionTime = 0.2f;
        baseDamage = 2.0f;
        currentCooldown = 0.0f;

        BirdPrefab = Resources.Load("Actions/Bird", typeof(GameObject)) as GameObject;
        if (BirdPrefab == null)
        {
            Debug.Log("Error loading Bird from Resources");
        }
    }


    public override bool Instantiate()
    {
        if (currentCooldown <= 0)
        {
            if (user.tag == "Player")
            {
                GameObject bird = Instantiate(BirdPrefab, user.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                bird.GetComponent<BirdBehaviour>().SetUser(user);
                return true;
            }
        }
        return false;
    }
}
