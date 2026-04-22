using UnityEngine;

[CreateAssetMenu( fileName = "Door", menuName = "ScriptableObjects/Door")]

public class DoorScriptable : ScriptableObject
{
    public RoomType roomType;
    public Sprite upDoor;
    public Sprite downDoor;
    public Sprite leftDoor;
    public Sprite rightDoor;
}
