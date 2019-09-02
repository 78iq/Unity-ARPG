using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometHandler : SpellHandler
{
    private GameObject CometPrefab;

    public override bool Instantiate()
    {
        if (currentCooldown <= 0)
        {
            if (user.tag == "Player")
            {
                Vector3 temp = Stuff.Intersect();
                if (!temp.Equals(Vector3.negativeInfinity))
                {
                    GameObject comet = Instantiate(CometPrefab, temp + new Vector3(0, 20, 0), Quaternion.identity);
                    comet.GetComponent<CometBehaviour>().SetDestination(temp);
                    comet.GetComponent<CometBehaviour>().SetUser(user);

                    StartCoroutine(Cooldown());

                    //rotate player towards cursor
                    StartCoroutine(RotateUser(Quaternion.LookRotation( new Vector3(temp.x - transform.position.x, 0, temp.z - transform.position.z), Vector3.up)));
                }
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        baseCooldown = 4.0f;
        baseActionTime = 0.3f;
        baseDamage = 10.0f;
        currentCooldown = 0.0f;

        CometPrefab = Resources.Load("Actions/Comet", typeof(GameObject)) as GameObject;
        if (CometPrefab == null)
        {
            Debug.Log("Error loading Comet from Resources");
        }
    }
}
