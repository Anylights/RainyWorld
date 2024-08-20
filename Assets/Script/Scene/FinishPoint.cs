using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private bool isSuccess = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spaceship"))
        {
            if (!isSuccess)
            {
                isSuccess = true;
                SceneController.instance.NextScene();
            }
        }
    }

}
