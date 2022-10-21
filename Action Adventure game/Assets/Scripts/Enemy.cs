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

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    

}
