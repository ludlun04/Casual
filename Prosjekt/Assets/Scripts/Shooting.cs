using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float bulletSpeed = 20f; // Velocity
    [SerializeField] private float fireRate = 0.5f; // Per second


    private float timeSinceLastShot = 0f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > timeSinceLastShot)
        {
            timeSinceLastShot = Time.time +  1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);

    }
}
