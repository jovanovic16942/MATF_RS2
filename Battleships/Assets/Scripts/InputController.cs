using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _cameraRoot;
    [SerializeField] private GameObject _camera;

    private float _posX, _posY;
    private bool _drag;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _posX = Input.mousePosition.x;
            _posY = Input.mousePosition.y;
            _drag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _drag = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (_drag)
            {
                float mouseDeltaX = Input.mousePosition.x - _posX;
                float mouseDeltaY = _posY - Input.mousePosition.y;
                _posX = Input.mousePosition.x;
                _posY = Input.mousePosition.y;
                _cameraRoot.transform.Rotate(mouseDeltaY * Time.deltaTime * 20, mouseDeltaX * Time.deltaTime * 20, 0);
            }
        }

        if (Input.mouseScrollDelta.y != 0) {
            _camera.transform.position += _cameraRoot.transform.forward * Input.mouseScrollDelta.y;
        }
        
    }
}
