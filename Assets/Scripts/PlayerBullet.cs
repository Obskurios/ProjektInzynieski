using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;

    public GameObject impactEffect;

    public int damageToGive = 20;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyControler>().DamageEnemy(damageToGive);
        }
    }

    //usuwanie pocisków jak znikn¹ z mapy

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
