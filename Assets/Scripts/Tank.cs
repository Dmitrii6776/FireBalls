using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private Bullet _bulletTeamPlate;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeAfterShoots += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoots > _delayBetweenShots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoots = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTeamPlate, _shootPoint.position, Quaternion.identity);
    }
}
