using UnityEngine;
using System.Collections;

public class Anima : MonoBehaviour {

    public float speed;
    public float Vspeed;

  


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Vspeed*(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x )/(10 * speed), 0.0f, 1);
        GetComponent<Rigidbody>().velocity = movement * speed;
        /* if(GameObject.FindGameObjectWithTag("Player").transform.position.z < transform.position.z)
             GetComponent<Transform>().rotation = Quaternion.Euler(GetComponent<Transform>().rotation.eulerAngles.x, 20 * Mathf.Atan((transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x) / (transform.position.z - GameObject.FindGameObjectWithTag("Player").transform.position.z)), GetComponent<Transform>().rotation.eulerAngles.z);*/
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(330, 0, -90 - GetComponent<Rigidbody>().velocity.x * 30);

    }
    

}
