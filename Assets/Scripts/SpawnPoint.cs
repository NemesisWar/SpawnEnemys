using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyCreated = new UnityEvent();
    public bool EnemyHave { get; private set; }


    public event UnityAction CreatedEnemy
    {
        add => _enemyCreated.AddListener(value);
        remove => _enemyCreated.RemoveListener(value);
    }

    public void CheckCreateEnemyInPoint()
    {
        EnemyHave = gameObject.GetComponent<InstantiateEnemy>().IsEnemyThisPoint;
        if (EnemyHave)
        {
            return;
        }
        else
        {
            EnemyHave = true;
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        _enemyCreated.Invoke();
    }

    public void CheckEnemyinScene()
    {
        EnemyHave = gameObject.GetComponent<InstantiateEnemy>().IsEnemyThisPoint;
    }
}
