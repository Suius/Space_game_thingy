using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private gameController gamecontroller;
    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            gamecontroller = GameControllerObject.GetComponent<gameController>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        if (other.CompareTag("Boss"))
        {
            gamecontroller.BossDED();
        }
    }
}