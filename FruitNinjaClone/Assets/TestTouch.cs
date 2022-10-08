using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    private InputManager _inputManager;
    private Camera cameraMain;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Vector2 screenCoordinates = new Vector2(screenPosition.x, screenPosition.y);
        Vector2 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        transform.position = worldCoordinates;
    }
}
