using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public event Action<GridCell> Selected;

    [SerializeField] private GameObject _selection;
    [SerializeField] private GameObject _hover;

    private MeshRenderer _renderer;
    private MaterialPropertyBlock _materialBlock;
    
    private void Start()
    {
        _selection.SetActive(false);
        _hover.SetActive(false);
        _renderer = GetComponent<MeshRenderer>();
        _materialBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_materialBlock);
    }

    private void Update()
    {
        float speed = 1.0f;
        float offset = (transform.position.x / 8) + (transform.position.y / 8) + (transform.position.z / 8);
        float sin = Mathf.Sin((Time.realtimeSinceStartup + offset) * speed);
        float max = 0.02f;
        float amount = 0.01f + (sin + 1) * 0.5f * max;

        _materialBlock.SetColor("_Color", new Color(1f, 1f, 1f, amount));
        _renderer.SetPropertyBlock(_materialBlock);
    }

    private void OnMouseDown()
    {
        Selected?.Invoke(this);
    }

    private void OnMouseOver() {
        _hover.SetActive(true);
    }
    private void OnMouseExit() {
        _hover.SetActive(false);
    }

    public void Select(bool state)
    {
        _selection.SetActive(state);
    }
}
