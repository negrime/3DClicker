using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _fpsText;
    private float _currentTime;
    private int _fpsCounter;
    void Start()
    {
        _currentTime = 0;
        _fpsCounter = 0;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        _fpsCounter++;
        if (_currentTime >= 1)
        {
            _fpsText.text = "FPS: " + _fpsCounter.ToString();
            _fpsCounter = 0;
            _currentTime = 0;
        }
    }
}
