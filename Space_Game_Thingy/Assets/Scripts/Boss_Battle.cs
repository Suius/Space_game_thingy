using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Battle : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Player_explosion;
    private gameController gamecontroller;
    public int score_value;
    public int Lives;

    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            gamecontroller = GameControllerObject.GetComponent<gameController>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag ("Boss") || other.CompareTag("Enemy")|| other.CompareTag("Boundary"))
        {
            return;
        }
        Destroy(other.gameObject);
        Lives--;
        if (Lives == 0)
        {
            gamecontroller.BossDED();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            gamecontroller.addScore(score_value);
            gamecontroller.Congratz();
        }
    }
}
