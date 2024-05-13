using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmmount = 1;

    public float waitToBeCollected = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && waitToBeCollected <= 0)
        {
            PlayerHealthControler.instance.HealPlayer(healAmmount);

            Destroy(gameObject);

        }
    }
}
