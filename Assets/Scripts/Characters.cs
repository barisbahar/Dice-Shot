using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    Rigidbody rb;
    float speed = 3f;
    Animator animator;
    bool touchbar = false;

    void Start()
    {
        Physics.gravity = new Vector3(0, -175, 0);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Pushbar" || col.gameObject.tag == "RedPlayer" || col.gameObject.tag == "BluePlayer")
        {
            touchbar = true;
            speed = 0f;
            transform.SetParent(col.gameObject.transform.parent, true);
            animator.SetBool("Push", true);
            animator.SetBool("Run", false);
        }
        else if (touchbar == true)
        {
            speed = 5;
            animator.SetBool("Push", false);
            animator.SetBool("Run", true);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyDown")
        {
            GameManager.redTeamCount--;
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "AllieDown")
        {
            GameManager.blueTeamCount--;
            Destroy(gameObject);
        }
    }
}
