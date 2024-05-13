using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControler : MonoBehaviour
{

    public static PlayerHealthControler instance;

    public int currentHealth;
    public int maxHealth;

    public float damageInvincLenght = 1f;
    private float invincCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        UiController.instance.healthSlider.maxValue = maxHealth;
        UiController.instance.healthSlider.value = currentHealth;
        UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();

    }

    
    void Update()
    {
        if(invincCount > 0)
        {
            invincCount -= Time.deltaTime;

            if(invincCount <= 0)
            {
                PlayerControler.instance.bodySR.color = new Color(PlayerControler.instance.bodySR.color.r, PlayerControler.instance.bodySR.color.g, PlayerControler.instance.bodySR.color.b, 1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if (invincCount <= 0)
        {

            currentHealth--;

            invincCount = damageInvincLenght;

            PlayerControler.instance.bodySR.color = new Color(PlayerControler.instance.bodySR.color.r, PlayerControler.instance.bodySR.color.g, PlayerControler.instance.bodySR.color.b, .5f);

            if (currentHealth <= 0)
            {
                PlayerControler.instance.gameObject.SetActive(false);

                UiController.instance.deathScreen.SetActive(true);
            }

            UiController.instance.healthSlider.value = currentHealth;
            UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }

    public void MakeInvincible(float lenght)
    {
        invincCount = lenght;
        PlayerControler.instance.bodySR.color = new Color(PlayerControler.instance.bodySR.color.r, PlayerControler.instance.bodySR.color.g, PlayerControler.instance.bodySR.color.b, .5f);

    }

    public void HealPlayer(int healAmmount)
    {
        currentHealth += healAmmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UiController.instance.healthSlider.value = currentHealth;
        UiController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
