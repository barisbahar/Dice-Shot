using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CameraMov : MonoBehaviour
{
    public static bool fpscontrol = false;

    void Start()
    {
        backcam.SetActive(false);
    }
    public GameObject focus, backcam, gun;
    public void CameraMovement()
    {
        transform.DOMove(new Vector3(13.54f, 5.26f, -1.11f), 3);
        focus.SetActive(false);
        backcam.SetActive(true);
        transform.DORotate(new Vector3(-6, 270, 0), 3).OnComplete(() =>
        {

            fpscontrol = true;
            transform.SetParent(gun.transform, true);
        });

    }
    public void BackCamera()
    {
        transform.DOMove(new Vector3(14.5f, 27f, -0.62f), 3);
        transform.DORotate(new Vector3(61.075f, 270, 0), 5);
        focus.SetActive(true);
        backcam.SetActive(false);
        fpscontrol = false;
    }
}
