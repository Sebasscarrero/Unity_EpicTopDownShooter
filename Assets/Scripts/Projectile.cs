using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector2 target;
    public float speed;
    public GameObject Enemy;
    public GameObject explosionProjectile;
    
    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    
        if (Vector2.Distance(transform.position, target) <= 0.2)
        {
            Instantiate(explosionProjectile, transform.position, Quaternion.identity);
           // Instantiate(Enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        

    }




}
