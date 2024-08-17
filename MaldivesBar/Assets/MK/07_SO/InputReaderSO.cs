using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
{
    private Controls _controls;
    public Vector2 MousePos { get; private set; }
    public event Action<bool> OnClickEvent;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Player.Enable();
        _controls.Player.SetCallbacks(this);
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePos = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            OnClickEvent?.Invoke(true);
        }
        else
        {
            OnClickEvent?.Invoke(false);
        }
    }
}