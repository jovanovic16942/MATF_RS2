using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Grid _playerGrid;
    [SerializeField] private Grid _enemyGrid;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _cameraRoot;
    private int _offset = 2;

    private void Start()
    {
        // Initialize grid
        _enemyGrid.transform.position += new Vector3(_playerGrid.Size.x + _offset, 0, 0);

        // Initialize camera position
        Vector3 gridCenter = new Vector3(_playerGrid.Size.x, _playerGrid.Size.y / 2f, _playerGrid.Size.z / 2f);
        _cameraRoot.transform.position = gridCenter;
        _camera.transform.position += new Vector3(0, 0, -15);
    }

    // TODO
    // State machine represents game loop

    /*
        S0 - Setup phase - Both players are setting up their boards
        P1 - Player 1 is playing his turn
        P2 - Player 2 is playing his turn

        S0 -> P1 <-> P2
    */
}
