using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    public float stoppingDistance;
    public float retreatDistance;

    [SerializeField] private EnemyShooting shooting;
    [SerializeField] private int rangedDamage = 4;
    
    private Vector3 direction;
    private float angle;
    private Vector2 movement;
    private float distance; // Distance between enemy and player
    private enum characterState { CHASING, RUNNING, SHOOTING}
    private characterState state; 

    // Update is called once per frame
    void Update()
    {

        direction = base.player.position - transform.position;     
        direction.Normalize();
        movement = direction;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        distance = Vector2.Distance(transform.position, base.player.position);

        // If character is running, turn around
        if (state == characterState.RUNNING) 
        {
            angle -= 180;
        }

        base.rb.rotation = angle; // Rotate character

        if (distance > stoppingDistance - .2f)
        {
            //Move towards the player
            state = characterState.CHASING;
            shooting.isShooting(false);
        } 

        else if (distance < stoppingDistance && distance > retreatDistance)
        {

            state = characterState.SHOOTING;
            shooting.isShooting(true);
            transform.position = this.transform.position;
        } else
        {
            state = characterState.RUNNING;
            shooting.isShooting(false);
        }
    }
    private void FixedUpdate()
    {
        movecharacter(movement);
    }

    void movecharacter(Vector2 direction)
    {
        if (state != characterState.SHOOTING)
        {
            if (state == characterState.RUNNING)
            {
               direction = -direction;
            }
            rb.MovePosition((Vector2)transform.position + (direction * base.moveSpeed * Time.deltaTime));
        }
        
    }

    public int getRangedDamage()
    {
        return rangedDamage;
    }
}
