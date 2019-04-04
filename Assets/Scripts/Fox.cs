using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] int damage;
    Attacker attacker;

    Animator animator;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("JumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
        }
    }

    private void HitFrame()
    {
        attacker.StrikeCurTarget(damage);
    }
}
