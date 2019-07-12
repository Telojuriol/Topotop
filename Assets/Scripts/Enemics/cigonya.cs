using UnityEngine;
using System.Collections;

public class cigonya : MonoBehaviour {

    private float temps = 0;
    public GameObject projectil;
    private int costat;
    private float moureT = 2f;
    private GameObject raig;
    private bool raigFet = false;
    void Start()
    {
        costat = (Random.Range(0, 2) * 2 - 1);
        GetComponent<Transform>().position = new Vector3(5.0f * costat, 0, 3);
        moureT = Random.Range(1f, 4f);
        raig = Resources.Load("raig") as GameObject;
        if(costat == 1)
        {
            transform.rotation = Quaternion.Euler(0,270,270);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -270, -270);

        }
    }
    void Update()
    {
        temps += Time.deltaTime;
        Vector3 moviment = new Vector3(0, 0, 0);
        if (temps < moureT)
        {
            moviment = new Vector3(-Time.deltaTime * costat, 0, 0);
        }

        if (temps > moureT && !raigFet)
        {
            transform.Find("bebe").GetComponent<enemic>().enabled = true;
            raigFet = true;
        }
        if (temps > moureT)
        {
            moviment = new Vector3(-Time.deltaTime * costat, 0, Time.deltaTime * 2);
        }


        transform.position = transform.position + moviment;

    }
}
