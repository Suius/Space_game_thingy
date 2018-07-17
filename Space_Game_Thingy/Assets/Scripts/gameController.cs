using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject Boss;
    public Vector3 spawnValues;
    public int hazardCount;
    public int boss_score_ready;
    public float waitTime;
    public float startWait;
    public float waveWait;
    public Text scoretext;
    private int score;
    private Boss_Battle bossbattle;
    public GameObject RestartButton;
    public GameObject BackToMenuButton;
    public Text GameOverText;
    public Text Boss_defeated;
    private bool Gameover;
    private bool Boss_Spawned;

    private void Start()
    {
        Boss_defeated.text = "";
        Boss_Spawned = false;
        GameOverText.text = "";
        Gameover = false;
        score = 0;
        RestartButton.SetActive(false);
        BackToMenuButton.SetActive(false);
        updateScore();
       StartCoroutine (spawnWaves());
    }
    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!Gameover)
        {
            Boss_defeated.text = "";
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards [Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(waitTime);   
            }
            SpawnBoss();
            while (Boss_Spawned)
            {
                yield return new WaitForSeconds(3);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void RestartButtonActivate ()
    {
        RestartButton.SetActive(true);
        BackToMenuButton.SetActive(true);
    }

    public void addScore(int NewScoreValue)
    {
        score += NewScoreValue;
        updateScore();
    }

    void updateScore()
    {
        scoretext.text = "Score " + score;
    }

    private void SpawnBoss()
    {
        if (score >= boss_score_ready && Boss_Spawned == false)
        {
            Boss_Spawned = true;
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(Boss, spawnPosition, spawnRotation);
            boss_score_ready += 250;            
        }
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        Boss_defeated.text = "";
        Gameover = true;
    }

    public void Congratz()
    {
        Boss_defeated.text = "Congratulations, you've defeated the commander! Prepare for the next wave.";
    }

    public void BossDED()
    {
        Boss_Spawned = false;
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene("Some_Scene");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
