using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class coinScript : MonoBehaviour
{
    

    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == ("Player"))
        {
            GameManager.Instance.coinCount += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
