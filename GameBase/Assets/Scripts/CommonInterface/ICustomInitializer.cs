using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongSDK
{
    public interface ICustomInitializer
    {
        void PreEnable();
        void PreDisable();
    }

}