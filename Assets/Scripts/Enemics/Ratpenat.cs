using UnityEngine;
using System.Collections;

public class Ratpenat : MonoBehaviour {
    private float y = -4;
    private float maxX;
    private float x;
    private Quaternion angle;
    private int costat;

    void Start()
    {
        x = Random.Range(0, 2f);
        costat = (Random.Range(0, 2) * 2 - 1);
        GetComponent<Transform>().position = new Vector3(3.0f * costat, 0, Random.Range(2f, 7f));
        if (costat == 1)
            angle = Quaternion.Euler(-17, -18, 216);
        else
            angle = Quaternion.Euler(-17, 18, 143);

        GetComponent<Transform>().rotation = angle;
    }

    void FixedUpdate()
    {

        if (y <= 6)
            y += 0.1f;
      

      

        GetComponent<Rigidbody>().velocity = new Vector3(1 * -costat, 0, -y);
       

    }
}
