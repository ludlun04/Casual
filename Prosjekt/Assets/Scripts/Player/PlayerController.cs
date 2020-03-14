using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Movement speed
    [SerializeField] private Transform arrow; // Pointing arrow
    [SerializeField] private Camera cam; // Main camera

    [SerializeField] private int hp = 10; //Player hp
    private int initialHp;
    [SerializeField] private HealthBar healthbar;
    private Rigidbody2D rb; // Player Rigidbody

    private Vector2 movement;
    void Start()
    {
        initialHp = hp; // Store max hp
        healthbar.setText(hp.ToString() + " / " + initialHp.ToString()); // Display hp on start
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - arrow.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        arrow.rotation = rotation;
    }

    private void FixedUpdate()
    {
        Move();
        
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            takeDamage(enemy.dealDamage()); 
        }
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        float healthBarValue = (float)hp / initialHp;

        if (hp <= 0)
        {
            healthbar.setHealth(0);
            healthbar.setText("0  / " + initialHp.ToString());
            Die();
        }
        else
        {
            healthbar.setHealth(healthBarValue);
            healthbar.setText(hp.ToString() + " / " + initialHp.ToString());
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
