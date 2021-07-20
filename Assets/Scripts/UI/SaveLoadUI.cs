using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FullSerializer;

public class SaveLoadUI : MonoBehaviour
{
    string SaveFilePath => System.IO.Path.Combine(Application.persistentDataPath, "GameData.json");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSave()
    {
        // create a list of our inventory data
        Dictionary<string, PlayerInventoryData> inventoryData = new Dictionary<string, PlayerInventoryData>();

        // populate inventory data list
        var allInventories = FindObjectsOfType<PlayerInventory>();
        foreach(var inventory in allInventories)
        {
            inventoryData[inventory.gameObject.name] = inventory.InventoryData;
        }

        var gameData = new GameData();
        gameData.InventoryData = inventoryData;

        // create serializer and serialize the game data
        var serializer = new fsSerializer();
        var serializedData = new fsData();
        var result = serializer.TrySerialize<GameData>(gameData, out serializedData);

        // save the data
        System.IO.File.WriteAllText(SaveFilePath, fsJsonPrinter.PrettyJson(serializedData));
        Debug.Log(SaveFilePath);
    }

    public void OnLoad()
    {
        // do nothing if there is no file
        if (!System.IO.File.Exists(SaveFilePath))
            return;

        // read the json data
        string jsonData = System.IO.File.ReadAllText(SaveFilePath);
        var serializedData = new fsData();
        fsJsonParser.Parse(jsonData, out serializedData);

        // convert to a game data
        var deserializer = new fsSerializer();
        GameData loadedData = null;
        deserializer.TryDeserialize<GameData>(serializedData, ref loadedData);

        // restore the data to each character
        var allInventories = FindObjectsOfType<PlayerInventory>();
        foreach (var inventory in allInventories)
        {
            // look up the data for this character
            if (loadedData.InventoryData.ContainsKey(inventory.gameObject.name))
                inventory.InventoryData = loadedData.InventoryData[inventory.gameObject.name];
        }

        // force the UI to refresh
        var characterPanels = FindObjectsOfType<CharacterPanelUI>();
        foreach(var panelUI in characterPanels)
        {
            panelUI.RefreshInventory();
        }
    }
}
