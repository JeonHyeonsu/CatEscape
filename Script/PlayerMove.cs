using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D p_rigidbody;
    Animator p_animator;
    public float speed;

    void Start()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
        p_animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!GameManager.isPause)
        {
            Move();
        }
        
    }

    void Move()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            p_animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            p_animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            p_animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            p_animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        p_animator.SetBool("IsMoving", dir.magnitude > 0);

        p_rigidbody.velocity = speed * dir;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("EndStage");
            GameManager.instance.EndStage();
        }

        if (collision.gameObject.name == "Doorchk")
        {
            Debug.Log("dooropen");
            GameManager.instance.DoorOpen();
        }

        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("coinget");
            collision.gameObject.SetActive(false);
            GameManager.instance.CoinGain();
        }

        if (collision.gameObject.tag == "item")
        {
            Debug.Log("itemget");
            collision.gameObject.SetActive(false);
            GameManager.instance.ItemGain();
        }

        if (collision.gameObject.tag == "enemy")
        {
            GameManager.instance.RestartStage();
        }
    }

    public void VelocityZero()
    {
        p_rigidbody.velocity = Vector2.zero;
    }
}
