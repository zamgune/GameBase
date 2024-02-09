using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController<T> : ICustomInitializer where T : IIntStatus
{
    const float PERCENTAGE = 0.01f;
    private T _originalValue;
    private Dictionary<ulong, AdditionalStatus> _uidToAdditionalValueFair = new();
    private ulong _uid;

    public readonly struct AdditionalStatus
    {
        public readonly IIntStatus Status;
        public readonly EStatusOperator Operator;

        public AdditionalStatus(in IIntStatus status, in EStatusOperator statusOperator)
        {
            Status = status;
            Operator = statusOperator;
        }
    }

    public void SetOriginalValue(T originalValue)
    {
        _originalValue = originalValue;
    }

    public (ulong uid, int calculationResult) AddAdditionalStatus(in IIntStatus additionalValue, in bool isRemovable, in EStatusOperator statusOperator)
    {
        var uid = ulong.MaxValue;
        int retunValue = _originalValue.Value;
        switch (statusOperator)
        {
            case EStatusOperator.Plus:
                PlusStatus(additionalValue, isRemovable);
                break;
            case EStatusOperator.Minus:
                MinusStatus(additionalValue, isRemovable);
                break;
            case EStatusOperator.PlusPercent:
                PlusPercentStatus(additionalValue, isRemovable);
                break;
            case EStatusOperator.MinusPercent:
                MinusPercentStatus(additionalValue, isRemovable);
                break;
        }

        return (uid, retunValue);
    }

    public int RemoveAdditionalStatus(in ulong uid)
    {
        if (_uidToAdditionalValueFair.ContainsKey(uid))
        {            
            _uidToAdditionalValueFair.Remove(uid);
        }

        return GetSavedStatus();
    }

    private int GetSavedStatus()
    {
        var calculatedValue = _originalValue.Value;
        foreach (var v in _uidToAdditionalValueFair)
        {
            switch (v.Value.Operator)
            {
                case EStatusOperator.Plus:
                    calculatedValue += v.Value.Status.Value;
                    break;
                case EStatusOperator.Minus:
                    calculatedValue -= v.Value.Status.Value;
                    break;
                case EStatusOperator.PlusPercent:
                    var plusValue = Mathf.RoundToInt(calculatedValue * ((float)v.Value.Status.Value * PERCENTAGE));
                    calculatedValue += plusValue;
                    break;
                case EStatusOperator.MinusPercent:
                    var minusValue = Mathf.RoundToInt(calculatedValue * ((float)v.Value.Status.Value * PERCENTAGE));
                    calculatedValue -= minusValue;
                    break;
            }
        }

        return calculatedValue;
    }

    private (ulong uid, int calculationResult) PlusStatus(in IIntStatus additionalValue, in bool isRemovable)
    {
        var plusResult = GetSavedStatus();
        var uid = ulong.MaxValue;      
        plusResult += additionalValue.Value;

        if (isRemovable)
        {
            uid = GenerateUID();            
            _uidToAdditionalValueFair.Add(uid, new AdditionalStatus(additionalValue, EStatusOperator.Plus));
        }

        return (uid, plusResult);
    }

    private (ulong uid, int calculationResult) MinusStatus(in IIntStatus additionalValue, in bool isRemovable)
    {
        var minusResult = GetSavedStatus();
        var uid = ulong.MaxValue;
        minusResult -= additionalValue.Value;

        if (isRemovable)
        {
            uid = GenerateUID();
            _uidToAdditionalValueFair.Add(uid, new AdditionalStatus(additionalValue, EStatusOperator.Minus));
        }

        return (uid, minusResult);
    }

    private (ulong uid, int calculationResult) PlusPercentStatus(in IIntStatus additionalValue, in bool isRemovable)
    {
        var plusPercentResult = GetSavedStatus();
        var uid = ulong.MaxValue;
        var plusValue = Mathf.RoundToInt(plusPercentResult * ((float)additionalValue.Value * PERCENTAGE));
        plusPercentResult += plusValue;

        if (isRemovable)
        {
            uid = GenerateUID();
            _uidToAdditionalValueFair.Add(uid, new AdditionalStatus(additionalValue, EStatusOperator.PlusPercent));
        }

        return (uid, plusPercentResult);
    }

    private (ulong uid, int calculationResult) MinusPercentStatus(in IIntStatus additionalValue, in bool isRemovable)
    {
        var minusPercentResult = GetSavedStatus();
        var uid = ulong.MaxValue;
        var plusValue = Mathf.RoundToInt(minusPercentResult * ((float)additionalValue.Value * PERCENTAGE));
        minusPercentResult -= plusValue;

        if (isRemovable)
        {
            uid = GenerateUID();
            _uidToAdditionalValueFair.Add(uid, new AdditionalStatus(additionalValue, EStatusOperator.PlusPercent));
        }

        return (uid, minusPercentResult);
    }

    private ulong GenerateUID()
    {
        return _uid++;
    }

    public void PreEnable()
    {
        
    }

    public void PreDisable()
    {
        _originalValue = default;
        _uid = 0;
        _uidToAdditionalValueFair.Clear();
    }
}
