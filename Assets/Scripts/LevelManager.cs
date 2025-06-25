using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    public Transform spawnPosition;

    void OnEnable()
    {
        Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);
    }
}
