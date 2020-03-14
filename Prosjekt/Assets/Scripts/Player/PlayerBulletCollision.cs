using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
        GameObject animation = Instantiate(bulletExplosion, transform.position, transform.rotation);
        Destroy(animation, .8f);
        
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.takeDamage();
            Debug.Log("Hit" + enemy.gameObject.name);
        }

        
    }

}
