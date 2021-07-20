using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem
{
    public string ItemName;
    public int Cost;

    public virtual string GetDescription()
    {
        return "Item Name [" + Cost.ToString() + "]";
    }

    public virtual void RandomiseItem()
    {
        Cost = Random.Range(-50, 200);
        ItemName = Random.Range(0, 2000).ToString();
    }
}
