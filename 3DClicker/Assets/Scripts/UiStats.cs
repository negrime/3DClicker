using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _healthTxt;
    
    [SerializeField]
    private  TextMeshProUGUI _scoresTxt;
    

    private void OnEnable()
    {
        Player.ScoresChanged += UpdateScores;
        Player.UpdateHealth += UpdateHealth;
    }
    private void OnDisable()
    {
        Player.ScoresChanged -= UpdateScores;
        Player.UpdateHealth -= UpdateHealth;
    }

    private void Start()
    {
        UpdateScores(0);
    }
    
    private void UpdateHealth(int health)
    {
        _healthTxt.text = "Health: " + health;
    }


    private void UpdateScores(int scores)
    {
        _scoresTxt.text = "Scores: " + scores;
    }

    
}
