using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    int currentSceneIndex;
    [SerializeField] float timeToLoad = 4f;

    LevelTracker tracker;

    void Start()
    {
        tracker = FindObjectOfType<LevelTracker>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitToLoad());
        }

        SetTmpIndex();
    }

    private void SetTmpIndex()
    {
        if (currentSceneIndex == 2)
        {
            tracker.tmpIndex = 2;
        }
        else if (currentSceneIndex == 3)
        {
            tracker.tmpIndex = 3;
        }
        else if (currentSceneIndex == 4)
        {
            tracker.tmpIndex = 4;
        }

    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(timeToLoad);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Reload()
    {
        SceneManager.LoadScene(tracker.tmpIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
