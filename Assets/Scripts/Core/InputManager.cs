using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private Vector2 _moveInput;

    private float _verticleMovement;
    private float _horizontalMovement;

    public float VertcalMove => _verticleMovement;
    public float HorizontalMove => _horizontalMovement;

    private void OnEnable() 
    {
        if(_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += i =>  HandleMoveInput(i.ReadValue<Vector2>());
        }   

        _playerControls.Enable();
    }

    private void OnDisable() 
    {
        _playerControls.Disable();    
    }

    private void HandleMoveInput(Vector2 value)
    {
        _moveInput = value;
        _horizontalMovement = _moveInput.x;
        _verticleMovement = _moveInput.y;
    }
}
