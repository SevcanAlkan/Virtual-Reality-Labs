using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShootForce = 1.0f;
    public float TotalHealth = 100.0f;
    private float currentHealth;
    public Text HealthStat;
    public Image AttackButton;
    public RectTransform GameOverText;
    private bool IsGameOver = false;
    
    void Start()
    {
        currentHealth = TotalHealth;
    }
    
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform);
        Ray r = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        bullet.GetComponent<Rigidbody>().AddForce(r.direction * ShootForce, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (IsGameOver)
            return;
        
        Bullet bullet = collision.collider.GetComponent<Bullet>();
        if(bullet != null && bullet.tag != "DontGetDamage")
        {
            currentHealth -= bullet.DamageInflicted;
            HealthStat.text = "Health: " + currentHealth.ToString();
            Destroy(bullet.gameObject);
            
            if(currentHealth <= 0)
            {
                IsGameOver = true;
                Destroy(AttackButton.gameObject);
                GameOverText.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
