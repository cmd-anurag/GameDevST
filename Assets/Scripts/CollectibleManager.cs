using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool allCoinsCollected = false;

    void Update() {
        if (transform.childCount == 0 && !allCoinsCollected)
        {
            allCoinsCollected = true;
        }
    }

}
