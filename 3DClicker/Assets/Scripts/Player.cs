using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats _stats;
    private Shoot _shoot;

    private float _timeToShoot = 0.15f;
    private float _currentTime = 0;


    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField]
    private Animator _weaponAnimator;

    public delegate void UpdateScores(int scores);
    public static event UpdateScores ScoresChanged;
    public static Action<int> UpdateHealth;
    public static Action PlayerDie;

    [SerializeField]
    private GameObject[] DisableOjects;
    
    private void OnEnable()
    {
        Shoot.EnemyDamagedInfo += ShootOnEnemyDamagedInfo;
        Timer.TimesUp += StopGame;
    }

    private void OnDisable()
    {
        Shoot.EnemyDamagedInfo -= ShootOnEnemyDamagedInfo;
        Timer.TimesUp -= StopGame;
    }

    private void ShootOnEnemyDamagedInfo(int scores)
    {
        _stats.UpdateScores(scores);
        int scoresAmount = _stats.GetScores();
        ScoresChanged?.Invoke(scoresAmount);
    }

    private void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _shoot = GetComponent<Shoot>();
        UpdateHealth?.Invoke(_stats.GetHealth());
    }

    private void Update()
    {

        _currentTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _currentTime >= _timeToShoot)
        {
            _weaponAnimator.SetTrigger("Shoot");
            _currentTime = 0;
            _shoot.Fire();
        }
    }

    public int GetDamage()
    {
       return _stats.GetDamage();
    }


    public int GetScores()
    {
        return _stats.GetScores();
    }
    
    
    public void ApplyDamage(int damage)
    {
        _stats.UpdateHealth(-damage);
        UpdateHealth?.Invoke(_stats.GetHealth());
        if (!_stats.IsAlive())
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        PlayerDie?.Invoke();

        foreach (var item in DisableOjects)
        {
            item.SetActive(false);
        }

        this.enabled = false;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _gameOverMenu.SetActive(true);
    }
    
}
