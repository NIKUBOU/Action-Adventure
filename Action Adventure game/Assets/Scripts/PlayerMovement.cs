using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 changePosition;
    private Animator animator;
    public float health;
    public float damage;

    public GameObject corpseDrop;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changePosition = Vector3.zero;
        changePosition.x = Input.GetAxisRaw("Horizontal");
        changePosition.y = Input.GetAxisRaw("Vertical");
        
        
        if (currentState == PlayerState.walk)
        {
            MoveAnimation();
        }
        
        
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("isAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.3f);
        currentState = PlayerState.walk;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= damage;
        if (health <= 0)
        {
            CorpseDrop();
            this.gameObject.SetActive(false);
        }
    }

    private void CorpseDrop()
    {

        GameObject corpse = Instantiate(corpseDrop, transform.position, Quaternion.identity);
        corpse.SetActive(true);

    }
}
