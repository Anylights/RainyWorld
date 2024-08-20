using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private int Number;
    public GameObject Entrance;


    private void OnTriggerEnter2D(Collider2D CoinCol)
    {
        if (CoinCol.tag == "item")
        {
            Number += 1;
            Destroy(CoinCol.gameObject);
            Debug.Log("This works at least....");
        }
    }

    void Update()
    {
        if (Number > 2)
        {
            Debug.Log("Collection system works!!!");
            Entrance.SetActive(true);
        }
        else
        {
            Debug.Log("NO,THERE IS AN ISSUE!!!");
        }
    }



}
