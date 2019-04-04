using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] int attackers = 0;
    [SerializeField] bool levelFinished = false;
    [SerializeField] float waitToLoad = 4f;

    private void Start()
    {
        winCanvas.SetActive(false);
    }

    void Update()
    {

    }

    public void AttackerSpawned()
    {
        attackers++;
    }

    public void LevelFinished()
    {
        levelFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void AttackerKilled()
    {
        attackers--;
        if (attackers <= 0 && levelFinished == true)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        winCanvas.SetActive(false);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
