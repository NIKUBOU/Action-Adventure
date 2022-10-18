using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Enemy
{
    private Rigidbody2D rb;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);
        }
    }
}
