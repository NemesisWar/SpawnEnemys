using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _changeHealth;
    [HideInInspector] public float Health => _health;

    public event UnityAction ChangeHealth
    {
        add => _changeHealth.AddListener(value);
        remove => _changeHealth.RemoveListener(value);
    }

    private void OnValidate()
    {
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void TakeDamage(float Damage)
    {
        if (_health < Damage)
        {
            _health = 0;
        }
        else
        {
            _health -= Damage;
        }
        _changeHealth.Invoke();
    }

    public void AddHelth(float AddHealth)
    {
        if (_health + AddHealth > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += AddHealth;
        }
        _changeHealth.Invoke();
    }
}
