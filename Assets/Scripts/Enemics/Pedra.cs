using UnityEngine;
using System.Collections;

public class Pedra : MonoBehaviour
{
    public float speed;
    public float mal;

    void Start()
    {
        GetComponent<Transform>().position = new Vector3(Random.Range(-2f, 2f), 0, 20);
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * speed;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere *30;
        if(this.gameObject.name == "Pedravolcanica1(Clone)" || this.gameObject.name == "Pedravolcanica2(Clone)" || this.gameObject.name == "BoladeFoc(Clone)" || this.gameObject.name == "BoladeFocEspai(Clone)")
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 3);

    }

}

