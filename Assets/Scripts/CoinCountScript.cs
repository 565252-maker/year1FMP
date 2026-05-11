using UnityEngine;

public class CoinCountScript : MonoBehaviour
{
    TMPro.TMP_Text coins;
    

    private void Awake()
    {
        coins = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        coins.text = $"{GameManager.Instance.coinCount}";
    }
}
