using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Activator : MonoBehaviour
{
    [SerializeField] Animator_Controller Animator_Controller;
    [SerializeField] Player_Movement player_Movement;

    const string tag_obstacle = "Obstacle";
    const string tag_ground = "Tile_";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_obstacle) || other.CompareTag(tag_ground))
            Game_Over();
    }

    private void Game_Over()
    {
        Debug.Log("GAME OVER");
        
        Animator_Controller.Ragdoll_Push();
        player_Movement.speed = 0;
        Canvas__Manager.UI_Instance.Over_UI();
        // enable restart ui
    }
}
