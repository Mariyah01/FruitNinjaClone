using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitSpawner;
    [SerializeField] private float spawnRate=5f;
    private GameObject point;

    private void Start()
    {
        StartCoroutine(spawnFruit());
    }

    private IEnumerator spawnFruit()
    {
        while (true)
        {
          point = fruitSpawner[Random.Range(0, fruitSpawner.Length)];
                  point.SetActive(true);
                  yield return new WaitForSeconds(1f);
                  point.SetActive(false);
                  yield return new WaitForSeconds(spawnRate);  
        }
    }
}
