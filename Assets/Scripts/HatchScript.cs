using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchScript : MonoBehaviour
{
    GameObject player;
    GameObject playerCam;
    GameObject altar;

    private GameObject damageUpText;
    private GameObject healthUpText;
    private GameObject fireRateUpText;
    private GameObject shotSpeedUpText;
    private GameObject allStatsUpText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCam = GameObject.Find("Main Camera");
        altar = GameObject.FindGameObjectWithTag("Altar");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == ("Player"))
        {
            if(GameManager.Instance.currentFloor == 1)
            {
                SceneManager.LoadScene("Floor 2");
            }
            if (GameManager.Instance.currentFloor == 2)
            {
                SceneManager.LoadScene("Floor 3");
            }
            if (GameManager.Instance.currentFloor == 3)
            {
                SceneManager.LoadScene("Floor 4");
            }
            GameManager.Instance.currentFloor += 1;
        }
    }
}
