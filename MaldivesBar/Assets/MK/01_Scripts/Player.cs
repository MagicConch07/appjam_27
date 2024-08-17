using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private LayerMask _objLayer;

    private Camera _camera;
    private GameObject _selectObject = null;

    private bool _isClicking = false;

    private void Awake()
    {
        _camera = Camera.main;

        _inputReader.OnClickEvent += HandleClick;
    }

    private void HandleClick(bool isClick)
    {
        _isClicking = isClick;
    }

    private void Update()
    {
        SelectObj();
        MoveObj();
    }

    private void SelectObj()
    {
        if (_isClicking == false) return;
        RaycastHit2D[] hits = new RaycastHit2D[1];

        int hit = Physics2D.RaycastNonAlloc(GetMousePosition(), Vector3.forward, hits, Mathf.Infinity, _objLayer);

        if (hit >= 1)
        {
            _selectObject = hits[0].collider.gameObject;
        }
    }

    private void MoveObj()
    {
        if (_isClicking == false || _selectObject == null) return;

        _selectObject.transform.position = GetMousePosition();
    }

    private Vector2 GetMousePosition()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(_inputReader.MousePos);
        return mousePos;
    }
}
