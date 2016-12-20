using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour 
{
    public Vector3 tarPos;
    

    private float movementSpeed = 5.0f;
    private float rotSpeed = 2.0f;
    public float minX, maxX, minZ, maxZ, minmaxY;

	// Use this for initialization
	void Start () 
    {
        //minX = -45.0f;
        //maxX = 45.0f;

        //minZ = -45.0f;
        //maxZ = 45.0f;
        //minX = 50f;
        //maxX = 227f;

        //minZ = -650.0f;
        //maxZ = -350f;
        ////minmaxY  = - 16.5f;

        //tarPos.x = 268;
        //tarPos.y = -60;
        //tarPos.z = -469;



        //Get Wander Position
        GetNextPosition();
    }
	
	// Update is called once per frame
	void Update () 
    {

        if (Vector3.Distance(tarPos, transform.position) <= 5.0f)
            GetNextPosition();

        Quaternion tarRot = Quaternion.LookRotation(tarPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
	}

    void GetNextPosition()
    {
        tarPos = new Vector3(Random.Range(minX, maxX), minmaxY , Random.Range(minZ, maxZ));
    }
}