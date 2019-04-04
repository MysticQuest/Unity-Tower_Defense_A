using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{

    [SerializeField] int stars = 100;

    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateStars();
    }

    public void UpdateStars()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int gain)
    {
        stars += gain;
        UpdateStars();
    }

    public bool EnoughStars(int cost)
    {
        return stars >= cost;
    }

    public void PayStars(int cost)
    {
        if (stars >= cost)
        {
            stars -= cost;
            UpdateStars();
        }
    }
}
