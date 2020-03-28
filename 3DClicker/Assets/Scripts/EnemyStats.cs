using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private float _timeToShoot;
    [SerializeField]
    private int _damage;

    [SerializeField]
    private int scoresForKill;

    [SerializeField] 
    private int _scoresForHit;


    public int GetHealth()
    {
        return _health;
    }

    public int GetScoresForHit()
    {
        return _scoresForHit;
    }

    public void SubtractHealth(int value)
    {
        _health -= value;
    }

    public int GetScoresForKill()
    {
        return scoresForKill;
    }

    public float GetTimeToShoot()
    {
        return _timeToShoot;
    }

    public int GetDamage()
    {
        return _damage;
    }
    

}
