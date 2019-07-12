using UnityEngine;
using System.Collections;

public class ovni : MonoBehaviour {

    private float temps = 0;

    private int costat;
    private float moureT = 2f;
    private GameObject raig;
    private bool raigFet = false;
    private GameObject aniRaig;

    void Start()
    {
        costat = (Random.Range(0, 2) * 2 - 1);
        GetComponent<Transform>().position = new Vector3(3.0f * costat, 0, Random.Range(1f, 4f));
        moureT = Random.Range(1f, 5f);
        raig = Resources.Load("raig") as GameObject;
        aniRaig = Resources.Load("laser") as GameObject;
    }
    void Update()
    {
        temps += Time.deltaTime;
        Vector3 moviment = new Vector3(0, 0, 0);
        if (temps < moureT)
        {
            moviment = new Vector3(-Time.deltaTime * costat, 0, 0);
        }
        if (temps > moureT + 3 && temps < moureT + 5 && !raigFet)
        {
            //aqui tira el raig
            Destroy(Instantiate(aniRaig, transform.position + new Vector3(-0.15f, 0, -8.5f), Quaternion.Euler(90, 0, 0)), 5.0f);
            Vector3 offset = new Vector3(0, 0, -5);
            Instantiate(raig, transform.position + offset, Quaternion.identity);
            raigFet = true;
        }
        if (temps > moureT + 5)
        {
            moviment = new Vector3(-Time.deltaTime * costat, 0, Time.deltaTime * 2);
        }


        transform.position = transform.position + moviment;

    }
}
