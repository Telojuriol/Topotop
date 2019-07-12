using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int i;
   
    public GameObject[] enemics = new GameObject[36];
    public GameObject femella,botiquin,turbo, fuel;
    public GameObject fonsController;
    public GameObject player,infoPartida;
    // Use this for initialization
    private XMLPlayer xml;
    public float spawnWait;
    private bool fi = false;
    private float temps = 0;
    private float tempsFuel = 0;
    public float tempsNivell = 0;
    public float duracioNivell = 30;
    private float puntuacioSegNiv = 20;
    public int nivell = 1;
    public bool nivellPujat = false;
    public float timeForFemelles = 0;
    public bool transicio;
    public float tempsSenseFuel;
    private GameObject musica;
    public Sprite[] imatgesLogros = new Sprite[12];
    private GameObject ImatgeLogros;
    public AudioClip alex, marta;

    void Start()
    {
        xml = new XMLPlayer();

        GameObject.Find("Music").GetComponent<AudioSource>().clip = marta;
        GameObject.Find("Music").GetComponent<AudioSource>().Play();

        

        infoPartida = GameObject.Find("InfoPartida");
        ImatgeLogros = GameObject.Find("/Canvas/Logro");
        musica = GameObject.Find("/Music");
        ImatgeLogros.SetActive(false);
        StartCoroutine(spawnWaves());
		i = (nivell - 1) * 2;
        duracioNivell = duracioNivell * nivell;
        if (nivell == 12) player.GetComponent<playerController>().nivellFinal = true;
    }

    void Update()
    {
        temps += Time.deltaTime* fonsController.GetComponent<fonsController>().velocitat;
        tempsFuel += Time.deltaTime * fonsController.GetComponent<fonsController>().velocitat;
        if (!fonsController.GetComponent<fonsController>().transFons)
            tempsNivell += Time.deltaTime * fonsController.GetComponent<fonsController>().velocitat;
        if(tempsNivell >= duracioNivell)
        {
            fonsController.GetComponent<fonsController>().transFons = true;
        }

        if (nivellPujat)
        {
            if(nivell == 12)player.GetComponent<playerController>().nivellFinal = true;
            if (!player.GetComponent<playerController>().xml.getLogro(nivell - 1))
            {
                infoPartida.GetComponent<InfoPartida>().logro = true;
                player.GetComponent<playerController>().xml.setLogro(nivell - 1);
                if (nivell == 12) player.GetComponent<playerController>().xml.setLogro(nivell);
                ImatgeLogros.GetComponent<Image>().sprite = imatgesLogros[nivell - 2];
                ImatgeLogros.SetActive(true);
                Invoke("treureLogro", 4f);
            }
            duracioNivell = duracioNivell + 20;
            nivellPujat = false;

            if (nivell == 6) {
                GameObject.Find("Music").GetComponent<AudioSource>().clip = alex;
                GameObject.Find("Music").GetComponent<AudioSource>().Play();

            }
            if (nivell == 8) {
                GameObject.Find("Music").GetComponent<AudioSource>().clip = marta;
                GameObject.Find("Music").GetComponent<AudioSource>().Play(); 
            }
            if (nivell == 10)
            {
                GameObject.Find("Music").GetComponent<AudioSource>().clip = alex;
                GameObject.Find("Music").GetComponent<AudioSource>().Play();
            }
        }

    }

    void treureLogro()
    {
        ImatgeLogros.SetActive(false);

    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(0);
        while (true)
        {
            //print("Nivell: "+nivell+"Primer: "+ ((nivell -1) * 3) +" Segon: "+ ((nivell -1) * 3 + 1) + " Tercer: "+ ((nivell-1) * 3 + 2) + " El canvi del fons esta en fase de: "+ fonsController.GetComponent<fonsController>().transFons + " El temps de nivell es; " +tempsNivell + " I la i es: "+ fonsController.GetComponent<fonsController>().iFons);
            Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, 7);
            Quaternion spawnRotation;
            int randEnemic = Random.Range(0, 100);
            if (nivell < 12)
            {
                if (randEnemic >= 0 && randEnemic <= 42)
                {
                    spawnRotation = enemics[(nivell - 1) * 3].GetComponent<Transform>().rotation;
                    Instantiate(enemics[(nivell - 1) * 3], spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(0.5f);
                }
                if (randEnemic >= 43 && randEnemic <= 79)
                {

                    spawnRotation = enemics[(nivell - 1) * 3 + 1].GetComponent<Transform>().rotation;
                    Instantiate(enemics[(nivell - 1) * 3 + 1], spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(0.5f);
                }
                if (randEnemic >= 80 && randEnemic <= 93)
                {

                    spawnRotation = enemics[(nivell - 1) * 3 + 2].GetComponent<Transform>().rotation;
                    Instantiate(enemics[(nivell - 1) * 3 + 2], spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                int enemicFinal = Random.Range(0, 33);
                spawnRotation = enemics[enemicFinal].GetComponent<Transform>().rotation;
                Instantiate(enemics[enemicFinal], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(0.5f);

            }


            if (randEnemic == 97 || randEnemic == 98)
            {

                spawnRotation = botiquin.GetComponent<Transform>().rotation;
                Instantiate(botiquin, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(0.5f);
            }
            if (randEnemic == 99)
            {

                spawnRotation = turbo.GetComponent<Transform>().rotation;
                Instantiate(turbo, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(0.5f);
            }
            if (randEnemic == 94 || randEnemic == 95 || randEnemic == 96)
            {

                spawnRotation = fuel.GetComponent<Transform>().rotation;
                Instantiate(fuel, spawnPosition, spawnRotation);
                tempsFuel = 0;
                yield return new WaitForSeconds(0.5f);
            }

            if (timeForFemelles <= temps)
            {
                spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, 7);
                spawnRotation = Quaternion.identity;
                Instantiate(femella, spawnPosition, spawnRotation);
                timeForFemelles = temps + 1;
            }

            if (tempsFuel >= tempsSenseFuel - 12)
            {
                spawnPosition = new Vector3(Random.Range(-2f, 2f), 0, 7);
                spawnRotation = fuel.GetComponent<Transform>().rotation;
                Instantiate(fuel, spawnPosition, spawnRotation);
                tempsFuel = 0;
            }


        }


    }
}
