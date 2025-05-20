using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI overText;
    public Button reStartG;

    public int score;
    public bool gameAct;
    public GameObject titleScreen;
    public int lives;

    public GameObject pauseScreen;
    public bool pause;
    


    public void StartGame(int diff)
    {
        lives = 3;
        UpdateLives();
        titleScreen.gameObject.SetActive(false);
        gameAct = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        spawnRate /= diff;
        UpdateScore(0);
        livesText.text = "Lives: " + lives;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Paused();
    }

    public void Paused()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&gameAct && !pause)
        {
            pause = true;
            gameAct = false;
            Time.timeScale = 0.0f;
            pauseScreen.SetActive(true);
            Debug.Log("paue");
        }

        else if(Input.GetKeyDown(KeyCode.Space)&&!gameAct &&pause)
        {
            pause = false;
            gameAct = true;
            Time.timeScale = 1.0f;
            pauseScreen.SetActive(false);
            Debug.Log("uno");
        }
    }

    IEnumerator SpawnTarget()
    {
        while (gameAct)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(1);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives()
    {
        if(gameAct)
        {
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives < 0)
            {
                gameAct = false;
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        overText.gameObject.SetActive(true);
        reStartG.gameObject.SetActive(true);
        
    }

    public void ReGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
