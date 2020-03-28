using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IEnemy
{
    bool TryToKill();
    void Die();

    int GetScoresForHit();

    int GetScoresForKill();
}

