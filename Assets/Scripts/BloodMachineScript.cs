using UnityEngine;

public class BloodMachineScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == ("Player"))
        {
            if (GameManager.Instance.coinCount >= 3 && GameManager.Instance.playerHealth != GameManager.Instance.playerMaxHealth)
            {
                GameManager.Instance.coinCount -= 3;
                GameManager.Instance.playerHealth += 1;
            }
        }
    }
}
