using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPrefabsFromFolderInDictionary
{
    public static Dictionary<string, GameObject> FillDictionary(string filePath)
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(filePath);

        Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

        foreach (GameObject g in prefabs)
        {
            dictionary.Add(g.name, GameObject.Instantiate<GameObject>(g));
        }
        return dictionary;
    }
    
}
