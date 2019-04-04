
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] bool spawn = true;
    [SerializeField] int minDelay = 1;
    [SerializeField] int maxDelay = 5;

    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            {
                SpawnAttacker();
            }
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefabs[Random.Range(0, attackerPrefabs.Length)], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
