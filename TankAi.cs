using UnityEngine;
using System.Collections;

public class TankAi : MonoBehaviour {
    public Material[] mat;
    // General state machine variables
    private GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 6.0f;
    private float currentDistance;
    private Vector3 checkDirection;

    // Patrol state variables
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;


    public NavMeshAgent navMeshAgent;
    //public Camera cam;

    private int currentTarget;
    private float distanceFromTarget;
    private Transform[] waypoints = null;


    // Use this for initialization
    //void Start()
    //{
    //    cam = Camera.main;
    //    navMeshAgent = GetComponent<NavMeshAgent>();


    //}


    ////temp code
    //void update()
    //{

    //    currentTarget++;
    //    if (currentTarget > 3) currentTarget = 0;
    //    navMeshAgent.SetDestination(waypoints[currentTarget].position);




    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit_;

    //        if (Physics.Raycast(ray, out hit_))
    //        {
    //            navMeshAgent.SetDestination(hit_.point);
    //        }



    //    }

    //}



    private void Awake() {
        gameObject.GetComponent<Renderer>().material = mat[0];
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        
        //These are hard-coded values and 
        //pointA = GameObject.Find("p1").transform;       
        //pointB = GameObject.Find("p2").transform;
        //pointC = GameObject.Find("p3").transform;
        //pointD = GameObject.Find("p4").transform;

        // Here we making independent variable or we can say loose couppling
        pointA = pointA.transform;
        pointB = pointB.transform;
        pointC = pointC.transform;
        pointD = pointD.transform;


        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = new Transform[4] {
            pointA,
            pointB,
            pointC,
            pointD
        };
        currentTarget = 0;
        //Debug.Log( waypoints[currentTarget].position);
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
       
    }


    


    private void FixedUpdate() {        
        //First we check distance from the player 
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("distanceFromPlayer", currentDistance);

        //Then we check for visibility
        checkDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, checkDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck)) {
            if(hit.collider.gameObject == player){
                animator.SetBool("isPlayerVisible", true);
            } else {
                animator.SetBool("isPlayerVisible", false);
            }
        } else {
            animator.SetBool("isPlayerVisible", false);
        }

        //Lastly, we get the distance to the next waypoint target
        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
     
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
       
    }

    public void ChangeDestinationPoint() {
        currentTarget++;
        if (currentTarget > 3) currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    public void FollowPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void SetColor(int t)
    {
        gameObject.GetComponent<Renderer>().material = mat[t];
    }


    public void ResumePatrol()
    {
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
}
