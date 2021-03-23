using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT : MonoBehaviour
{
    [SerializeField] // allows the variable to edited and seen in the Unity inspector
    int lives;
    [SerializeField]
    float Mana;
    [SerializeField]
    bool Live;
    [SerializeField]
    string saysomething;

    Rigidbody CubeRB;
    // Start is called before the first frame update
    void Start()
    {
        CubeRB = GetComponent<Rigidbody>();


        // if the game is run these values will overwrite any values set in the inspector in Unity
        lives = 10;
        Mana = 100;
        Live = true;
        saysomething = "Yo";
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float x;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            x += 1;
            Debug.Log("Key is pressed" + x);
        }
    }
}
