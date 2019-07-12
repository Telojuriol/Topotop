using UnityEngine;
using System.Collections;

public class Cuc : MonoBehaviour {
    private int costat;
    private Quaternion angle;
	// Use this for initialization
	void Start () {
        costat = (Random.Range(0, 2) * 2 - 1);
        if(costat == 1)
        {
            angle = Quaternion.Euler(330, 164, 100);
        }
        else {
            angle = Quaternion.Euler(350, 200, 277);
            
        }
        GetComponent<Transform>().position = new Vector3(2.5f * -costat, 0, 7);
        
        GetComponent<Transform>().rotation = angle;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
