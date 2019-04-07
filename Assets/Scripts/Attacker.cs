using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0, 5)]
    [SerializeField] float currentSpeed = 0f;
    //[SerializeField] int damage = 10;
    [SerializeField] int lifeCost;

    GameObject currentTarget;
    Animator animator;
    LevelController levels;

    private void Start()
    {
        animator = GetComponent<Animator>();
        levels = FindObjectOfType<LevelController>();
        levels.AttackerSpawned();
    }

    private void OnDestroy()
    {
        if (levels != null)
        {
            levels.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    public int GetLifeCost()
    {
        return lifeCost;
    }

    private void UpdateAnimation()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurTarget(int damage)
    {
        if (!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
