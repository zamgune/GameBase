using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongSDK
{
    public interface IUnitComponent
    {
        UnitBase Owner { get; }
    }

}