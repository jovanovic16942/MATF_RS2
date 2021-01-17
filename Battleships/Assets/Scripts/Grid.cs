using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Vector3Int _size;
    public Vector3Int Size {
        get { return _size; }
    }
    [SerializeField] private GridCell _gridCellPrefab;

    private GridCell[][][] _grid; 

    private void Awake()
    {
        // Instantiate grid cells
        _grid = new GridCell[_size.x][][];
        for (int i = 0; i < _size.x; i++)
        {
            _grid[i] = new GridCell[_size.y][];
            for (int j = 0; j < _size.y; j++)
            {
                _grid[i][j] = new GridCell[_size.z];
                for (int k = 0; k < _size.z; k++)
                {
                    GridCell instance = Instantiate(_gridCellPrefab, new Vector3(i, j, k), Quaternion.identity, transform);
                    instance.Selected += OnGridCellSelected;
                    _grid[i][j][k] = instance;
                }
            }
        }

        EmptySpace.Pressed += ClearSelection;
    }

    private GridCell _selectedCell;
    private void OnGridCellSelected(GridCell gridCell)
    {
        Debug.Log("OnGridCellSelected");

        if (_selectedCell)
        {
            _selectedCell.Select(false);
        }

        _selectedCell = gridCell;
        gridCell.Select(true);
    }

    public void ClearSelection() 
    {
        Debug.Log("ClearSelection");      
      
        if (_selectedCell)
        {
            _selectedCell.Select(false);
            _selectedCell = null;
        }
    }
}