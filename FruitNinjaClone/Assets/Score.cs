using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int fruitScore=0;

    private void Update()
    {
        scoreText.text = $"Score: {fruitScore}";
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Fruit"))
    //     {
    //         fruitScore++;
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Fruit"))
        {
            fruitScore++;
        }
    }
}
