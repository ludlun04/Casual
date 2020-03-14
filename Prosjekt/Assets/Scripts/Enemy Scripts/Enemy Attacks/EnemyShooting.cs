using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed = 20f; // Velocity
    [SerializeField] private float fireRate = 2; // Per second

    private bool canShoot = false;

    private float timeSinceLastShot = 0f;

    // Update is called once per frame
    void Update()
    {

        if (canShoot && Time.time > timeSinceLastShot + 1 / fireRate)
        {
            timeSinceLastShot = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }

    public void isShooting(bool isShooting)
    {
        canShoot = isShooting;
    }
}
