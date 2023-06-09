using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Camerashake : MonoBehaviour
{
    Vector3 normalPos;
    public bool _CanShake = false;
    float explosionTimer;
    float explosionTimerMax;
    public float _Shake;

    void Start()
    {
        normalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        explosionTimerMax = 0.15f;
        explosionTimer = explosionTimerMax;
    }

    void Update()
    {
        if (_CanShake == true)
        {
            transform.localPosition = normalPos + Random.insideUnitSphere * _Shake;
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0)
            {
                _CanShake = false;
                explosionTimer = explosionTimerMax;
            }

        }
    }
}
