using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject assassin;
    void Update()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BluePlayer")
        {
            Destroy(col.gameObject);
            GameManager.blueTeamCount--;
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            GameManager.blueTeamCount++;
            Instantiate(assassin, new Vector3(8.5f, 0, Random.Range(-7f, 6f)), Quaternion.Euler(0f, 270f, 0f)).gameObject.tag = "BluePlayer";

        }
    }
}
