using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    GameObject[] Doors;

    private void Start()
    {
        Doors = GameObject.FindGameObjectsWithTag("Door");
        print(Doors);
       
    }
    public void EnemiesAliveCheck(int enemiesAlive)
    {
        if(enemiesAlive != 0)
        {
            foreach (GameObject obj in Doors)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in Doors)
            {
                obj.SetActive(true);
            }
        }
    }
}
