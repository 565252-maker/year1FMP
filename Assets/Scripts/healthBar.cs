using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public float Health, MaxHealth, Width, Height;

    [SerializeField]
    private RectTransform HealthBar;

    public TMPro.TMP_Text healthCount;
    public void SetmaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (health / MaxHealth) * Width;

        HealthBar.sizeDelta = new Vector2(newWidth, Height);
    }

    private void Update()
    {
        healthCount.text = $"{GameManager.Instance.playerHealth} / {GameManager.Instance.playerMaxHealth}";
    }
}
