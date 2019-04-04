using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level Timer in SECONDS")]
    [SerializeField] float levelTime = 10;

    bool triggerFinish = false;

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (triggerFinish == true) { return; }
        slider.value = Time.timeSinceLevelLoad / levelTime;

        if (slider.value >= 1)
        {
            FindObjectOfType<LevelController>().LevelFinished();
            triggerFinish = true;
        }
    }
}
