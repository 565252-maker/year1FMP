using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public enum RoomType
{
    Regular,
    Altar,
    Shop,
    Boss
}

public class Cell : MonoBehaviour
{
    public RoomType roomType;

    public int index;
    public int value;

    public SpriteRenderer spriteRenderer;

    public List<int> cellList = new List<int>();

    public void SetSpecialRoomSprite(Sprite icon)
    {
        spriteRenderer.sprite = icon;
    }

    public void SetRoomType(RoomType newRoomType)
    {
        roomType = newRoomType;
    }
    


    
}
