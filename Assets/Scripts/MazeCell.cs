using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject leftWall;

    [SerializeField]
    private GameObject rightWall;

    [SerializeField]
    private GameObject frontWall;

    [SerializeField]
    private GameObject backWall;

    [SerializeField]
    private GameObject unvisited;

    [SerializeField]
    private GameObject coinPrefab;

    public Transform Collectibles;

    public bool IsVisited { get; private set; }


    public void Visit()
    {
        IsVisited = true;
        unvisited.SetActive(false);

        // spawn a coin with a random chance
        if (Random.value <= 0.1f) {
            float x = transform.position.x;
            float z = transform.position.z;
            Vector3 spawnPos = new(x, 0.65f, z);
            GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.Euler(90, 0, 0));
            coin.transform.SetParent(Collectibles, true);
        }
    } 

    public void ClearLeftWall()
    {
        leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        backWall.SetActive(false);
    }
}
