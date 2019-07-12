using UnityEngine;
using System.Collections;

public class XMLPlayer : MonoBehaviour {

    public const string path = "items";
    private UserInfo ic;

    public XMLPlayer()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/items.xml"))
        {
            UserInfo iAux = UserInfo.Inicial();
            iAux.Save(Application.persistentDataPath + "/items.xml");
        }
        ic = UserInfo.Load();
    }
    void Start () {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/items.xml"))
        {
            UserInfo iAux = UserInfo.Inicial();
            iAux.Save(Application.persistentDataPath + "/items.xml");
        }
        ic = UserInfo.Load();

    }

    public int getMoney()
    {
        return ic.money;

    }

    public bool checkRecord(int puntuacio)
    {
        bool retorn = false;
        if(puntuacio > ic.record)
        {
            ic.record = puntuacio;
            retorn = true;
        }

        return retorn;

    }

    public int getRecord()
    {
        return ic.record;

    }

    public bool getLogro(int nivell)
    {
        bool returned = false;
        if(ic.logros[nivell - 1].damage == 1)
        {
            returned = true;
        }
        return returned;
    }

    public void setLogro(int nivell)
    {
        ic.logros[nivell - 1].damage = 1;
        ic.Save(Application.persistentDataPath + "/items.xml");

    }


    public int getNivell(string millora)
    {
        int retorn = 0;

        for (int i = 0; i < ic.items.Count; i++)
        {
            if (ic.items[i].name == millora)
            {
                retorn = (int)ic.items[i].damage;

            }
        }
        return retorn;

    }
    public void resetLogros()
    {
        for(int i = 0; i < ic.logros.Count; i++)
        {
            ic.logros[i].damage = 0;

        }
        ic.Save(Application.persistentDataPath + "/items.xml");

    }
    public void muteGame()
    {
        if (ic.volum == 1)
        {
            ic.volum = 0;
        }else{
            ic.volum = 1;
        }
        ic.Save(Application.persistentDataPath + "/items.xml");
    }
    public bool volume()
    {
        bool volume = false;
        if (ic.volum == 1)
        {
            volume = true;
        }
        return volume;
    }
    public int getNumLogros()
    {

        return ic.logros.Count;
    }

    public void guardaDades()
    {
        ic.Save(Application.persistentDataPath + "/items.xml");

    }
    public void sumaMonedas(int monedas)
    {
        ic.money += monedas;

    }

    public bool setNivell(string millora, int nivell)
    {
        ic.money = ic.money - (int)(800 * Mathf.Pow(nivell, 2));

        for (int i = 0; i < ic.items.Count; i++)
        {
            if (ic.items[i].name == millora)
            {
                ic.items[i].damage = nivell;

            }
        }
        ic.Save(Application.persistentDataPath + "/items.xml");


        return true;

    }

    public bool firstPlay()
    {
        bool retorn = false;
        if(ic.tutorial == 0)
        {
            retorn = true;
        }
        return retorn;
    }

    public void firstPlayPlayed()
    {
        ic.tutorial = 1;
        guardaDades();

    }

}
