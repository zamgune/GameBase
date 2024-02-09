using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitComponent_StatusBase : IUnitComponent, ICustomInitializer
{
    public Health Health { get; protected set; }
    public CriticalChance CriticalChance { get; protected set; }

    private StatusController<CriticalChance> _criticalChanceController = new();

    public UnitBase Owner { get; }
    public void PreDisable() { }
    public void PreEnable()
    {
        _criticalChanceController.SetOriginalValue(new CriticalChance(CriticalChance.Value));
    }

    public ulong AddStatus(in IIntStatus plusValue, in bool isRemovable)
    {
        switch (plusValue.StatusType)
        {
            case EStatusType.Health:
                break;
            case EStatusType.CriticalChance:
            {
                var result = _criticalChanceController.AddAdditionalStatus(plusValue, isRemovable, EStatusOperator.Plus);
                CriticalChance = new CriticalChance(result.calculationResult);
                return result.uid;
            }
        }
        return 0;
    }

    public void RemoveStatus(in ulong uid, in EStatusType statusType)
    {
        switch (statusType)
        {
            case EStatusType.Health:
                break;
            case EStatusType.CriticalChance:
                CriticalChance = new CriticalChance(_criticalChanceController.RemoveAdditionalStatus(uid));
                break;
        }
    }
}

public class UnitComponent_Status : UnitComponent_StatusBase
{
      
}
