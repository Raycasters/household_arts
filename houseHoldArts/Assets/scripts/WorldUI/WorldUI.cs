using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUI : MonoBehaviour {


    public int id = 0;
    public string title;
    public string details;
    public string room;
    public string type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    // For memoization not to get art every time if we already find it.
    Dictionary<int, WorldUI> _dic = new Dictionary<int, WorldUI>();

    /// <summary>
    /// Gets the art.
    /// </summary>
    /// <returns>The art.</returns>
    public WorldUI getWorldUI()
    {

        WorldUI lookup;
        if (_dic.TryGetValue(id, out lookup))
        {
            return lookup;
        }

        lookup = WorldUIDataManager.Instance.GetWorldUIById(this.id) as WorldUI;

        _dic[id] = lookup;
        return lookup;
    }
    */

}
