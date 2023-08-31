using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Trigger_Interaction : MonoBehaviour
{
    [SerializeField] Tile_Generator tile_Generator;

    const string tag_tile = "Tile_Spawn_Trigger";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_tile))        
            tile_Generator.Tile_Passed();        
    }
}