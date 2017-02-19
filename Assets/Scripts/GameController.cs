using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController intstance;

    [SerializeField]
    private GameObject gameOverText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text bestScoreText;


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioSource music;

    private void Awake() {
        if (intstance == null)
            intstance = this;
        GetBestScore();
        music.Play();
    }

    public void EndGame() {
        gameOverText.SetActive(true);
        StartCoroutine(RestartLevel());
      
    }


    public void ChangeScore(int score) {
        scoreText.text = "Очки: " + score.ToString();
        SetBestScore(score);
    }

    private IEnumerator RestartLevel() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Gameplay");
    }

    private void SetBestScore(int score) {
        if (!PlayerPrefs.HasKey("Score") || PlayerPrefs.GetInt("Score") < score) {
            PlayerPrefs.SetInt("Score", score);
            bestScoreText.text = "Рекорд: " + score.ToString();
        }
    }

    private void GetBestScore() {
        if (PlayerPrefs.HasKey("Score")) {
            int score = PlayerPrefs.GetInt("Score");
            bestScoreText.text = "Рекорд: " + score.ToString();
        }
    }


}
