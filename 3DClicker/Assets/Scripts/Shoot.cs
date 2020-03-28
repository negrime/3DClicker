using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Runtime.InteropServices;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private RotateToTarget _rotate;

    public delegate void EnemyDamaged(int scores);

    public static event EnemyDamaged EnemyDamagedInfo;
    
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    private void Start()
    {
        SetCursorPos(0,0);
        _rotate = GetComponent<RotateToTarget>();
    }

    public void Fire()
    {
        _rotate.SetRecoil(new Vector3(Random.Range(0.5f, 1f),Random.Range(1f, 2f),0));
        RaycastHit hit;
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (!objectHit.CompareTag("Enemy"))
            {
                return;
            }

            if (objectHit.GetComponent<IEnemy>().TryToKill())
            {
                EnemyDamagedInfo?.Invoke(objectHit.GetComponent<IEnemy>().GetScoresForKill());
            }
            else
            {
                EnemyDamagedInfo?.Invoke(objectHit.GetComponent<IEnemy>().GetScoresForHit());
            }
        }
    }




    
}
