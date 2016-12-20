using UnityEngine;
using System.Collections;

public class Perspective_player : Sense_behavior_tree
{

   
    public Material[] mat;
    public int FieldOfView = 45;
    public int ViewDistance = 50;

    private Transform playerTran;
    private Vector3 rayDirection;



    protected override void Initialise() 
    {
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }

	// Update is called once per frame
    protected override int UpdateSense() 
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= detectionRate)
            return   DetectAspect();

        return -1;

    }

    //Detect perspective field of view for the AI Character
     int   DetectAspect()
    {

        RaycastHit hit;
        rayDirection = playerTran.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) < FieldOfView)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, ViewDistance))
            {
                //Debug.Log(hit.collider.GetComponent<Aspect>());
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    //    //Check the aspect
                    if (aspect.aspectName == aspectName)
                    {
               //if (hit.collider.gameObject.tag == "Player")
                            return 0;
                    }
                }
                return 0;
            }
        }
        else
        {
            //SetColor(0);
            return 2;
        }
        return 3;
    }

    /// <summary>
    /// Show Debug Grids and obstacles inside the editor
    /// </summary>
    void OnDrawGizmos()
    {
        if (playerTran == null)
            return;

        Debug.DrawLine(transform.position, playerTran.position, Color.red);

        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);

        //Approximate perspective visualization
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView * 0.5f;

        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView * 0.5f;

        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }

    public void SetColor(int t)
    {
        gameObject.GetComponent<Renderer>().material = mat[t];

         
    }



}
