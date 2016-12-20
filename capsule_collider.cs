using UnityEngine;
using System.Collections;

public class capsule_collider : MonoBehaviour {




    void OnTriggerEnter(Collider other)
    {
                print("Enemy Touch Detected");
                System.Console.WriteLine("Enemy  Touch Detected");

                if (other.gameObject.tag == "Player")
                {
                    Destroy(other.gameObject);
                }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
