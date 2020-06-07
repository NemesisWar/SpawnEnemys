using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private Coroutine _createCorotine;
    private void OnEnable()
    {
        _points = gameObject.GetComponentsInChildren<SpawnPoint>();
        foreach (var point in _points)
        {
            point.CreatedEnemy += OnCreatedEnemys;
        }
        if (_createCorotine == null)
        {
            _createCorotine = StartCoroutine(FindRandomPiontToCreateEmeny());
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.CreatedEnemy -= OnCreatedEnemys;
        }
    }

    private IEnumerator FindRandomPiontToCreateEmeny()
    {
        var waitForOneSeconds = new WaitForSeconds(2f);
        foreach (var point in _points)
        {
            point.CheckCreateEnemyInPoint();
            yield return waitForOneSeconds;
        }
    }

    private void OnCreatedEnemys()
    {
        foreach (var point in _points)
            if (point.EnemyHave == false) 
                return;
        CheckAndAddEnemys();
    }

    private void CheckAndAddEnemys()
    {
        if (_createCorotine != null)
        {
            StopCoroutine(_createCorotine);
            _createCorotine = null;
        }
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        CheckEnemesOnScene();
    }

    private void CheckEnemesOnScene()
    {
        foreach (var point in _points)
        {
            point.CheckEnemyinScene();
        }
    }
}
