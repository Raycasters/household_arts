using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class WorldUIDataManager : MonoBehaviour {

    private List<WorldUI> arrWorldUIs;
    private static WorldUIDataManager _instance;
    public static WorldUIDataManager Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        LoadFile();

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadFile()
    {
        // Load json from local file
        string jsonPath = Constants.dataPath;
        TextAsset asset = Resources.Load(jsonPath) as TextAsset;
        Debug.Log("asset.text: " + asset.text);
        ProcessData(asset.text);
    }

    private void ProcessData(string jsonString)
    {

        var jsonData = JSON.Parse(jsonString);
        JSONArray arrLivingRoom = jsonData[Constants.Rooms.livingRoom] as JSONArray;

        arrWorldUIs = new List<WorldUI>();
        if (arrLivingRoom.Count > 0)
        {
            foreach (JSONNode node in arrLivingRoom)
            {
                WorldUI worldUI = new WorldUI();
                worldUI.room = Constants.Rooms.livingRoom;
                worldUI.id = Convert.ToInt32(node["id"]);
                worldUI.title = node["name"].ToString().Length > 0 ? node["name"].ToString().Substring(1, node["name"].ToString().Length - 2) : node["name"].ToString();
                worldUI.details = node["details"].ToString().Length > 0 ? node["details"].ToString().Substring(1, node["details"].ToString().Length - 2) : node["details"].ToString();
                worldUI.type = node["type"].ToString().Length > 0 ? node["type"].ToString().Substring(1, node["type"].ToString().Length - 2) : node["type"].ToString();

                arrWorldUIs.Add(worldUI);
            }
        }
    }

    public WorldUI GetWorldUIById(int id)
    {
        if (arrWorldUIs.Count == 0)
        {
            return null;
        }

        foreach (WorldUI worldUI in arrWorldUIs)
        {
            if (worldUI.id == id)
            {
                return worldUI;
            }
        }
        return null;
    }

    // For memoization not to get art every time if we already find it.
    Dictionary<int, WorldUI> _dic = new Dictionary<int, WorldUI>();

    /// <summary>
    /// Gets the art.
    /// </summary>
    /// <returns>The art.</returns>
    public WorldUI getWorldUI(int id)
    {

        WorldUI lookup;
        if (_dic.TryGetValue(id, out lookup))
        {
            return lookup;
        }

        lookup = GetWorldUIById(id) as WorldUI;

        _dic[id] = lookup;
        return lookup;
    }
}
