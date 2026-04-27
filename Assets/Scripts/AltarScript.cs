using NUnit.Framework;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    int[] items = new int[5];
    int pickedItem;

    private void PickItem()
    {
        pickedItem = items[Random.Range(0, items.Length)];

    }

    private void GiveItem(int pickedItem)
    {
        if (pickedItem == 0)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

        }
    }
}
