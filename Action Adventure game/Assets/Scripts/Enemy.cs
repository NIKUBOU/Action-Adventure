using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger //hurt
}


public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public int baseAttack;
    public float moveSpeed;

    public float damage;

    public GameObject keyDrop;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= damage;
        if(health <= 0)
        {
            ItemDrop();
            this.gameObject.SetActive(false);
        }
    }

    private void ItemDrop()
    {
        
        GameObject key = Instantiate(keyDrop, transform.position, Quaternion.identity);
        key.SetActive(true);
        
    }

}
