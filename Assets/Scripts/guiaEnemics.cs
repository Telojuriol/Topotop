using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class guiaEnemics : MonoBehaviour {

    private XMLPlayer xml;
    public Sprite[] enemics = new Sprite[28];
    private GameObject pantallaEnemic;
    // Use this for initialization
    void Awake () {
        xml = new XMLPlayer();
        pantallaEnemic = GameObject.Find("/Canvas/PantallaEnemic");
        pantallaEnemic.SetActive(false);
        
        if (xml.getLogro(1)){
            GameObject.Find("/Canvas/ScrollRect/Enemics/1").GetComponent<Image>().sprite = enemics[0];
            GameObject.Find("/Canvas/ScrollRect/Enemics/2").GetComponent<Image>().sprite = enemics[1];
        }
        if (xml.getLogro(2))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/3").GetComponent<Image>().sprite = enemics[2];
            GameObject.Find("/Canvas/ScrollRect/Enemics/4").GetComponent<Image>().sprite = enemics[3];
            GameObject.Find("/Canvas/ScrollRect/Enemics/5").GetComponent<Image>().sprite = enemics[4];
        }
        if (xml.getLogro(3))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/6").GetComponent<Image>().sprite = enemics[5];
        }
        if (xml.getLogro(4))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/7").GetComponent<Image>().sprite = enemics[6];
            GameObject.Find("/Canvas/ScrollRect/Enemics/8").GetComponent<Image>().sprite = enemics[7];
            GameObject.Find("/Canvas/ScrollRect/Enemics/9").GetComponent<Image>().sprite = enemics[8];
        }
        if (xml.getLogro(5))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/10").GetComponent<Image>().sprite = enemics[9];
            GameObject.Find("/Canvas/ScrollRect/Enemics/11").GetComponent<Image>().sprite = enemics[10];
        }
        if (xml.getLogro(6))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/12").GetComponent<Image>().sprite = enemics[11];
            GameObject.Find("/Canvas/ScrollRect/Enemics/13").GetComponent<Image>().sprite = enemics[12];
            GameObject.Find("/Canvas/ScrollRect/Enemics/14").GetComponent<Image>().sprite = enemics[13];
        }
        if (xml.getLogro(7))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/15").GetComponent<Image>().sprite = enemics[14];
            GameObject.Find("/Canvas/ScrollRect/Enemics/16").GetComponent<Image>().sprite = enemics[15];
            GameObject.Find("/Canvas/ScrollRect/Enemics/17").GetComponent<Image>().sprite = enemics[16];
        }
        if (xml.getLogro(8))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/18").GetComponent<Image>().sprite = enemics[17];
            GameObject.Find("/Canvas/ScrollRect/Enemics/19").GetComponent<Image>().sprite = enemics[18];
            GameObject.Find("/Canvas/ScrollRect/Enemics/20").GetComponent<Image>().sprite = enemics[19];
        }
        if (xml.getLogro(9))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/21").GetComponent<Image>().sprite = enemics[20];
            GameObject.Find("/Canvas/ScrollRect/Enemics/22").GetComponent<Image>().sprite = enemics[21];
            GameObject.Find("/Canvas/ScrollRect/Enemics/23").GetComponent<Image>().sprite = enemics[22];
        }
        if (xml.getLogro(10))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/24").GetComponent<Image>().sprite = enemics[23];
            GameObject.Find("/Canvas/ScrollRect/Enemics/25").GetComponent<Image>().sprite = enemics[24];
        }
        if (xml.getLogro(11))
        {
            GameObject.Find("/Canvas/ScrollRect/Enemics/26").GetComponent<Image>().sprite = enemics[25];
            GameObject.Find("/Canvas/ScrollRect/Enemics/27").GetComponent<Image>().sprite = enemics[26];
        }
        
    }

    // Update is called once per frame


    public void tornaGuia()
    {
        Application.LoadLevel("Guia");
    }

    public void menuEnemic()
    {
       
        if(EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name != "unlocked")
        {
            pantallaEnemic.SetActive(true);
            int i = int.Parse(EventSystem.current.currentSelectedGameObject.name);
            GameObject.Find("/Canvas/PantallaEnemic/Image").GetComponent<Image>().sprite = enemics[i - 1];
            GameObject.Find("/Canvas/PantallaEnemic/Name").GetComponent<Text>().text = getEnemyName(i);
            GameObject.Find("/Canvas/PantallaEnemic/Description").GetComponent<Text>().text = getEnemyDescription(i);

        }


    }
    public void closeMenuEnemics()
    {
        pantallaEnemic.SetActive(false);

    }

    public string getEnemyDescription(int i)
    {
        string retorn = "";
        switch (i)
        {
            case 1: retorn = "Don't use it as a pillow if you don't want neck pain for a week or a month. Even harder than the yesterday's bread."; break;
            case 2: retorn = "They hate you, and you won't kill they with a simple insecticide. Truly you won't kill they, so run."; break;
            case 3: retorn = "Perfect for a BBQ. But at least use mittens to catch it or you'll regret. Don't ask where is it falling from."; break;
            case 4: retorn = "Perfect for a big BBQ. But at least use bigger mittens to catch it or you'll regret more than before."; break;
            case 5: retorn = "The tipical enemie of all the videogames. Topotop's not an exception. We're sorry for the lack of originality."; break;
            case 6: retorn = "Found inside an apple. Not so letal, but disgusting. Maybe that apple wasnt fresh at all, not as fruiterer said."; break;
            case 7: retorn = "He's the tipical vampire that sucks your blood. At least it's not dating Christen Stewart and glows with daylight."; break;
            case 8: retorn = "Like Casper but not gay. He wasn't caught in the casting for Hogwarts ghost, so we hired him for less money and worst conditions."; break;
            case 9: retorn = "You are not interested in deal with an angry fireball. It's angry and have fire, it's logical. He doesn't remember you to Don Patch."; break;
            case 10: retorn = "He smells better than you after a sport day without a good shower, so don't judge him. Rats doesn't have soap."; break;
            case 11: retorn = "More poisonous. More dangerous. He returned stronger than ever. Now is pink, so he's better than before."; break;
            case 12: retorn = "It's not fat, he have bigger bones. It's so tired of the bullying that is about to explode. You don't want to see that."; break;
            case 13: retorn = "Another sink. Around 100 deads. It will be on the news everywhere tomorrow, with the report of a giant pizza on a lost village."; break;
            case 14: retorn = "Perfect to read in the night. Under the water. Outside water he will die and you will lose your light."; break;
            case 15: retorn = "Chan chan chan chan chan chan chan chan chan chan chan chan chaaaaaaaaaan chan chaaaaaaaan. (It's the Jaws song, sorry for that)."; break;
            case 16: retorn = "We copied the idea from Mario Bros. Don't judge us. At least we used another texture and it follows you, not like Mario's."; break;
            case 17: retorn = "Don't mess with them. They are more than you. And all they can breath under water, not like you. Otherwise, they are so weak."; break;
            case 18: retorn = "There's a kid crying because that. It costs 2 dollars on the fair or 20 dollars on the tipical toy store of the mall."; break;
            case 19: retorn = "A pirate will be looking for it. And don't try to talk with him. The carrots can not speak the humans language. It's necessary to say that?"; break;
            case 20: retorn = "If he shoots you is because he likes you. There's a war on the skies for your heart, and no one wants to lose."; break;
            case 21: retorn = "It/s like the pink pig from toy story, but has wings, is made of ceramic and has no coins inside. Nor tells jokes."; break;
            case 22: retorn = "Another undesired baby. The fathers cancelled the order. Another lost on budget for the childre-delivery agency of storks."; break;
            case 23: retorn = "Isn't a X-Men, but will makes you suffer. Be carefull because is a non-announced by the meteorologist storm. Those are the worst."; break;
            case 24: retorn = "In the best of cases you will sintonize FOX. In the worst he will kill you. Or maybe you prefer to die to sintonize FOX."; break;
            case 25: retorn = "Nasa lost all the glamour of aforetime. Now they make rockets with any sense only to strut around the russians."; break;
            case 26: retorn = "Don't use it as a pillow on the space. Because it's on the space. You can't breath or sleep. Keep surviving please."; break;
            case 27: retorn = "If they catch you maybe will make experiments with your body. You will phisically finish worst than Steve Urlek after boxing, and mentally worst than Mike Tyson after a school exam."; break;

        }
        return retorn;

    }

    public string getEnemyName(int i)
    {
        string retorn = "";
        switch (i)
        {
            case 1: retorn = "Rock"; break;
            case 2: retorn = "Beetle"; break;
            case 3: retorn = "Volcanic Rock"; break;
            case 4: retorn = "Big Volcanic Rock"; break;
            case 5: retorn = "Fireball"; break;
            case 6: retorn = "Green Worm"; break;
            case 7: retorn = "Bat"; break;
            case 8: retorn = "Ghost"; break;
            case 9: retorn = "Angry Fireball"; break;
            case 10: retorn = "Rat"; break;
            case 11: retorn = "Purple Worm"; break;
            case 12: retorn = "Blowfish"; break;
            case 13: retorn = "Anchor"; break;
            case 14: retorn = "Lanternfish"; break;
            case 15: retorn = "Shark"; break;
            case 16: retorn = "Torpedo"; break;
            case 17: retorn = "Fish Stock"; break;
            case 18: retorn = "Kite"; break;
            case 19: retorn = "Parrot"; break;
            case 20: retorn = "War Plane"; break;
            case 21: retorn = "Pink Pig"; break;
            case 22: retorn = "Stork"; break;
            case 23: retorn = "Angry Cloud"; break;
            case 24: retorn = "Satellite"; break;
            case 25: retorn = "Rocket"; break;
            case 26: retorn = "Meteorite"; break;
            case 27: retorn = "U.F.O."; break;

        }
        return retorn;

    }


}
