using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderComponent : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _pathTime;
    [SerializeField] private float _pathRunningTime;
    private Coroutine _coroutine;
    private float _prevousValue;
    private float _value;
    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
    }

    public void StartValue(float Value)
    {
        _slider.value = Value;
    }

    public void ChangeValue(float Value)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _prevousValue = _slider.value;
        _value = Value;
        _coroutine = StartCoroutine(LerpChangeHealth(_value, _prevousValue));
    }

    private IEnumerator LerpChangeHealth(float Value, float PriviousValue)
    {
        _pathRunningTime = _pathTime;
        while (_slider.value != _value)
        {
            _pathRunningTime -= Time.deltaTime;
            _slider.value = Mathf.Lerp(Value, PriviousValue, _pathRunningTime / _pathTime);
            yield return null;
        }
        StopValueChanged(_coroutine);
    }

    private void StopValueChanged(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        _coroutine = null;
    }
}
