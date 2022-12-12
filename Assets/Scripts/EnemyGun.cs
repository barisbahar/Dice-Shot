using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyGun : MonoBehaviour
{
    public GameObject bulletprefab;
    public GameObject enemy;
    public Transform firePoint;
    float bulletForce = 5;
    void Start()
    {
        InvokeRepeating("FireGun", 0, 2);
    }

    void FireGun()
    {
        Vector3 pos = new Vector3(Random.Range(9.14f, -10.25f), 1, Random.Range(-6.56f, 5.3f));
        enemy.transform.DOLookAt(pos, 1).OnComplete(() =>
        {
            GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
            bullet.transform.DOMove(pos, pos.x < 0 ? 0.2f : 0.5f);

        });
    }
}
