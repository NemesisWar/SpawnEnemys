using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private SliderComponent _slider;
    [HideInInspector] public float Health => _health;

    private void Start()
    {
        _slider.StartValue(Health);
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
        _slider.ChangeValue(Health);
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
        _slider.ChangeValue(Health);
    }
}
