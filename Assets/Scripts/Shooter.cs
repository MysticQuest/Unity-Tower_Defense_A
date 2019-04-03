using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject zukini, gun;

    public void Fire(float damage)
    {
        Instantiate(zukini, gun.transform.position, transform.rotation);
    }
}
