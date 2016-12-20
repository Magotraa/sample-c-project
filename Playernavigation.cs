using UnityEngine;
using System.Collections;

public class Playernavigation : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent navMeshAgent;




	// Use this for initialization
	void Start () {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();

	
	}
	
	// Update is called once per frame
	void Update () {




            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit_;

                if (Physics.Raycast(ray, out hit_))
                {
                    navMeshAgent.SetDestination(hit_.point);
                }



     

        }
    }
}
