using NUnit.Framework;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ShopAltarScript : MonoBehaviour
{
    int[] items = new int[5];
    int pickedItem;

    

    private GameObject damageUpText;
    private GameObject healthUpText;
    private GameObject fireRateUpText;
    private GameObject shotSpeedUpText;
    private GameObject allStatsUpText;

    float textCountdown;
    
    private void Start()
    {
       
        
        
        items[0] = 0;
        items[1] = 1;
        items[2] = 2;
        items[3] = 3;
        items[4] = 4;

        damageUpText = GameObject.Find("DamageUp");
       
        healthUpText = GameObject.Find("HealthUp");
       
        fireRateUpText = GameObject.Find("FireRateUp");
       
        shotSpeedUpText = GameObject.Find("ShotSpeedUp");
        
        allStatsUpText = GameObject.Find("AllStatsUp");
       
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

        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            if(GameManager.Instance.coinCount >= 15)
            {
                PickItem();
                GameManager.Instance.coinCount -= 15;
            }
            

        }
    }
}
