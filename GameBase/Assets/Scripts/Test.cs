using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float _accTime;

    public void CustomUpdate(float _dt)
    {
        _accTime += _dt;
        var pos = Mathf.Cos(_accTime);
        gameObject.transform.position = new Vector3(pos, 0f, 0f);       
    }
}
