using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] maps;

    private void Awake()
    {
        int i = PlayerPrefs.GetInt("MapIndex", 0);
        Instantiate(maps[i]);
    }
}
