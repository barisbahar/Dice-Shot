using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce = 25f;
    public GameObject bulletPrefab;
    private Vector3 firstpoint; //change type on Vector3
    private Vector3 secondpoint;
    private float zAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float zAngTemp = 0.0f; //temiable for angle
    private float yAngTemp = 0.0f;
    void Start()
    {
        zAngle = 0.0f;
        yAngle = 0.0f;
        this.transform.rotation = Quaternion.Euler(0.0f, zAngle, yAngle);
    }

    void Update()
    {
        FpsControl();
    }

    void FpsControl()
    {
        if (CameraMov.fpscontrol == true)
        {
            if (Input.touchCount > 0)
            {
                //Touch began, save position
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    firstpoint = Input.GetTouch(0).position;
                    zAngTemp = zAngle;
                    yAngTemp = yAngle;
                }
                //Move finger by screen
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    secondpoint = Input.GetTouch(0).position;
                    //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                    zAngle = zAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                    yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;
                    //Rotate camera
                    this.transform.rotation = Quaternion.Euler(0.0f, zAngle, yAngle);
                }
            }
        }
    }
    public void GunShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 2);
    }
}


