using UnityEngine;
using System.Collections;

public class Sense_behavior_tree : MonoBehaviour {


    private NavMeshAgent[] navAgents;
    private Transform playerTr;
    public Transform TargetTr_start;
    public Transform TargetTr_End;


    public bool bDebug = true;
    public Aspect.aspect aspectName = Aspect.aspect.Player;
    public float detectionRate = 1.0f;
    public float distance_player = 0.0f;
    public int decision;

    protected float elapsedTime = 0.0f;

    protected virtual void Initialise() { }
    protected virtual int UpdateSense() { return -1; }
    //public Fuzzzy_movement(const int Visible) {return -1 ; }

    // Use this for initialization
    void Start () {
		elapsedTime = 0.0f;
		Initialise();


        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //move sphere towards the Kitten's position.
    void UpdateTargets(Vector3 targetPosition)
    {
        foreach (NavMeshAgent agent in navAgents)
        //NavMeshAgent agent = navAgents[];
        //for (int i = 0; i < 1; i++)
        {
            agent.destination = targetPosition;

        }
    }

    //// behaviour tree code for the sphere AI object 
    //
    //

    // Update is called once per frame
    void Update()
    {


        //if (UpdateSense()==0)  // means the ball can see the player 
        //NavMeshAgent agent = navAgents[5];

        foreach (NavMeshAgent agent in navAgents)
        //NavMeshAgent agent = navAgents[];
        //for (int i = 0; i < 1; i++)
        {
            //agent.destination = targetPosition;




            distance_player = agent.transform.position.z - playerTr.transform.position.z;

            // behaviour tree code for the sphere AI object 

            decision = Fuzzzy_movement(UpdateSense(), distance_player);

            if (decision == 0)
            {
                UpdateTargets(playerTr.position); // move towards the Player character
            }
            else if (decision == -2)
            {
                UpdateTargets(TargetTr_start.position);  // move towards the starting point of the plane start.

            }

            else
            {
                // do nothing and stand still where you are
            }

        }

    }

    //fuzzy algorith code to decide if the character should move toward the player or away from the player. 
    //
    //
    //
     int Fuzzzy_movement( int Visible, float distance)
    {

        if (Visible ==0)
        {
            return 0;
        }
        else if (Visible != 0  && (0.0f < distance  && distance < 1.5f))
            {

            return 0;
        }

        else if (Visible == 0 && distance < 1.0f)
        {

            return 0;

        }

        else if (Visible != 0 && distance > 10.0f)
        {

            return -2;//

        }


        else
        {

            return -2;
        }



        
    }

}
