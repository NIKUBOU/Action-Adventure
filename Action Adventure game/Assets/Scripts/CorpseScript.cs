using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScript : MonoBehaviour
{
    public float health;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            health -= damage;
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
