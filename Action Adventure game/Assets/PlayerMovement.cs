using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 changePosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changePosition = Vector3.zero;
        changePosition.x = Input.GetAxisRaw("Horizontal");
        changePosition.y = Input.GetAxisRaw("Vertical");
        MoveAnimation();
        
    }

    void MoveAnimation()
    {
        if (changePosition != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", changePosition.x);
            animator.SetFloat("moveY", changePosition.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + changePosition.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
