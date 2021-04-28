using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public float ShootDistance = 0.2f;
    public float ShootDelay = 2.0f;
    public float ShootForce = 1.0f;
    public Transform Target;
    public Transform SpawnPoint;
    public GameObject BulletPrefab;
    public float TotalHealth = 100.0f;
    private float currentHealth;
    public Image HealthBar;

    void Start()
    {
        StartCoroutine(ShootingTimer());
        
        currentHealth = TotalHealth;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, SpawnPoint);
        bullet.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward * ShootForce, ForceMode.Impulse);
    }
    private IEnumerator ShootingTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootDelay);
            float distance = (transform.position - Target.position).magnitude;
            if (distance > 0.1f && distance < ShootDistance)
            {
                Shoot();
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();
        if(bullet != null)
        {
            currentHealth -= bullet.DamageInflicted;
            HealthBar.fillAmount = currentHealth / TotalHealth;
            Destroy(bullet.gameObject);
            if(currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
