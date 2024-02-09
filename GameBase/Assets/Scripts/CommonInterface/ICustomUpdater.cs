using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomUpdater
{
    void CustomUpdate(float _dt);
    void CustomFixedUpdate(float _dt);
}
