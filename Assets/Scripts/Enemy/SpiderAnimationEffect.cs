using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEffect : MonoBehaviour
{
    private SpiderScript spider;

    private void Start()
    {
        spider = transform.parent.GetComponent<SpiderScript>(); //parentin componenetina eristik
    }
    void Fire()
    {
        Debug.Log("saldirildi");
        spider.Attack(); 
    }
}
