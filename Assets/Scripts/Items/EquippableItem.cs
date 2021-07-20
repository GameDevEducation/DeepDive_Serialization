using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESlot
{
    Head,
    Chest,
    Arms,
    Legs,
    Hands,
    Waist
}

[System.Serializable]
public class EquippableItem : BaseItem
{
    public ESlot Slot;
    public int Weight;

    public override string GetDescription()
    {
        return base.GetDescription() + " (" + Slot.ToString() + ", " + Weight.ToString() + ")";
    }

    public override void RandomiseItem()
    {
        base.RandomiseItem();

        var slotTypes = System.Enum.GetValues(typeof(ESlot));
        Slot = (ESlot) slotTypes.GetValue(Random.Range(0, slotTypes.Length));
        
        Weight = Random.Range(5, 50);
    }
}
