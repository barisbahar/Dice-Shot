using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public GameObject assassin;
    void Start()
    {

    }

    void Update()
    {
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "RedPlayer")
        {
            Destroy(col.gameObject);
            GameManager.redTeamCount--;
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            GameManager.redTeamCount++;
            Instantiate(assassin, new Vector3(-10.7f, 0, Random.Range(-7f, 6f)), Quaternion.Euler(0f, 90f, 0f)).gameObject.tag = "RedPlayer";
        }
    }
}
