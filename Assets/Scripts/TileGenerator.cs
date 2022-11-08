using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] TilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLenght = 100;

    [SerializeField] private Transform player;
    private int startTitles = 6;
    void Start()
    {
        for (int i = 0; i < startTitles; i++)
        {
            if (i == 0)
            {
                SpawnTile(4);
            }
            SpawnTile(Random.Range(0, TilePrefabs.Length-1));
        }
    }
    void Update()
    {
        if (player.position.z - 60 > spawnPos - (startTitles * tileLenght))
        {
            SpawnTile(Random.Range(0, TilePrefabs.Length-1));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject newxtTile = Instantiate(TilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(newxtTile);
        spawnPos += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
