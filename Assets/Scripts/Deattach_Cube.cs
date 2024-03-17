using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Deattach_Cube : MonoBehaviour
{
    [Inject] Cubes_Manager cubes_Manager;

    const string tag_obstacle = "Obstacle";

    bool can_be_used = true;

/*    private void Awake()
    {
        cubes_Manager = GetComponentInParent<Cubes_Manager>();
        camera_script = FindObjectOfType<Camera_Manager>();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_obstacle) && can_be_used)
        {            
            StartCoroutine(Start_Deatach_CD());

            cubes_Manager.Cube_Deatach(transform.gameObject);
        }
    }

    IEnumerator Start_Deatach_CD()
    {
        can_be_used = false;
        yield return new WaitForSeconds(0.5f);
        can_be_used = true;
    }
}