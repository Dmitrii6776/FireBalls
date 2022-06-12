using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    

    private Vector3 _moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        _moveDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    
    {
        if (other.gameObject.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out ObstacleCollisions obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        var rigitBody = GetComponent<Rigidbody>();
        rigitBody.isKinematic = false;
        rigitBody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceRadius);
    }
}
