using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {

	 public float speed;
    public float Vspeed;
    public int mal;
    private GameObject aniExplosio;

    void Start()
    {
        aniExplosio = Resources.Load("explosioFoc") as GameObject;


    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Vspeed*(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x )/(10 * speed), 0.0f, 1);
        GetComponent<Rigidbody>().velocity = movement * speed;
        if(GameObject.FindGameObjectWithTag("Player").transform.position.z < transform.position.z)
            GetComponent<Transform>().rotation = Quaternion.Euler(180, 20 * Mathf.Atan((transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x) / (transform.position.z - GameObject.FindGameObjectWithTag("Player").transform.position.z)), -GetComponent<Transform>().rotation.eulerAngles.z);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(Instantiate(aniExplosio, transform.position, Quaternion.Euler(90, 0, 0)), 5.0f);
            Destroy(this.gameObject);
        }


    }
}
