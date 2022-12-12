using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PushBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3((20 * slider.value / 100) - 10, 0, 0);
    }
}
