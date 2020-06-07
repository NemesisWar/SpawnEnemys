using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmClip;
    [SerializeField] private float _pathTime;
    [SerializeField] private float _pathRunningTime;
    private float _minValue = 0.0f;
    private float _maхValue = 1.0f;
    private AudioSource _audioSource;
    private Coroutine _lowVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _audioSource.volume = _minValue;
            _audioSource.PlayOneShot(_alarmClip);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _pathRunningTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_minValue,_maхValue, _pathRunningTime/_pathTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _lowVolume = StartCoroutine(StopAlarm());
        }
    }

    private IEnumerator StopAlarm()
    {
        _pathRunningTime = _pathTime;
        while (_audioSource.volume !=0)
        {
            Debug.Log("Run");
            _pathRunningTime -= Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_minValue, _maхValue, _pathRunningTime / _pathTime);
            yield return null;
        }

        EndSound(_lowVolume);
    }

    private void EndSound(Coroutine coroutine)
    {
        _audioSource.Stop();
        StopCoroutine(_lowVolume);
    }
}
