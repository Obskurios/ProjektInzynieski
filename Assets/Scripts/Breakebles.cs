using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakebles : MonoBehaviour
{
    public GameObject[] brokenPieces;
    public int maxPieces = 5;

    public bool shouldDropItem;
    public GameObject[] itemsToDrop;
    public float itemDropProcent;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Smash()
    {

        Destroy(gameObject);

        //show broken pieces

        int piecesToDrop = Random.Range(0, maxPieces);

        for (int i = 0; i < piecesToDrop; i++)
        {
            int randomPiece = Random.Range(0, brokenPieces.Length);

            Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
        }

        //drop items

        if (shouldDropItem)
        {
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropProcent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (PlayerControler.instance.dashCounter > 0)
            {
                Smash();
        
            }
        }

        if(other.tag == "PlayerBullet")
        {
            Smash();
        }
    }

}

