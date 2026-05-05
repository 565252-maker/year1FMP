using NUnit.Framework;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AltarScript : MonoBehaviour
{
    int[] items = new int[5];
    int pickedItem;

    bool hasCollided;

    GameObject damageUpText;
    GameObject healthUpText;
    GameObject fireRateUpText;
    GameObject shotSpeedUpText;
    GameObject allStatsUpText;

    float textCountdown;
    private void Start()
    {
        hasCollided = false;
        
        items[0] = 0;
        items[1] = 1;
        items[2] = 2;
        items[3] = 3;
        items[4] = 4;

        damageUpText = GameObject.Find("DamageUp");
        if(damageUpText != null)
        {
            damageUpText.SetActive(false);
        }
        healthUpText = GameObject.Find("HealthUp");
        if (healthUpText != null)
        {
            healthUpText.SetActive(false);
        }
        fireRateUpText = GameObject.Find("FireRateUp");
        if (fireRateUpText != null)
        {
            fireRateUpText.SetActive(false);
        }
        shotSpeedUpText = GameObject.Find("ShotSpeedUp");
        if (shotSpeedUpText != null)
        {
            shotSpeedUpText.SetActive(false);
        }
        allStatsUpText = GameObject.Find("AllStatsUp");
        if (allStatsUpText != null)
        {
            allStatsUpText.SetActive(false);
        }
    }

    private void Update()
    {
        if (textCountdown > 2)
        {
            damageUpText.SetActive(false);
            healthUpText.SetActive(false);
            fireRateUpText.SetActive(false);
            shotSpeedUpText.SetActive(false);
            allStatsUpText.SetActive(false);
        }

        textCountdown += Time.deltaTime;
        
    }

    private void PickItem()
    {
        pickedItem = items[Random.Range(0, items.Length)];
        print(pickedItem);
        GiveItem(pickedItem);
    }

    private void GiveItem(int pickedItem)
    {
        if (pickedItem == 0)
        {
            GameManager.Instance.playerDamage += 0.5f;
            
            damageUpText.SetActive(true);
            textCountdown = 0;

        }

        if(pickedItem == 1)
        {
            GameManager.Instance.playerMaxHealth += 2;

            healthUpText.SetActive(true);
            textCountdown = 0;

            GameManager.Instance.playerHealth += 3;
        }

        if (pickedItem == 2)
        {
            GameManager.Instance.playerFireCooldown -= 0.15f;

            fireRateUpText.SetActive(true);
            textCountdown = 0;
        }

        if (pickedItem == 3)
        {
            GameManager.Instance.playerShotSpeed += 1;

            shotSpeedUpText.SetActive(true);
            textCountdown = 0;
        }

        if (pickedItem == 4)
        {
            GameManager.Instance.playerDamage -= 0.3f;
            GameManager.Instance.playerMaxHealth += 2;
            GameManager.Instance.playerFireCooldown -= 0.1f;
            GameManager.Instance.playerShotSpeed += 0.8f;

            GameManager.Instance.playerHealth += 3;

            allStatsUpText.SetActive(true);
            textCountdown = 0;
        }

        hasCollided = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && hasCollided == false)
        {
            PickItem();

        }
    }
}
