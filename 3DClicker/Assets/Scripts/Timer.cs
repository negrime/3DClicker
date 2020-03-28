using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action TimesUp;
    
    [SerializeField]
    private TextMeshProUGUI _timerText;

    [SerializeField] 
    private float _StartTime;
    
    private float _currentTime;
    void Start()
    {
        _currentTime = _StartTime;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        _timerText.text = "Time: " + String.Format("{0:f}", _currentTime);

        if (_currentTime <= 0)
        {
            TimesUp?.Invoke();
        }
    }
}
