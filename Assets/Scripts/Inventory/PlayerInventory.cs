using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventoryData
{
    public List<BaseItem> WornItems = new List<BaseItem>();
    public List<BaseItem> CarriedItems = new List<BaseItem>();
}

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] PlayerInventoryData Data;

    public List<BaseItem> WornItems { get { return Data.WornItems; } set { Data.WornItems = value; } }
    public List<BaseItem> CarriedItems { get { return Data.CarriedItems; } set { Data.CarriedItems = value; } }

    public PlayerInventoryData InventoryData
    {
        get
        {
            return Data;
        }
        set
        {
            Data = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
