using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _target;

    [SerializeField] private float _speedRotatonCamera;
    [SerializeField] private float _minRotateX;
    [SerializeField] private float _maxRotateX;
    private float _horisontalinput;
    private float _RootX;
    private Vector3 _distance;

    private void OnValidate()
    {
        if (_minRotateX>=_maxRotateX)
        {
            _minRotateX = _maxRotateX - 1;
        }
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _RootX = transform.eulerAngles.y;
        _distance = _player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _horisontalinput = Input.GetAxis("Mouse X");
        if (_horisontalinput!=0)
        {
            _RootX += _horisontalinput * _speedRotatonCamera; 
        }

        Quaternion Rootation = Quaternion.Euler(0, _RootX, 0);
        transform.position = _player.transform.position - (Rootation * _distance);
        transform.LookAt(_target.transform);
        _player.transform.rotation = Rootation;
    }
}
