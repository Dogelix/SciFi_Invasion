using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    public float _moveSpeed = 7f;

    private InputManager _inputManager;
    private Vector3 _moveDir;
    private Transform _camera;
    private Rigidbody _rigidBody;

    private void Awake() 
    {
        _inputManager = gameObject.GetComponent<InputManager>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();    
        _camera = transform.GetComponentInChildren<Camera>().transform;
    }

    private void FixedUpdate() 
    {
        HandleMovement();    
    }

    public void HandleMovement()
    {
        _moveDir = _camera.forward * _inputManager.VertcalMove;
        _moveDir += _camera.right * _inputManager.HorizontalMove;
        _moveDir.Normalize();
        _moveDir.y = 0;

        Vector3 velocity = _moveDir * _moveSpeed;
        _rigidBody.velocity = velocity;
    }
}
