using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winningText;

    public Button restartButton;
    public Button quitButton;
    public TextMeshProUGUI pauseText;
    private bool isPaused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        } 
    }

    void PauseGame() {
        pauseText.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame() {
        pauseText.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider player) {
        Destroy(gameObject);
        if (gameObject.CompareTag("Player")) {
            GameOver();
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Win() {
        Time.timeScale = 0;
        winningText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    
}
