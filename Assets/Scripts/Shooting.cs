using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject shot;
    public GameObject shot1;
    public GameObject bomba;
    public Transform playerPos;
    public PlayerMovement player;
    private float timeShooting;
    public float timeShootingValue;
    public bool getsLittle;
    private float timeBomb;
    public float timeBombValue;
    public bool bombReady;


    private void Start()
    {
        
        getsLittle = false;
        bombReady = true;
        timeShooting = timeShootingValue;       
        playerPos = GetComponent<Transform>();
        player = GetComponent<PlayerMovement>();
    }



    private void Update()
    {

        if (getsLittle == false && player.isDead == true) 
            { 


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot1, playerPos.position, transform.rotation);
        }



        if (Input.GetMouseButton(1))
        {
            if (timeShooting >0)
            Instantiate(shot, playerPos.position, Quaternion.identity);
            timeShooting -= Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1))
        {
            timeShooting = timeShootingValue;
        }





        if (Input.GetKeyDown("space"))
        {
                if (bombReady == true)
                {
                    timeBomb = timeBombValue;
                    Instantiate(bomba, playerPos.position, transform.rotation);
                    bombReady = false;
                }           
        }
        
       
        if (bombReady == false)
            {
                ContBomb();
            }

    }
    }

    void ContBomb()
    {


        if (timeBomb <= 0)
        {
            bombReady = true;
        }
        else
        {
            timeBomb -= Time.deltaTime;
        }


    }


}
