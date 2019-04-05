using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] Text text;

    void Start()
    {
        text.CrossFadeAlpha(255f, 5f, false);
    }


    void Update()
    {

    }
}
