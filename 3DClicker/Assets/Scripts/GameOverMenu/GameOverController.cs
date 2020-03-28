using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scores;
    private void Start()
    {

        int scores = FindObjectOfType<Player>().GetScores();
        _scores.text = "YOUR SCORES: "  + scores;

        if (scores > PlayerPrefs.GetInt("BestScores"))
        {
            Debug.Log("Saved new Scores");
            PlayerPrefs.SetInt("BestScores", scores);
        }
    }

    public void BackToMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
