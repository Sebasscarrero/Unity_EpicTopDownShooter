using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
   // public float Speed;
    private Transform playerPos;
    public GameObject explosion;
    private PlayerMovement player;
    public GameObject explosionProjectile;
    public GameObject explosionProjectile1;
    private int randSpeed;
    //public int enemyHealth;



    private void Start()
    {

        randSpeed = Random.Range(2, 7);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

   


    }

    private void Update()
    {
       

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, randSpeed * Time.deltaTime);
        

       /* if (enemyHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
                Instantiate(explosion, transform.position, Quaternion.identity);

                player.TiltingTime();

                //player.Health--;
                Debug.Log(player.Health);
      
                Destroy(gameObject);
      
        }

        if (other.CompareTag("Projectile"))
        {
            Instantiate(explosionProjectile, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);

            player.score++;

            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        if (other.CompareTag("Projectile1"))
        {
            Instantiate(explosionProjectile1, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);

            player.score++;

            Destroy(other.gameObject);
            Destroy(gameObject);

        }

        if (other.CompareTag("Bomb"))
        {
            //Instantiate(explosionProjectile1, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);

            player.score++;

            
            Destroy(gameObject);

        }
    }



}

