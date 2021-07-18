using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    // 0 --> left, 1 --> forward, 2 --> current
    [SerializeField] private GameObject[] _tiles = new GameObject[3];
    private static TileSpawner _instance;


    public static TileSpawner Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<TileSpawner>();
            return _instance;
        }
    }

    void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            int rnd = Random.Range(0, 2);
            // 0 --> left, 1 --> forward
            Spawn(rnd);
        }
    }

    public void Spawn(int position)
    {
        Transform tile = _tiles[2].transform.GetChild(0);
        Vector3 attachPosition = tile.GetChild(position).position;
        _tiles[2] = Instantiate(_tiles[position], attachPosition, Quaternion.identity);

        int spawnGem = Random.Range(0,5);
        if (spawnGem == 0)
        {
            _tiles[2].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
