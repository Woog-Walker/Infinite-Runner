using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deattach_Cube : MonoBehaviour
{
    Cubes_Manager cubes_Manager;
    Camera_Follower camera_script;

    const string tag_obstacle = "Obstacle";

    bool can_be_uded = true;

    private void Awake()
    {
        cubes_Manager = GetComponentInParent<Cubes_Manager>();
        camera_script = FindObjectOfType<Camera_Follower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_obstacle) && can_be_uded)
        {            
            StartCoroutine(Start_Deatach_CD());

            cubes_Manager.Detach_Cube(transform.gameObject);
            camera_script.Camera_Shake();

            other.gameObject.GetComponentInParent<Tile_Manager>().Disable_Interaction();
        }
    }

    IEnumerator Start_Deatach_CD()
    {
        can_be_uded = false;
        yield return new WaitForSeconds(0.5f);
        can_be_uded = true;
    }
}