using UnityEngine;

public class TurretController : MonoBehaviour
{   
    public GameObject GunBarrel;
    public Transform firePoint; 
    public GameObject bulletPrefab; 
    private float fireRate = 0.5f; 
    private float bulletSpeed = 3f; 
    private float bulletLifetime = 4f; 

    private float nextFireTime;

    void Update()
    {
        RotateToMouse();
        Shoot();
    }

    
    void RotateToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - transform.position.y));
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       transform.rotation = lookRotation;
    }

   
    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            
            rb.velocity = firePoint.forward.normalized * bulletSpeed;

            
          Destroy(bullet, bulletLifetime);
        }
    }
}
