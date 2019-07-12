using UnityEngine;
using System.Collections;

public class peixGlobus : MonoBehaviour {

    private float temps = 0;
    public GameObject projectil;
    private int costat;
    private float explosio = 2f;
    private GameObject aniExplosio;

    void Start()
    {
        aniExplosio = Resources.Load("explosioPeixAigua") as GameObject;
        projectil = Resources.Load("punxa") as GameObject;
        costat = (Random.Range(0, 2) * 2 - 1);
        GetComponent<Transform>().position = new Vector3(3.0f * costat, 0, Random.Range(-1.5f, 4f));
        GetComponent<Transform>().rotation = Quaternion.Euler(330, 90,75);
        if (costat == 1)
            GetComponent<Transform>().rotation = Quaternion.Euler(230, 78, 88);
        explosio = Random.Range(1f,5f);
    }
	void Update () {
        temps += Time.deltaTime;
        Vector3 moviment = new Vector3(-Time.deltaTime*costat,0,0);
        transform.position = transform.position + moviment;
        if (temps >= explosio)
        {
            Destroy(Instantiate(aniExplosio, transform.position, Quaternion.Euler(90, 0, 0)), 5.0f);
            GameObject p1 = Instantiate(projectil,transform.position,Quaternion.identity) as GameObject;
            p1.GetComponent<projectil>().objectiu = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
            p1.GetComponent<projectil>().activaProjectil();

            GameObject p2 = Instantiate(projectil, transform.position, Quaternion.identity) as GameObject;
            p2.GetComponent<projectil>().objectiu = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z-100);
            p2.GetComponent<projectil>().activaProjectil();

            GameObject p3 = Instantiate(projectil, transform.position, Quaternion.identity) as GameObject;
            p3.GetComponent<projectil>().objectiu = new Vector3(transform.position.x, transform.position.y, transform.position.z - 100);
            p3.GetComponent<projectil>().activaProjectil();

            GameObject p4 = Instantiate(projectil, transform.position, Quaternion.identity) as GameObject;
            p4.GetComponent<projectil>().objectiu = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z-100);
            p4.GetComponent<projectil>().activaProjectil();

            GameObject p5 = Instantiate(projectil, transform.position, Quaternion.identity) as GameObject;
            p5.GetComponent<projectil>().objectiu = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
            p5.GetComponent<projectil>().activaProjectil();

            Destroy(gameObject);

        }
    }
}
