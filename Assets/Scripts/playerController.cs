using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class playerController : MonoBehaviour
{
    private Text monedas;
    private Text canvasPuntuacio;
    private Text FPS;


    private GameObject barreraInmortal,flareTurbo, bordeVida, bordeFuel;
    private Rigidbody rb;
    private GameObject feedbackFuel, feedbackVida;
    private float moveVertical;

    private GameObject camera, barraFuel;
    private int nivellValorFemella;
    private GameObject infoPartida,arranque;
    public bool nivellFinal = false;
    public int scale = 1;
    public XMLPlayer xml;

    public Boundary boundary;
	public BarraVida barravida;
    public BarraFuel barrafuel;
    public float vida = 75;
    public float fuel = 50;
    public GameObject gameController;
    public int velVertic = 1;
    public bool inmortal = false;
    public bool turbo = false;
    private int resistencia = 5;
    public int nFemelles = 0;
    public GameObject feedbackEnemic;
    public GameObject[] feedbackfemelles = new GameObject[5];
    public float puntuacio = 0;
    public int valorFemella = 50;
    public int valorFuel = 10;
    public int valorBotiquin = 37;
    private float tempsTurbo = 3;
    private bool enverinat = false;
	private float lowvida;
	private float lowfuel;
	//public AudioClip clipMotor, clipOuch, clipFemella, clipBonus, clipLow;
	public AudioSource audioMotor, audioOuch, audioFemella, audioBonus;
    private GameObject[] propulsors = new GameObject[5];

    public bool android = true;
    public float tilt;
    public float speed;
    public AudioClip menu;
    private float moveHorizontal;
    private int screenWidth = 0;

    void Awake()
    {
        camera = GameObject.Find("Main Camera");
		bordeVida = GameObject.Find ("bordeVida");
		bordeFuel = GameObject.Find ("bordeFuel");
        xml = new XMLPlayer();
        int nivellVelocitat = xml.getNivell("Velocitat");
        for (int i = 0; i < 5; i++)
        {
            propulsors[i] = GameObject.Find("/Jugador/Player/topo3/propulsor"+i);
            if (nivellVelocitat != i) propulsors[i].SetActive(false);

        }

        Application.targetFrameRate = -1;
        //Velocitat
        speed = 1.8f + (float)xml.getNivell("Velocitat") * 0.65f;

        //Vida
        vida = vida*Mathf.Pow(2, xml.getNivell("Vida"));
        barravida.setVidaMax (vida);
		lowvida = vida / 5;

        //ValorFemella
        nivellValorFemella = xml.getNivell("Valor");
        valorFemella = valorFemella + nivellValorFemella * 5;

        //ValorFuel
        valorFuel = valorFuel * (int)Mathf.Pow(2, xml.getNivell("ValorFuel"));
        
        //CapacitatFuel
        fuel = fuel * Mathf.Pow(2, xml.getNivell("Capacitat"));
        barrafuel.setFuelMax(fuel);
		lowfuel = fuel / 5;
        GameObject.Find("Game Controller").GetComponent<GameController>().tempsSenseFuel = fuel/2;

        //Resistencia
        resistencia = resistencia * xml.getNivell("Resistencia");

        //TempsTurbo
        tempsTurbo = tempsTurbo + 2*xml.getNivell("Turbo");

        //Arrancada
        if(xml.getNivell("Arrancada") != 0) Invoke("treuBotoArrancada", 4);
        else Invoke("treuBotoArrancada", 0);

        //ValorBotiquin
        valorBotiquin = valorBotiquin + 50* xml.getNivell("Botiquin");


        nFemelles = xml.getMoney();
        monedas = GameObject.Find("/Canvas/monedas").GetComponent<Text>();
        canvasPuntuacio = GameObject.Find("/Canvas/Puntuacio").GetComponent<Text>();
        //FPS = GameObject.Find("/Canvas/FPS").GetComponent<Text>();
        monedas.text = "" + nFemelles;

        feedbackFuel = Resources.Load("feedbackFuel") as GameObject;
        feedbackVida = Resources.Load("feedbackVida") as GameObject;

        barreraInmortal = GameObject.Find("/Jugador/Player/BarreraInmortal");
        flareTurbo = GameObject.Find("/Jugador/Player/engines_turbo");
        barreraInmortal.SetActive(false);
        flareTurbo.SetActive(false);
        infoPartida = GameObject.Find("InfoPartida");
        arranque = GameObject.Find("/Canvas/Arrancada");
        screenWidth = Screen.width;

    }

    void FixedUpdate()
    {
        //FPS.text = "" + (1/ Time.unscaledDeltaTime);
        if (enverinat)
        {
            vida = barravida.treuVida(0.04f);
            comprovaVida();
        }
        puntuacio = puntuacio + Time.deltaTime*100*velVertic;
        canvasPuntuacio.text = "" + (int)puntuacio + " m.";
        if (!inmortal)
            fuel = barrafuel.GetComponent<BarraFuel> ().treuFuel (0.04f);
        comprovaFuel();
		feedbacklowlifefuel();


        if (android) controlsAndroid();
        else controlsPC();


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, -2, 2), 0.0f, -4.57f);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt * 0.8f);


    }


    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Femella")
        {
            Destroy(other.gameObject);
            if (turbo)
            {
                nFemelles += 10;
                xml.sumaMonedas(10);
            }
            else
            {
                nFemelles += valorFemella;
                xml.sumaMonedas(valorFemella);
            }            
			Vector3 Position = new Vector3 (0, 4, 1);
			Position = Position + GetComponent<Rigidbody> ().position;
			Destroy (Instantiate (feedbackfemelles[nivellValorFemella], Position, feedbackfemelles[nivellValorFemella].GetComponent<Transform>().rotation), 0.5f);
            monedas.text = "" + nFemelles;
			audioFemella.GetComponent<AudioSource>().Play();
        }


        if (other.tag == "Botiquin")
        {
            Destroy(other.gameObject);
            vida = vida + valorBotiquin;
            Destroy(Instantiate(feedbackVida, other.transform.position, feedbackFuel.transform.rotation), 4);
            barravida.curaVida(valorBotiquin);
			audioBonus.GetComponent<AudioSource>().Play();
        }


        if (other.tag == "Fuel")
        {
            Vector3 offset = new Vector3(0.05f,0.6f,0.5f);
            Destroy(other.gameObject);
            Destroy(Instantiate(feedbackFuel, other.transform.position, feedbackFuel.transform.rotation),4);
            fuel = fuel + valorFuel;
            fuel = barrafuel.GetComponent<BarraFuel>().sumaFuel(valorFuel);
			audioBonus.GetComponent<AudioSource>().Play();
        }


        if (other.tag == "Turbo" && !turbo)
        {
            Destroy(other.gameObject);
            Time.timeScale = 5;
            scale = 5;
            inmortal = true;
            turbo = true;
            barreraInmortal.SetActive(true);
            barreraInmortal.GetComponent<twinker>().stopTwinkle();
            flareTurbo.SetActive(true);
            camera.GetComponent<MotionBlur>().enabled = true;
            speed = (1.5f + (float)xml.getNivell("Velocitat") * 1.5f) / 5;
            Invoke ("defaultVelocity",4 * 5);

        }

        if (other.tag == "Enemic" && !inmortal)
        {

                Vector3 Position = new Vector3(-0.5f, 4, 0.8f);
                Position = Position + GetComponent<Rigidbody>().position;
                Quaternion Rotation = Quaternion.identity;
                Destroy(Instantiate(feedbackEnemic, Position, Rotation), 0.5f);
                if (other.name == "CucVerd(Clone)" || other.name == "CucLila(Clone)")
                {
                    enverinat = true;
                    Invoke("curaEnverinament", 10);
                }
                var obj = this.transform.parent;
                obj.GetComponent<Animation>().CrossFade("fbkenem");
                int malTot = other.gameObject.GetComponent<enemic>().mal - resistencia;
                if (malTot < 0) malTot = 0;
                if (nivellFinal) malTot = 200;
                vida = barravida.treuVida(malTot);
                other.gameObject.GetComponent<enemic>().mal = 0;
                comprovaVida();
				audioOuch.GetComponent<AudioSource>().Play();
                
            
        }

    }
	void defaultVelocity(){
        Time.timeScale = 1;
        scale = 1;
        Invoke("mortal",4);
        Invoke("twinkInmortal", 1);
        flareTurbo.SetActive(false);
        speed = 1.5f + (float)xml.getNivell("Velocitat") * 1.5f;
        turbo = false;
        camera.GetComponent<MotionBlur>().enabled = false; 
    }

    void comprovaVida()
    {
        if (vida <= 0)
        {
            if (xml.checkRecord((int)puntuacio))
            {
                infoPartida.GetComponent<InfoPartida>().record = true;
            }
            infoPartida.GetComponent<InfoPartida>().puntuacio = (int)puntuacio;
            infoPartida.GetComponent<InfoPartida>().motiuMort = 1;
            xml.guardaDades();
            Application.LoadLevel("GameOver");
        }
    }

    void comprovaFuel()
    {
        if (fuel <= 0)
        {

            if (xml.checkRecord((int)puntuacio))
            {
                infoPartida.GetComponent<InfoPartida>().record = true;
            }
            infoPartida.GetComponent<InfoPartida>().puntuacio = (int)puntuacio;
            infoPartida.GetComponent<InfoPartida>().motiuMort = 2;
            xml.guardaDades();
            GameObject.Find("Music").GetComponent<AudioSource>().clip = menu;
            GameObject.Find("Music").GetComponent<AudioSource>().Play();
            Application.LoadLevel("GameOver");

        }
    }

    void treuBotoArrancada()
    {
        arranque.SetActive(false);

    }

    public void activaArrancada()
    {

        Time.timeScale = 20;
        scale = 20;
        inmortal = true;
        flareTurbo.SetActive(true);
        turbo = true;
        barreraInmortal.SetActive(true);
        speed = (1.5f + (float)xml.getNivell("Velocitat") * 1.5f) / 20;
        camera.GetComponent<MotionBlur>().enabled = true;
        Invoke("defaultVelocity", 2.5f * Mathf.Pow(2, xml.getNivell("Arrancada"))  * 20);

        treuBotoArrancada();
    }

    void mortal()
    {
        if (!turbo)
        {
            inmortal = false;
            barreraInmortal.GetComponent<twinker>().stopTwinkle();
            barreraInmortal.SetActive(false);
        }
        
    }

    void curaEnverinament()
    {
        enverinat = false;

    }


    void twinkInmortal()
    {
        if (!turbo)
            barreraInmortal.GetComponent<twinker>().startTwinkle();
    }
	void feedbacklowlifefuel(){
		if (vida <= lowvida) {
			bordeVida.GetComponent<Animator>().enabled = true;
		} else {
			bordeVida.GetComponent<Animator>().enabled = false;
			bordeVida.GetComponent<Image>().color = Color.white;

		}
		if (fuel <= lowfuel) {
			bordeFuel.GetComponent<Animator>().enabled = true;
		} else {
			bordeFuel.GetComponent<Animator>().enabled = false;
			bordeFuel.GetComponent<Image>().color = Color.white;
		}
	}


    void controlsAndroid()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch myTouch = Input.GetTouch(i);
                if (moveHorizontal != 0)
                {
                    if (myTouch.position.x - (screenWidth / 2) < transform.position.x && moveHorizontal == 1)
                    {

                        moveHorizontal = 0;
                        break;
                    }
                    if (myTouch.position.x - (screenWidth / 2) > transform.position.x && moveHorizontal == -1)
                    {

                        moveHorizontal = 0;
                        break;
                    }

                }
                else
                {

                    if (myTouch.position.x - (screenWidth / 2) > transform.position.x) moveHorizontal = 1;
                    if (myTouch.position.x - (screenWidth / 2) < transform.position.x) moveHorizontal = -1;
                }

                if (myTouch.phase == TouchPhase.Ended) moveHorizontal = 0;

            }
        }
        else {
            moveHorizontal = 0;
        }


    }


    void controlsPC()
    {
        moveHorizontal = Input.GetAxis("Horizontal");


    }


}

