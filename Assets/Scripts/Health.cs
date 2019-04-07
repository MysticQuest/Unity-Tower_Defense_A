using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;

    Stars stars;
    [SerializeField] int starLoot;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            AddStars();
            Destroy(gameObject);
        }
    }

    private void AddStars()
    {
        if (GetComponent<Lizard>() != null)
        {
            FindObjectOfType<Stars>().AddStars(starLoot);
        }
        else if (GetComponent<Fox>() != null)
        {
            FindObjectOfType<Stars>().AddStars(starLoot);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 2);
    }
}
