using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes_Picking : MonoBehaviour
{
    [SerializeField] Cubes_Manager cubes_manager;

    private const string loot_cube_tag = "Loot_Cube";
    [SerializeField] Canvas_Manager canvas_Manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(loot_cube_tag))
        {
            canvas_Manager.PopUp_Collect_Text();
            cubes_manager.Attach_Cube();

            other.transform.gameObject.SetActive(false);
        }
    }
}