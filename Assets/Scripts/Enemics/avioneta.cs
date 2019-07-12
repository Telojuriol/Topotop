using UnityEngine;
using System.Collections;

public class avioneta : MonoBehaviour {

    private float tempsCohets = 2;
    private float temps = 0;
    public GameObject projectil;

    // Use this for initialization
    void Start () {
        Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, 10);
        transform.position = spawnPosition;
        projectil = Resources.Load("projectil") as GameObject;


    }
	
	// Update is called once per frame
	void Update () {
        temps += Time.deltaTime;
        if (temps >= tempsCohets)
        {
            Vector3 projectil1 = new Vector3(0,0,-0.8f);
            GameObject p1 = Instantiate(projectil, transform.position + projectil1, Quaternion.identity) as GameObject;
            p1.GetComponent<projectil>().objectiu = new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z - 100);
            p1.GetComponent<projectil>().activaProjectil();

            temps = 0;
        }
    }
}
