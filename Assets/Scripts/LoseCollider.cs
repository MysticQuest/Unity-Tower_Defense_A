using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        int lifeCost = other.GetComponent<Attacker>().GetLifeCost();
        FindObjectOfType<Lives>().LoseLife(lifeCost);
        Destroy(other.gameObject);
    }
}
