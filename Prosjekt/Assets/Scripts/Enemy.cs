using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float moveSpeed = 2f;

    private float initialSpeed;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float angle;
    private Vector2 movement;

    private int bounceTime = 0;

    [SerializeField]private float hp = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        initialSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        if (bounceTime != 0)
        {
            bounceTime--;
        } else
        {
            moveSpeed = initialSpeed;
            movecharacter(movement);
        }
        
    }

    void movecharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void BounceBack()
    {
        rb.velocity = new Vector2(-rb.velocity.x + moveSpeed, -rb.velocity.y + moveSpeed);
        bounceTime = 50;
    }

    public void takeDamage()
    {
        this.hp--;
        if (hp < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
