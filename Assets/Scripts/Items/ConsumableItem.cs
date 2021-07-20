using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEffect
{
    Heal,
    Mana
}

[System.Serializable]
public class ConsumableItem : BaseItem
{
    public EEffect Effect;
    public int NumCharges;
    public float CooldownTime;

    public override string GetDescription()
    {
        return base.GetDescription() + " (" + Effect.ToString() + ", " + NumCharges.ToString() + ")";
    }

    public override void RandomiseItem()
    {
        base.RandomiseItem();

        var effectTypes = System.Enum.GetValues(typeof(EEffect));
        Effect = (EEffect) effectTypes.GetValue(Random.Range(0, effectTypes.Length));

        NumCharges = Random.Range(1, 5);
        CooldownTime = Random.Range(1f, 10f);
    }
}
