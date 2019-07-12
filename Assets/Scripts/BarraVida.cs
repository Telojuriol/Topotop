using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class BarraVida : MonoBehaviour {

	public float vida = 100;
	private float maxVida = 100;


    void Start () {
    }


	public float treuVida(float mal){
		vida = vida - mal;
		GetComponent<Image>().fillAmount = vida/maxVida;
		return vida;

	}
	public float curaVida(float cura){
		vida = vida + cura;
		if (vida > maxVida)
			vida = maxVida;
		
		GetComponent<Image>().fillAmount = vida/maxVida;
		return vida;

	}
	public void setVidaMax(float mxVida){
		maxVida = mxVida;
		vida = maxVida;
	}
		



}

