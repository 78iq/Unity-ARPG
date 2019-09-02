using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    ActionManager actionManager;
    


    // Start is called before the first frame update
    void Start()
    {
       
        health = 20;
        mana = 10;
        baseMovementSpeed = 5;
        movementSpeedModifier = 1;
        cdr = 0.3f;
        range = 2;

        //initialize pathfinding agent
        agent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>() as UnityEngine.AI.NavMeshAgent;

        agent.autoBraking = true;
        agent.acceleration = 1024;
        agent.angularSpeed = 108000;
        agent.stoppingDistance = 0.5f;
        agent.radius = 0.5f;
        agent.height = 2;
        agent.avoidancePriority = 50;


        //
        actionManager = gameObject.AddComponent<ActionManager>() as ActionManager;
        actionManager.SetUser(gameObject);

        

        //initialize player data



        //initialize comet data
        //


       
    }

    // Update is called once per frame
    void Update()
    {
        //set agents speed every frame
        agent.speed = baseMovementSpeed * movementSpeedModifier;

        
        
        if (actionManager.IsCasting())
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }


        //handle input
        if(Stuff.GetButtonDown("Hotkey1"))
        {
            Vector3 temp = Stuff.Intersect();
            if (!temp.Equals(Vector3.negativeInfinity))
            {
                agent.SetDestination(temp);             
            }          
        }
        if(Stuff.GetButtonDown("Hotkey2"))
        {
            if(actionManager.Use("Action1"))
            {
                //action was used
            }
        }
        if (Stuff.GetButtonDown("Hotkey3"))
        {            
            if(actionManager.Use("Action2"))
            {
                //action was used
            }
        }
    }

    void AddAction(ActionHandler ah)
    {
        actionManager.AddAction(ah);
    }

    void FixedUpdate()
    {

    }
}
