using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    public event UnityAction<Block> BulletHit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {

        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
        var renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }
}
