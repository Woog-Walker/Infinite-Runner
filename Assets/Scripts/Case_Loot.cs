using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case_Loot : MonoBehaviour
{
    [SerializeField] List<GameObject> list_of_loot_cubes = new List<GameObject>();

    public void Enable_Loot_Cubes()
    {
        foreach (var tmp in list_of_loot_cubes)        
            tmp.SetActive(true);
    }
}