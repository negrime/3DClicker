using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float timeToSpawn;
    
    [SerializeField] 
    private GameObject _commonSoldier;
   
    [SerializeField]
    private Transform[] _spawnPositions;

    
    private Dictionary<Transform, IEnemy> _enemiesPosition = new Dictionary<Transform, IEnemy>();


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
        foreach (var t in _spawnPositions)
        {
            _enemiesPosition.Add(t, null);
        }

        StartCoroutine(nameof(Spawn));
    }
    

    private IEnumerator Spawn()
    {
        while (true)
        {
                
            yield return new WaitForSeconds(timeToSpawn);
            Transform newTransform =  transform;


       
             Transform randomTransform = _spawnPositions[Random.Range(0, _spawnPositions.Length)];
             if (_enemiesPosition[randomTransform] == null)
             {
                 newTransform = randomTransform;
             }
             else
             {
                 if (_enemiesPosition[randomTransform].Equals(null))
                 {
                     _enemiesPosition[randomTransform] = null;
                 }
                 
                 //Если все позиции для спауна заняты, мы спауним еще одного противнкиа рядом 
                 newTransform.position = new Vector3(randomTransform.position.x + Random.Range(1.8f, 4f),
                     randomTransform.position.y, randomTransform.position.z + Random.Range(1.8f, 3f));
             }
          

            GameObject go = Instantiate(_commonSoldier, newTransform.position, Quaternion.identity);
            _enemiesPosition[newTransform] = go.GetComponent<CommonSoldier>();
        }
    }
    
}
