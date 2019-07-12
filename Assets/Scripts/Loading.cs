using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("/Canvas/Hints").GetComponent<Text>().text = randomHint(); 
        
        Application.LoadLevel("JocPrincipal");
    }
	
    string randomHint()
    {
        int num = Random.Range(0,7);
        string frase = "Hint: Collect nuts to upgrade your equipment and go further.";
        switch (num)
        {
            case 0:
                frase = "Hint: Collect nuts to upgrade your equipment and go further.";
                break;

            case 1:
                frase = "All Tom wants is to explore the world, and he will try as many times as he needs.";
                break;

            case 2:
                frase = "Hint: During Turbo you can catch some bonifications. Use it to heal you!";
                break;

            case 3:
                frase = "Hint: Unlock content and information about enemies and areas in the guides unlocking the achievements!";
                break;

            case 4:
                frase = "Some enemies don't want to see Tom in its territory. Be carefull.";
                break;

            case 5:
                frase = "Tom have seen so many things, but it's a mole and he can't talk, so he won't explain it's to you.";
                break;

            case 6:
                frase = "Hint: Dodge enemies and take bonifications. I shouldn't explain that things...";
                break;
        }
        return frase;
    }

}
