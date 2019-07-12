using UnityEngine;
using System.Collections;

public class Enano : MonoBehaviour {
    private float y = -4;
    private float maxX;
    private float x;
    private float rotacio = 0;
    private Quaternion angle;
    private int costat;
    // Use this for initialization
    void Start () {
        x = Random.Range(0, 2f);
        costat = (Random.Range(0, 2) * 2 - 1);
        GetComponent<Transform>().position = new Vector3(3.0f * costat, 0, Random.Range(2f, 7f));

    }
	
	// Update is called once per frame
	void Update () {
        
        if (y <= 10)
            y += Time.deltaTime*3;
        rotacio+= Time.deltaTime*40;

        if(costat == 1)
        {
            angle = Quaternion.Euler(230, 140 - rotacio, 75);

        }
        else
        {
            angle = Quaternion.Euler(330, 60 + rotacio, 75);


        }

        GetComponent<Rigidbody>().velocity = new Vector3(1*-costat,0, -y);
        GetComponent<Transform>().rotation = angle;

    }
}
