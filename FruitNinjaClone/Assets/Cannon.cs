using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Sprite[] fruits;

    [SerializeField] private GameObject fruitsProjectile;

    [SerializeField] private float minHeight;
    
    [SerializeField] private float maxHeight;
    
    [SerializeField] private float lifeSpan=10f;
    // Start is called before the first frame update
    void OnEnable()
    {
        SpriteRenderer fruit = fruitsProjectile.GetComponent<SpriteRenderer>();
        fruit.sprite = fruits[Random.Range(0,fruits.Length)];
        Shoot();
    }

    private void Shoot()
    {
        var yay = Instantiate(fruitsProjectile,transform.position,transform.rotation);
        yay.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*Random.Range(minHeight,maxHeight), (ForceMode2D)ForceMode.Impulse);
        Destroy(yay,lifeSpan);
    }


}
