using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Player_explosion;
    public int score_value;
    private gameController gamecontroller;

    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag ("GameController");
        if (GameControllerObject != null)
        {
            gamecontroller = GameControllerObject.GetComponent<gameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy") || other.CompareTag("Boss"))
        {
            return;
        }
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            gamecontroller.addScore (score_value);
            if (other.CompareTag ("Player"))
            { 
                Instantiate(Player_explosion, other.transform.position, other.transform.rotation);
                gamecontroller.GameOver();
                gamecontroller.RestartButtonActivate();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
