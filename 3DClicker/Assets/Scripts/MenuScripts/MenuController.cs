using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private TextMeshProUGUI _bestScoreText;


    private const string _ToAuthorTrigger = "Author";
    private const string _FromAuthorTrigger = "FromAuthor";

    private void Start()
    {
        if (PlayerPrefs.GetInt("BestScores") != 0)
        {
            _bestScoreText.enabled = true;
            _bestScoreText.text = "BEST RESULT: " + PlayerPrefs.GetInt("BestScores");
        }

    }

    public void PlayButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void AboutAuthorClick()
    {
        _animator.SetTrigger(_ToAuthorTrigger);
    }
    public void NoProblemClick()
    {
        _animator.SetTrigger(_FromAuthorTrigger);
    }

    public void Exit()
    { 
        Application.Quit();
    }
    
}
