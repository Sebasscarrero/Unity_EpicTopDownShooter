using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int Health = 3;
    public float Velocidad = 8;
    private Rigidbody2D rb;
    private Vector2 VelocidadMovimiento;
    public Text HealthText;
    public Text scoreText;
   
    public int score = 0;

    public Animator anim;
    public Shooting shotting;

    public GameObject redFade;
    public GameObject effectPlayer;

    public bool SpawnOnce;

    public SpriteRenderer player;
    Color colorTransparente;

    public bool isDead;
    public Text timeText;
    public SpawnEnemy spawner;

    public float timeToWin;

    public bool enemyHit = false;
    private float privateTiltingTime;
    public float tiltingTime;

    private void Start()
    {
        // endGame = false;
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        shotting = GetComponent<Shooting>();
       // spawner = GetComponent<SpawnEnemy>();
        redFade.SetActive(false);
        SpawnOnce = true;
        isDead = true;
        colorTransparente = new Color(255, 255, 255, 0f);
        privateTiltingTime = tiltingTime;
    }

    void Limit()
    {   
        // LIMIT IN X AXIS
        if (transform.position.x <= -6.0f)
            transform.position = new Vector2(-6.0f, transform.position.y);
        else if (transform.position.x >= 6.0f)
            transform.position = new Vector2(6.0f, transform.position.y);
        // LIMIT IN Y AXIS
        if (transform.position.y <= -4.4f)
            transform.position = new Vector2(transform.position.x, -4.4f);
        else if (transform.position.y >= 4.4f)
            transform.position = new Vector2(transform.position.x, 4.4f);
    }

    void LittlePower()
    {
        if (Input.GetKey(KeyCode.CapsLock) && isDead == true)
        {
            anim.SetBool("isLittle", true);
            Velocidad = 12;
            shotting.getsLittle = true;

        }
        else
        {
            anim.SetBool("isLittle", false);
            Velocidad = 8;
            shotting.getsLittle = false;
        }
       /* if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            anim.SetBool("isLittle", false);
            Velocidad = 8;
            shotting.getsLittle = false;
        }*/


    }



    private void Update()
    {
        if (Health <= 0)
        {
            isDead = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Health = 0;
            player.color = colorTransparente;
            SpawnOnceParticles();
            StartCoroutine("Reset");
        }

        HealthText.text = "Health: " + Health;
        scoreText.text = "Score: " + score;


        timeToWin -= Time.deltaTime;
        timeText.text = "Time left: "+((int)timeToWin).ToString() ;

        Vector2 InputMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        VelocidadMovimiento = InputMove.normalized * Velocidad;

        Limit();
        LittlePower();


        PlayerTilt();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + VelocidadMovimiento * Time.fixedDeltaTime);
    }


    void SpawnOnceParticles()
    {

        if (SpawnOnce == true)
        {
            Instantiate(effectPlayer, transform.position, Quaternion.identity);

            SpawnOnce = false;
        }
    }




    IEnumerator Reset()
    {
        //endGame = true;
        player.color = colorTransparente;

        //Instantiate(effectPlayer, transform.position, Quaternion.identity);
        // Destroy(gameObject);
       
        
       
        redFade.SetActive(true);
        Time.timeScale = .3f;
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void TiltingTime()
    {
       if (isDead) { 
            if (enemyHit == false)
            {
                Health--;   
                enemyHit = true;
                Debug.Log("Choque Enemigo, titila y quita vida");
            }

            else
            {
          
                Debug.Log("Choque Enemigo pero aun tengo escudo");
            }
        }
    }
   
    void PlayerTilt()
    {
        if (isDead) { 
            if (enemyHit == true)
            {
                anim.SetBool("isHurt", true);
                privateTiltingTime -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("isHurt", false);
            }

            if (privateTiltingTime <= 0)
            {
                anim.SetBool("isHurt", false);
                privateTiltingTime = tiltingTime;
                enemyHit = false;
                Debug.Log("alv se me acabó el escudo");
            }
        }

    }



}
        
