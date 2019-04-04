using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 100;
    Text livesText;

    public void LoseLife(int lifeCost)
    {
        lives -= lifeCost;
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();

        if (lives <= 0)
        {
            FindObjectOfType<SceneLoader>().GameOver();
            livesText.text = "0";
        }
    }
}
