using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDoor : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private bool _isOpen = false;
    private Coroutine _coroutineOpenDoor;
    private Coroutine _coroutineCloseDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isOpen)
        {
            _coroutineOpenDoor = StartCoroutine(OpenDoor());
        }
        if (_isOpen)
        {
            _coroutineCloseDoor = StartCoroutine(CloseDoor());
        }
    }

    private void WhenStopCorutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator OpenDoor()
    {
        while (!_isOpen)
        {
            if (_door.eulerAngles.y < 90)
            {
                _door.Rotate(0, 50f * Time.deltaTime, 0);
            }

            else
            {
                _isOpen = true;
            }
            yield return null;
        }
        WhenStopCorutine(_coroutineOpenDoor);
    }

    private IEnumerator CloseDoor()
    {
        while (_isOpen)
        {
            if (_door.eulerAngles.y > 1)
            {
                _door.Rotate(0, -50f * Time.deltaTime, 0);
            }

            else
            {
                _isOpen = false;
            }
            yield return null;
        }
        WhenStopCorutine(_coroutineCloseDoor);
    }
}
