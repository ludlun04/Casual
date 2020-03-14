using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 2f;
    [SerializeField] private int meleeDamage = 1;

    public Rigidbody2D rb;

    [SerializeField] private float hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage()
    {
        this.hp--;
        if (hp < 1)
        {
            Die();
        }
    }

    public int dealDamage()
    {
        return this.meleeDamage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
