using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomInitializer
{
    void PreEnable();
    void PreDisable();
}