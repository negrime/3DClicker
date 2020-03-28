using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private int _health;

    [SerializeField]
    private int _scores;

    [SerializeField]
    private int _damage;

    
    public void UpdateScores(int value)
    {
        _scores += value;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetScores()
    {
        return _scores;
    }

    public bool IsAlive()
    {
        return _health > 0;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void UpdateHealth(int value)
    {
        if (_health > 0)
        {
            _health += value;
        }
    }
    
    
}
