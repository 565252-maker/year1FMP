using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MapGenerator : MonoBehaviour
{
    private int[] floorplan;
    public int[] getFloorPlan => floorplan;


    private int floorPlanCount;
    private int minRooms;
    private int maxRooms;
    private List<int> endRooms;

    private int bossRoomIndex;
    private int shopRoomIndex;
    private int altarRoomIndex;

    public Cell cellPrefab;
    private float cellSize;
    private Queue<int> cellQueue;
    private List<Cell> spawnedCells;

    public List<Cell> getSpawnedCells => spawnedCells;

    public static MapGenerator instance;

    [Header("Sprite References")]
    [SerializeField] private Sprite altar;
    [SerializeField] private Sprite shop;
    [SerializeField] private Sprite boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        minRooms = 7;
        maxRooms = 10;
        cellSize = 0.16f;
        spawnedCells = new();

        SetupDungeon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManualGenerate()
    {
         SetupDungeon();      
    }

    public void SetupDungeon() 
    { 
        for(int i = 0; i < spawnedCells.Count; i++)
        {
            Destroy(spawnedCells[i].gameObject);
        }

        spawnedCells.Clear();

        floorplan = new int[100];
        floorPlanCount = default;
        cellQueue = new Queue<int>();
        endRooms = new List<int>();

        VisitCell(45);

        GenerateDungeon();
    }

    void GenerateDungeon() 
    {
        while (cellQueue.Count > 0)
        {
            int index = cellQueue.Dequeue();
            int x = index % 10;

            bool created = false;

            if (x > 1) created |= VisitCell(index - 1);
            if (x < 9) created |= VisitCell(index + 1);
            if (index > 20) created |= VisitCell(index - 10);
            if (index < 70) created |= VisitCell(index + 10);

            if(created == false)
                endRooms.Add(index);
        }

        if(floorPlanCount < minRooms)
        {
            SetupDungeon();
            return;
        }

        SetupSpecialRooms();
    }

    void SetupSpecialRooms() 
    {
        bossRoomIndex = endRooms.Count > 0 ? endRooms[endRooms.Count - 1] : -1;

        if (bossRoomIndex != -1)
        {
            endRooms.RemoveAt(endRooms.Count - 1);
        }

        altarRoomIndex = RandomEndRoom();
        shopRoomIndex = RandomEndRoom();

        if (altarRoomIndex == -1 || shopRoomIndex == -1 || bossRoomIndex == -1)
        {
            SetupDungeon();
            return;
        }

        UpdateSpecialRoomVisuals();
        RoomManager.instance.SetupRooms(spawnedCells);
    }

    void UpdateSpecialRoomVisuals() 
    {
        foreach(var cell in spawnedCells)
        {
            if(cell.index == altarRoomIndex)
            {
                cell.SetSpecialRoomSprite(altar);
                cell.SetRoomType(RoomType.Altar);
            }

            if(cell.index == shopRoomIndex)
            {
                cell.SetSpecialRoomSprite(shop);
                cell.SetRoomType(RoomType.Shop);
            }

            if(cell.index == bossRoomIndex)
            {
                cell.SetSpecialRoomSprite(boss);
                cell.SetRoomType(RoomType.Boss);
            }
        }
    }

    int RandomEndRoom()
    {
        if (endRooms.Count == 0) return -1;

        int randomRoom = Random.Range(0, endRooms.Count);
        int index = endRooms[randomRoom];

        endRooms.RemoveAt(randomRoom);

        return index;
    }

    private int GetNeighbourCount(int index)
    {
        return floorplan[index - 10] + floorplan[index - 1] + floorplan[index + 1] + floorplan[index + 10];
    
    }

    private bool VisitCell(int index)
    {
        if (floorplan[index] != 0 || GetNeighbourCount(index) > 1 || floorPlanCount > maxRooms || Random.value > 0.5f)
            return false;
      
        cellQueue.Enqueue(index);
        floorplan[index] = 1;
        floorPlanCount++;

        SpawnRoom(index);

        return true;
    
    }

    private void SpawnRoom(int index)
    {
        int x = index % 10;
        int y = index / 10;
        Vector2 position = new Vector2(x * cellSize, -y * cellSize);

        Cell newCell = Instantiate(cellPrefab, position, Quaternion.identity);
        newCell.value = 1;
        newCell.index = index;
        newCell.SetRoomType(RoomType.Regular);

        newCell.cellList.Add(index);

        spawnedCells.Add(newCell);
    }

    
}
