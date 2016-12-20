using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {
    public GameObject chp;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Text>().text = chp.name + ":" + chp.GetComponent<PlayerData>().m_chp.HP;
    }

    // Update is called once per frame
    void Update () {
        if (chp)
        {
            //GetComponent<Text>().text = chp.name + ":" + chp.GetComponent<PlayerData>().m_chp.HP;
            Vector3 first =
                       Camera.main.GetComponent<Camera>().WorldToScreenPoint(chp.transform.position);

            this.transform.position = first;
        }
        else
            Destroy(gameObject);
    }
}
