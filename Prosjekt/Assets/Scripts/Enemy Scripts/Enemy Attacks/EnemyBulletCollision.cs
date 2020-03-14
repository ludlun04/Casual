using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosion;
    [SerializeField] private int damage = 4;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject animation = Instantiate(bulletExplosion, transform.position, transform.rotation);
        Destroy(animation, .8f);

        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent <PlayerController>();
            player.takeDamage(damage);
        }


    }
}
