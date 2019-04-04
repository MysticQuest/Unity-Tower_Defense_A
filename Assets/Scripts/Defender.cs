using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] int bonus = 10;

    Stars stars;

    private void Start()
    {
        stars = FindObjectOfType<Stars>();
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars()
    {
        stars.AddStars(bonus);
    }

}
