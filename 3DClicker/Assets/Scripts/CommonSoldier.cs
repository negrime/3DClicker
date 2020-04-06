using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CommonSoldier : MonoBehaviour, IEnemy
{
    [SerializeField]
    private ParticleSystem _blood;
   
    [SerializeField]
    private ParticleSystem _fire;

    
    [SerializeField]
    private Transform _bloodTransform;
    
    private EnemyStats _stats;
    private Player _player;
    private Animator _animator;

    [SerializeField]
    private const string _shootingTrigger ="Shoot";


    private void OnEnable()
    {
        Player.PlayerDie += StopGame;
    }

    private void OnDisable()
    {
        Player.PlayerDie -= StopGame;
    }

    private void StopGame()
    {
        StopAllCoroutines();
    }

    void Start()
    {
        _stats = GetComponent<EnemyStats>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>(); 

        transform.LookAt(_player.transform);
        StartCoroutine(nameof(Shoot));
    }


    public bool TryToKill()
    {
        var go = Instantiate(_blood,  _bloodTransform.position, Quaternion.Euler(new Vector3(0, _player.transform.forward.y, 0)));
        go.transform.rotation = Quaternion.Euler(_player.transform.forward);
        int damage = _player.GetDamage();
        _stats.SubtractHealth(damage);
        if (_stats.GetHealth() <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public int GetScoresForKill()
    {
        return _stats.GetScoresForKill();
    }

    public int GetScoresForHit()
    {
        return _stats.GetScoresForHit();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_stats.GetTimeToShoot());
            _animator.SetTrigger("Shoot");
            _fire.Play();
            _player.ApplyDamage(_stats.GetDamage());
        }
    }
    
}
