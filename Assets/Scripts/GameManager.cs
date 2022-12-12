using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int redTeamCount = 5, blueTeamCount = 5;
    public Slider slider;
    public GameObject restartpanel;
    private bool check = false;
    void Start()
    {
        Time.timeScale = 1;
        slider.value = 50;
        restartpanel.SetActive(false);
    }
    private void Update()
    {
        if (redTeamCount != blueTeamCount)
        {
            check = true;
        }
        if (check == true)
        {
            check = false;
            StartCoroutine(SliderCount());
        }
        if (slider.value == 0 || slider.value == 100)
        {
            restartpanel.gameObject.SetActive(true);

            Time.timeScale = 0;

        }
    }
    IEnumerator SliderCount()
    {
        while (true)
        {

            int total = redTeamCount - blueTeamCount;
            if (total == 0)
            {
                break;
            }
            if (total < 0)
            {
                slider.value -= 1 * Time.deltaTime;
            }
            else if (total > 0)
            {
                slider.value += 1 * Time.deltaTime;
            }
            yield return new WaitForSeconds(2f / Mathf.Abs(total));
        }
    }

}
