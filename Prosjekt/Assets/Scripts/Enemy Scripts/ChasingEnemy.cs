using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChasingEnemy : Enemy
{
    private Vector3 direction;
    private float angle;
    private Vector2 movement;

    void Update()
    {
        direction = base.player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        base.rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        movecharacter(movement);
    }

    void movecharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * base.moveSpeed * Time.deltaTime));
    }

}
