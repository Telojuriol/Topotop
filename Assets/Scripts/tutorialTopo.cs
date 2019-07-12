using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorialTopo : MonoBehaviour {

    public bool android = true;
    public float tilt;
    public float speed;
    public BarraVida barravida;
    public BarraFuel barrafuel;
    private float moveHorizontal;
    private int screenWidth = 0;
    public GameObject controler;

    public bool detectaMoviment = false;

    void Start()
    {
        screenWidth = Screen.width;
        barravida.setVidaMax(100);
        barrafuel.setFuelMax(100);

    }

    void Update()
    {
        
        if (android) controlsAndroid();
        else controlsPC();

        if (moveHorizontal != 0) detectaMoviment = true;
        else detectaMoviment = false;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, -2, 2), 0.0f, -4.57f);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt * 0.8f);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Femella" && controler.GetComponent<Tutorial>().waiting4Femella)
        {
            Destroy(other.gameObject);
            controler.GetComponent<Tutorial>().waiting4Femella = false;
            GameObject.Find("Canvas/monedas").GetComponent<Text>().text = "15";
        }


        if (other.tag == "Botiquin")
        {
            Destroy(other.gameObject);
            controler.GetComponent<Tutorial>().waiting4Botiquin = false;
            barravida.curaVida(50);
        }


        if (other.tag == "Fuel")
        {
            controler.GetComponent<Tutorial>().waiting4Fuel = false;
            barrafuel.sumaFuel(50);
            Destroy(other.gameObject);
        }


        if (other.tag == "Turbo")
        {
            Destroy(other.gameObject);

        }

        if (other.tag == "Enemic")
        {
            controler.GetComponent<Tutorial>().waiting4Enemic = true;
            barravida.treuVida(30);

        }

    }



    public void treuvida()
    {
        barravida.treuVida(30);

    }

    public void treuFuel()
    {
        barrafuel.treuFuel(30);

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
