using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveBlock : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Transform _transform;

    public SpriteRenderer Sprite => _sprite;
    public Transform Transform => _transform;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    }

    public abstract void OnBlock();
    public abstract void OffBlock();
}
