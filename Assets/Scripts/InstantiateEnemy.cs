using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyThisPoint;
    public bool IsEnemyThisPoint { get; private set; }

    public void EnemyInstantiate()
    {
        _enemyThisPoint = Instantiate(_enemy, gameObject.transform.position, Quaternion.identity);
        IsEnemyThisPoint = true;
    }

    public void Update()
    {
        if (_enemyThisPoint != null)
        {
            IsEnemyThisPoint = true;
        }
        else
        {
            IsEnemyThisPoint = false;
        }
    }
}
