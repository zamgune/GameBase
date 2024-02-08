using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatus<T> where T : struct
{
    public T Value { get; }
}

public readonly struct Health : IStatus<int>
{
    public int Value { get; }

    public Health(in int value)
    {
        Value = value;
    }

    public Health Add(in Health health)
    {
        return new Health(Value + health.Value);
    }

    public Health Sub(in Health health)
    {
        return new Health(Value - health.Value);
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct HealthRegeneration : IStatus<int>
{
    public int Value { get; }

    public HealthRegeneration(in int value)
    {
        Value = value;
    }

    public HealthRegeneration Add(in HealthRegeneration healthRegeneration)
    {
        return new HealthRegeneration(Value + healthRegeneration.Value);
    }

    public HealthRegeneration Sub(in HealthRegeneration healthRegeneration)
    {
        return new HealthRegeneration(Value - healthRegeneration.Value);
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct Heal : IStatus<int>
{
    public int Value { get; }

    public Heal(in int value)
    {
        Value = value;
    }

    public Heal Add(in Heal heal)
    {
        return new Heal(Value + heal.Value);
    }

    public Heal Sub(in Heal heal)
    {
        return new Heal(Value - heal.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct Damage : IStatus<int>
{
    public int Value { get; }

    public Damage(in int value)
    {
        Value = value;
    }

    public Damage Add(in Damage damage)
    {
        return new Damage(Value + damage.Value);
    }

    public Damage Sub(in Damage damage)
    {
        return new Damage(Value - damage.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct PhysicalDamage : IStatus<int>
{
    public int Value { get; }

    public PhysicalDamage(in int value)
    {
        Value = value;
    }

    public PhysicalDamage Add(in PhysicalDamage physicalDamage)
    {
        return new PhysicalDamage(Value + physicalDamage.Value);
    }

    public PhysicalDamage Sub(in PhysicalDamage physicalDamage)
    {
        return new PhysicalDamage(Value - physicalDamage.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct MagicDamage : IStatus<int>
{
    public int Value { get; }

    public MagicDamage(in int value)
    {
        Value = value;
    }

    public MagicDamage Add(in MagicDamage magicDamage)
    {
        return new MagicDamage(Value + magicDamage.Value);
    }

    public MagicDamage Sub(in MagicDamage magicDamage)
    {
        return new MagicDamage(Value - magicDamage.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct Mana : IStatus<int>
{
    public int Value { get; }

    public Mana(in int value)
    {
        Value = value;
    }

    public Mana Add(in Mana mana)
    {
        return new Mana(Value + mana.Value);
    }

    public Mana Sub(in Mana mana)
    {
        return new Mana(Value - mana.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct Range : IStatus<int>
{
    public int Value { get; }

    public Range(in int value)
    {
        Value = value;
    }

    public Range Add(in Range range)
    {
        return new Range(Value + range.Value);
    }

    public Range Sub(in Range range)
    {
        return new Range(Value - range.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct Defense : IStatus<int>
{
    public int Value { get; }

    public Defense(in int value)
    {
        Value = value;
    }

    public Defense Add(in Defense defense)
    {
        return new Defense(Value + defense.Value);
    }

    public Defense Sub(in Defense defense)
    {
        return new Defense(Value - defense.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct PhysicalDefense : IStatus<int>
{
    public int Value { get; }

    public PhysicalDefense(in int value)
    {
        Value = value;
    }

    public PhysicalDefense Add(in PhysicalDefense physicalDefense)
    {
        return new PhysicalDefense(Value + physicalDefense.Value);
    }

    public PhysicalDefense Sub(in PhysicalDefense physicalDefense)
    {
        return new PhysicalDefense(Value - physicalDefense.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct MagicDefense : IStatus<int>
{
    public int Value { get; }

    public MagicDefense(in int value)
    {
        Value = value;
    }

    public MagicDefense Add(in MagicDefense magicDefense)
    {
        return new MagicDefense(Value + magicDefense.Value);
    }

    public MagicDefense Sub(in MagicDefense magicDefense)
    {
        return new MagicDefense(Value - magicDefense.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct CriticalChance : IStatus<int>
{
    public int Value { get; }

    public CriticalChance(in int value)
    {
        Value = value;
    }

    public CriticalChance Add(in CriticalChance criticalChance)
    {
        return new CriticalChance(Value + criticalChance.Value);
    }

    public CriticalChance Sub(in CriticalChance criticalChance)
    {
        return new CriticalChance(Value - criticalChance.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct CriticalDamage : IStatus<int>
{
    public int Value { get; }

    public CriticalDamage(in int value)
    {
        Value = value;
    }

    public CriticalDamage Add(in CriticalDamage criticalDamage)
    {
        return new CriticalDamage(Value + criticalDamage.Value);
    }

    public CriticalDamage Sub(in CriticalDamage criticalDamage)
    {
        return new CriticalDamage(Value - criticalDamage.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct MovementSpeed : IStatus<int>
{
    public int Value { get; }

    public MovementSpeed(in int value)
    {
        Value = value;
    }

    public MovementSpeed Add(in MovementSpeed movementSpeed)
    {
        return new MovementSpeed(Value + movementSpeed.Value);
    }

    public MovementSpeed Sub(in MovementSpeed movementSpeed)
    {
        return new MovementSpeed(Value - movementSpeed.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct AttackSpeed : IStatus<int>
{
    public int Value { get; }

    public AttackSpeed(in int value)
    {
        Value = value;
    }

    public AttackSpeed Add(in AttackSpeed attackSpeed)
    {
        return new AttackSpeed(Value + attackSpeed.Value);
    }

    public AttackSpeed Sub(in AttackSpeed attackSpeed)
    {
        return new AttackSpeed(Value - attackSpeed.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

public readonly struct SkillHaste : IStatus<int>
{
    public int Value { get; }

    public SkillHaste(in int value)
    {
        Value = value;
    }

    public SkillHaste Add(in SkillHaste attackSpeed)
    {
        return new SkillHaste(Value + attackSpeed.Value);
    }

    public SkillHaste Sub(in SkillHaste attackSpeed)
    {
        return new SkillHaste(Value - attackSpeed.Value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}




