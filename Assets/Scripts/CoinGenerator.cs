﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObjects();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObjects();
        coin2.transform.position = new Vector3(
            startPosition.x - distanceBetweenCoins, 
            startPosition.y, 
            startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObjects();
        coin3.transform.position = new Vector3(
            startPosition.x + distanceBetweenCoins,
            startPosition.y,
            startPosition.z);
        coin3.SetActive(true);
    }
}
