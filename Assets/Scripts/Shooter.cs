using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject zukini, gun;
    [SerializeField] AttackerSpawner myLaneSpawner;

    Animator animator;

    GameObject projectileParent;
    const string PROJ_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJ_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJ_PARENT_NAME);
        }
    }

    public void Fire(float damage)
    {
        GameObject newProj = Instantiate(zukini, gun.transform.position, transform.rotation);
        newProj.transform.parent = projectileParent.transform;
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
