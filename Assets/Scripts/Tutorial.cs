using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    GameObject dialeg;
    GameObject nextButton;
    GameObject continueButton;
    GameObject TutoGen;
    GameObject fFemelles,fFemella,fVida,fFuel;
    
    public GameObject femella, botiquin, turbo, fuel,enemic;
    int torn = 0;
    public bool waiting4Femella = false;
    public bool waiting4Enemic = false;
    public bool waiting4Botiquin = false;
    public bool waiting4Fuel = false;
    public bool waiting4Movement = false;
    public GameObject jugador;
    public GameObject instruccions;
    private Object fuelImatge;
    private XMLPlayer xml;
    // Use this for initialization
    void Awake () {
        xml = new XMLPlayer();
        Time.timeScale = 0;
        fFemella = GameObject.Find("Canvas/DialegTutorialTopo/FlechaFemella");
        fFemelles = GameObject.Find("Canvas/DialegTutorialTopo/FlechaFemelles");
        fVida = GameObject.Find("Canvas/DialegTutorialTopo/FlechaVida");
        fFuel = GameObject.Find("Canvas/DialegTutorialTopo/FlechaFuel");
        fFemella.SetActive(false);
        fFemelles.SetActive(false);
        fVida.SetActive(false);
        fFuel.SetActive(false);
        dialeg = GameObject.Find("Canvas/DialegTutorialTopo/Text");
        nextButton = GameObject.Find("Canvas/DialegTutorialTopo/Next");
        continueButton = GameObject.Find("Canvas/DialegTutorialTopo/Continue");
        TutoGen = GameObject.Find("Canvas/DialegTutorialTopo");
        dialeg.GetComponent<Text>().text = "Welcome to Topotop! I'm Tom, and I'm gonna teach you how to survive in that universe! Press Next to continue.";
        continueButton.SetActive(false);
        instruccions.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        
        if(torn == 2 && jugador.GetComponent<tutorialTopo>().detectaMoviment && waiting4Movement)
        {
            torn++;
            dialeg.GetComponent<Text>().text = "Well done! You have learned how to move!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            Invoke("activaDialeg",4f);

        }


    }


    public void nextbutton()
    {
        torn++;
        if (torn == 1)
        {
            dialeg.GetComponent<Text>().text = "We are gonna start learning the basic movement. Press on the sides of the screen to move.";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
        }
        if (torn == 4)
        {
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(femella, spawnPosition, spawnRotation);
            waiting4Femella = true;
            fFemella.SetActive(true);
            dialeg.GetComponent<Text>().text = "Look! It has appeared something on the screen! It's a nut, try to catch it!";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
        }
        if (torn == 6)
        {
            fFemelles.SetActive(true);
			dialeg.GetComponent<Text>().text = "At the top right of the screen you can see the number of nuts that you have.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
        }
        if (torn == 7)
        {
            fFemelles.SetActive(false);
            dialeg.GetComponent<Text>().text = "The nuts are the basic coin of this universe. You can use the nuts to improve the rocket: velocity, resistance to damage, maximum life, etc...";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
        }
        if (torn == 8)
        {
			dialeg.GetComponent<Text> ().text = "At the main menu you will find the upgrade menu, there is where you can spend the nuts to improve your equipment.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
        }
        if (torn == 9)
        {
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemic, spawnPosition, spawnRotation);
            fFemella.SetActive(true);
            dialeg.GetComponent<Text>().text = "An obstacle has appeared! Dodge it! Hurry!";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
        }
        if (torn == 11)
        {
            if (!waiting4Enemic) jugador.GetComponent<tutorialTopo>().treuvida();
            dialeg.GetComponent<Text>().text = "If you hit an obstacle It will reduce your health. You can see the actual life that you have at the top left of the screen.";
            fVida.SetActive(true);
            nextButton.SetActive(true);
            continueButton.SetActive(false);
        }
        if (torn == 12)
        {
            fFemella.SetActive(true);
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(botiquin, spawnPosition, botiquin.transform.rotation);
            waiting4Botiquin = true;
            dialeg.GetComponent<Text>().text = "To heal yourself, try catching the first-aid kit.";
            fVida.SetActive(false);
            nextButton.SetActive(false);
            continueButton.SetActive(true);
        }
        if (torn == 14)
        {
            dialeg.GetComponent<Text>().text = "You will find many differend kind of obstacles while you advance during your journey. Be careful, for god's sake!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 15)
        {
            fFuel.SetActive(true);
            jugador.GetComponent<tutorialTopo>().treuFuel();
			dialeg.GetComponent<Text> ().text = "See that there is a fuel bar too. You will lose fuel progressively as you advance, when it reaches 0, your travell will end. (And the mole will die forever).";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 16)
        {
            fFuel.SetActive(false);
            fFemella.SetActive(true);
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(fuel, spawnPosition, fuel.transform.rotation);
            waiting4Fuel = true;
            dialeg.GetComponent<Text>().text = "To recover fuel, reach the fuel-tanks. It is important if you wanna go far! Now, try it!";
            nextButton.SetActive(false);
            continueButton.SetActive(true);

        }
        if (torn == 18)
        {
            dialeg.GetComponent<Text>().text = "If you run out of life or fuel, you will lose and you'll have to restart!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 19)
        {
            fFemella.SetActive(true);
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            fuelImatge = Instantiate(turbo, spawnPosition, turbo.transform.rotation);
            dialeg.GetComponent<Text>().text = "You will find turbo too, that are useful to speed up during a limited time. During this time you will be inmune to damage, but you still can catch bonifications!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 20)
        {
            fFemella.SetActive(false);
            Destroy(fuelImatge);
            dialeg.GetComponent<Text>().text = "We recommend you to try to catch the maximum of nuts that you can, so you can improve and advance more on each run. Upgrading your rocket is essential!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 21)
        {
            dialeg.GetComponent<Text>().text = "In conclusion, try to catch all the bonifications that you can and upgrade all that you can of the rocket.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 22)
        {
            dialeg.GetComponent<Text>().text = "As you advance throught the game, you will find new zones, and unlock special content in the guide. You can find it at the bottom right of the main menu.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 23)
        {
			dialeg.GetComponent<Text>().text = "Now you know all that you need to play Topotop. If you want to play the tutorial again, go to the settings menu, at the bottom right of the main menu.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);

        }
        if (torn == 24)
        {
            dialeg.GetComponent<Text>().text = "I wish you good luck. Help me to reach the top!";
            nextButton.SetActive(false);
            continueButton.SetActive(true);

        }
    }


    public void continuebutton()
    {
        Time.timeScale = 1;
        torn++;
        TutoGen.SetActive(false);
        if (torn == 2) {
            instruccions.SetActive(true);
            Invoke("waitMovementNow", 1);
        }
        if (torn == 5)
        {
            Invoke("femellaAgafada",4);

        }

        if (torn == 10)
        {
            Invoke("enemicEsquivat", 4);

        }
        if (torn == 13)
        {
            
            Invoke("botiquinAgafat", 4);

        }
        if (torn == 17)
        {

            Invoke("fuelAgafat", 4);

        }
        if (torn == 25)
        {
            if (xml.firstPlay())
            {
                xml.firstPlayPlayed();
                Application.LoadLevel("menus");

            }
            else
            {
                Application.LoadLevel("Ajustes");

            }

        }
    }
    void activaDialeg()
    {
        if(torn == 3) instruccions.SetActive(false);
        TutoGen.SetActive(true);
        Time.timeScale = 0f;

    }

    void enemicEsquivat()
    {
        fFemella.SetActive(false);
        if (waiting4Enemic)
        {
			dialeg.GetComponent<Text> ().text = "Well,  It has touched you and reduced your health!";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            activaDialeg();

        }
        else{
            dialeg.GetComponent<Text>().text = "Well done! It hasn't touched you";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            activaDialeg();
        }

    }

    void waitMovementNow()
    {
        waiting4Movement = true;
    }

    void femellaAgafada()
    {
        fFemella.SetActive(false);
        if (waiting4Femella)
        {
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(femella, spawnPosition, spawnRotation);
            waiting4Femella = true;
            torn--;
            dialeg.GetComponent<Text>().text = "Try again! Catch the nut!";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            activaDialeg();

        }
        else
        {
            

            dialeg.GetComponent<Text>().text = "Well done! The nuts are useful to upgrade the rocket.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            activaDialeg();
        }

    }

    void botiquinAgafat()
    {
        fFemella.SetActive(false);
        if (waiting4Botiquin)
        {
           


            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(botiquin, spawnPosition, botiquin.transform.rotation);
            waiting4Botiquin = true;
            torn--;
            dialeg.GetComponent<Text>().text = "Try reaching the first-aid kit to heal yourself.";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            activaDialeg();

        }
        else
        {

            dialeg.GetComponent<Text>().text = "Well done! You have recovered health and now you have it at the maximum.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            activaDialeg();

        }

    }


    void fuelAgafat()
    {
        fFemella.SetActive(false);
        if (waiting4Fuel)
        {
            Vector3 spawnPosition = new Vector3(0.5f, 0, 2.8f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(fuel, spawnPosition, fuel.transform.rotation);
            waiting4Botiquin = true;
            torn--;
            dialeg.GetComponent<Text>().text = "Try to catch the fuel tank to recover fuel.";
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            activaDialeg();

        }
        else
        {

            dialeg.GetComponent<Text>().text = "Well done! You have recovered fuel and now you have It at the maximum again.";
            nextButton.SetActive(true);
            continueButton.SetActive(false);
            activaDialeg();

        }

    }

    public void goMenu()
    {
        Time.timeScale = 1;
        if (xml.firstPlay())
        {
            xml.firstPlayPlayed();
            Application.LoadLevel("menus");

        }
        else
        {
            Application.LoadLevel("Ajustes");

        }
        

    }

}
