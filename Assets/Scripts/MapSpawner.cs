using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] maps;
    [SerializeField] PlayerVictories victories;

    private void Awake()
    {
        int i = victories.mapIndex;
        Instantiate(maps[i]);
    }
}
