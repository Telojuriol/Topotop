using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

    public bool android = true;
    public float tilt;
    public float speed;

    private float moveHorizontal;
    private int screenWidth = 0;

    void Start()
    {
        screenWidth = Screen.width;

    }

    void Update () {

        if (android) controlsAndroid();
        else controlsPC();


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, -2, 2), 0.0f, -4.57f);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt * 0.8f);
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
