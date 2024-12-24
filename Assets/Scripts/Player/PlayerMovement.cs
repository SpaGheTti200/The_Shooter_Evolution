using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Camera _mainCamera;

    [SerializeField] private Vector2 xClamp;
    [SerializeField] private Vector2 yClamp;

    [HideInInspector] public Vector2 dir;
    public float speed = 5f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        _moveAction.performed += OnMove;
        _moveAction.canceled += OnMove;
    }

    private void OnDisable()
    {
        _moveAction.performed -= OnMove;
        _moveAction.canceled -= OnMove;
    }

    private void Update()
    {
        dir = dir.normalized;
    }

    private void FixedUpdate()
    {
        MoveHandler();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

  

    private void MoveHandler()
    {
        Vector2 newPosition = _rb2d.position + dir * (speed * Time.fixedDeltaTime);

        float clampedX = Mathf.Clamp(newPosition.x, xClamp.x, xClamp.y);
        float clampedY = Mathf.Clamp(newPosition.y, yClamp.x, yClamp.y);

        _rb2d.MovePosition(new Vector2(clampedX, clampedY));
    }


   
}
