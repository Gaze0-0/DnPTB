using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseMovement : MonoBehaviour
{
    float _rotationSpeed = 0.2f;
    public bool _OpenCase = false;

    private void Update()
    {
        if (_OpenCase)
        {
            OpenLid();
        }
    }
    void OpenLid()
    {
        if (transform.rotation.x <= 0.75f)
        {
            transform.Rotate(_rotationSpeed,0,0);
        }
        else if (transform.rotation.x > 0.75f)
        {
            Destroy(this.gameObject);

        }
    }
}
