using UnityEngine;
using System.Collections;

public class projectil : MonoBehaviour {
    public Vector3 objectiu;
    public float speed = 10;
    private Vector3 direccio;
    private bool activa = false;
    private GameObject aniExplosio;
    // Use this for initialization
    public void activaProjectil()
    {
        aniExplosio = Resources.Load("explosioFoc") as GameObject;
        Vector3 playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        direccio = new Vector3(objectiu.x - transform.position.x ,objectiu.y - transform.position.y, objectiu.z - transform.position.z);
        direccio.Normalize();
        activa = true;
        transform.LookAt(objectiu);
    }
	// Update is called once per frame
	void Update () {
        if (activa)
        {
            Vector3 moviment = new Vector3(Time.deltaTime * direccio.x, Time.deltaTime * direccio.y, Time.deltaTime * direccio.z);
            transform.position = transform.position + moviment * speed;

        }
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.gameObject.name == "projectil(Clone)")
        {
            Destroy(Instantiate(aniExplosio, transform.position, Quaternion.Euler(90, 0, 0)), 5.0f);
            Destroy(this.gameObject);
        }


    }

}
