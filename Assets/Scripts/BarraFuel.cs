using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class BarraFuel : MonoBehaviour {

	public float fuel = 100;
    private float maxFuel = 100;
	
	public float treuFuel(float quitarfuel){
		fuel = fuel - quitarfuel;
		//Debug.Log (fuel);
		GetComponent<Image>().fillAmount = fuel/maxFuel;

		return fuel;

	}

    public float sumaFuel(float cura)
    {
        fuel = fuel + cura;
        if (fuel > maxFuel)
            fuel = maxFuel;

        GetComponent<Image>().fillAmount = fuel /maxFuel;
        return fuel;

    }
    public void setFuelMax(float mxFuel)
    {
        maxFuel = mxFuel;
        fuel = maxFuel;
    }





}


