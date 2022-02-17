using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class MoveSphere : MonoBehaviour
{
    //Initialize forces to move the shpere
    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 50.0f;
    //Condition to know if the sphere is in the air or not
    public bool InAir = false;
  
    //Collisions functions allow me to make the sphere jump once
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sol" && InAir == true ) //We check if the sphere touching objects tagged as Sol and if it is not in the air
            InAir = false;
        
        if (other.gameObject.tag == "Lose") //If the sphere enter on collision with objects tagged Lose, switch scene to the Game over one
        {
            SceneManager.LoadScene("GameOver");
        }

        if (other.gameObject.tag == "Win") //If the sphere enter on collision with objects tagged Win, switch scene to the Win one
        {
            SceneManager.LoadScene("Win");
        }


    }
    void OnCollisionStay(Collision other)//This function allow us to know if the sphere is constantly touching an object
    {
        if (other.gameObject.tag == "Sol" && InAir == true) //We check if the sphere touching objects tagged as Sol and if it is not in the air
            InAir = false;
    }
    void OnCollisionExit()//Allow us to know if the phere has jumped
    {
        InAir = true;
    }

    void Update()//Update every frame
    {
        
        float x = 0.0f;
        if (Input.GetKey(KeyCode.Q))//Add force to the x axes to move the sphere
        {
            x = x - xForce;
        }

        if (Input.GetKey(KeyCode.D))//Add force to the x axes to move the sphere
        {
            x = x + xForce;
        }

        float z = 0.0f;
        if (Input.GetKey(KeyCode.S))//Add force to the z axes to move the sphere
        {
            z = z - zForce;
        }

        if (Input.GetKey(KeyCode.Z))//Add force to the z axes to move the sphere
        {
            z = z + zForce;
        }

        float y = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space) && InAir == false)//Add force to the y axes to make the sphere jump
        {
            y = yForce;
        }

        if (Input.GetKey(KeyCode.R))//Its a condition to make the sphere respawn at the beginning of the level
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 0);//We cancel the forces added to the sphere
            GetComponent<Rigidbody>().transform.position= new Vector3(340, 60, 117);//And make it respawn to the initial position
            
        }
        GetComponent<Rigidbody>().AddForce(x, y, z);
    }
}