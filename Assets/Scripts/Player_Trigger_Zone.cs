using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player_Trigger_Zone : MonoBehaviour
{
    [Inject] Level_Manager level_manager;

    const string tag_obstacle = "Obstacle";
    const string tag_ground = "Tile_";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_obstacle) || other.CompareTag(tag_ground))
        {
            level_manager.End_Level();
        }
    }
}