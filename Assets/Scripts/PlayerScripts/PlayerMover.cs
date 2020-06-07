using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0, _speed * Time.deltaTime);
            _animator.SetFloat("speed", _speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -_speed * Time.deltaTime);
            _animator.SetFloat("speed", _speed);
        }
        else
        {
            _animator.SetFloat("speed", 0);
        }
    }
}
