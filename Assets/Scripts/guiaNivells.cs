using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class guiaNivells : MonoBehaviour {

    private XMLPlayer xml;
    public Sprite[] nivells = new Sprite[12];
    private GameObject pantallaNivell;
    // Use this for initialization
    void Awake()
    {
        xml = new XMLPlayer();
        pantallaNivell = GameObject.Find("/Canvas/PantallaNivell");
        pantallaNivell.SetActive(false);

        for (int i = 0; i < xml.getNumLogros(); i++)
        {
            if (xml.getLogro(i + 1))
            {
                GameObject.Find("/Canvas/ScrollRect/Nivells/"+(i+1)).GetComponent<Image>().sprite = nivells[i];
            }

        }

    }

    // Update is called once per frame


    public void tornaGuia()
    {
        Application.LoadLevel("Guia");
    }

    public void menuEnemic()
    {

        if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name != "unlocked")
        {
            pantallaNivell.SetActive(true);
            int i = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            GameObject.Find("/Canvas/PantallaNivell/Image").GetComponent<Image>().sprite = nivells[i - 1];
            GameObject.Find("/Canvas/PantallaNivell/Name").GetComponent<Text>().text = getNivellName(i);
            GameObject.Find("/Canvas/PantallaNivell/Description").GetComponent<Text>().text = getNivellDescription(i);

        }


    }
    public void closeMenuEnemics()
    {
        pantallaNivell.SetActive(false);

    }

    public string getNivellDescription(int i)
    {
        string retorn = "";
        switch (i)
        {
            case 1: retorn = "It's near the center of the earth, and there isn't dinosaurs anywhere. Maybe Jules Verne lied us."; break;
            case 2: retorn = "There are rocks and a lot of fire. You should buy a fan and an umbrella or you will cry like when you were 5 years and you were punished without dessert."; break;
            case 3: retorn = "It's a simple stage with poisonous worms and rocks. There's nothing to say. Well, you won't see antidote anywhere, so try to dodge all."; break;
            case 4: retorn = "Fire, ashes, lava and sulfur. You are in the worst place of the world, but if you are here is because you did something wrong. Now you regret to haven't helped cross the road to that old lady?"; break;
            case 5: retorn = "After the hell, you have a break and you only have to face more poisonous worms and rats that will atack you directly. We know you love us."; break;
            case 6: retorn = "Welcome to the tipical water level from all the games. Here you have tipical underwater music and fishes as enemies. And you don't have to breath!"; break;
            case 7: retorn = "More water. New enemies. More agresive. Harder. and you can still breathe under water, but try to don't run out of fuel, because you will die. It's our logical."; break;
            case 8: retorn = "If you noticed during two levels the lack of air, now you will have an excess. And there seems to be a war, so the airplanes will shot you. Bad luck Tom."; break;
            case 9: retorn = "The stratosphere is the second major layer of Earth's atmosphere, just above the troposphere, and below the mesosphere. Thank you Wikipedia, you saved us again."; break;
            case 10: retorn = "You are getting top levels, so we have to make it harder to you. Maybe space junk? Fireballs again? Nasa satellite? Perfect"; break;
            case 11: retorn = "You can see the inmensity of univers. You are on the top of the world. On the top of the existence. It's imposible to be something over this, no?"; break;
            case 12: retorn = "You reached the last Stage. Congratulations! We tried to make it hard to arrive here, but if EVEN YOU can reach that, maybe the game is easier than we wanted. Now, try to dodge all the enemies you saw during all the stages."; break;


        }
        return retorn;

    }

    public string getNivellName(int i)
    {
        string retorn = "";
        switch (i)
        {
            case 1: retorn = "Inner Core"; break;
            case 2: retorn = "Outer Core"; break;
            case 3: retorn = "Mantle"; break;
            case 4: retorn = "Hell"; break;
            case 5: retorn = "Crust"; break;
            case 6: retorn = "Seabed"; break;
            case 7: retorn = "Ocean"; break;
            case 8: retorn = "Sky"; break;
            case 9: retorn = "Stratosphere"; break;
            case 10: retorn = "Exosphere"; break;
            case 11: retorn = "Galaxies"; break;
            case 12: retorn = "The Limbo"; break;

        }
        return retorn;

    }
}
