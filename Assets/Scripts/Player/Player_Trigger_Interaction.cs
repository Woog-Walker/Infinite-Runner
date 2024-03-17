using UnityEngine;

public class Player_Trigger_Interaction : MonoBehaviour
{
    [SerializeField] Tiles_Manager tiles_manager;
    [SerializeField] Cubes_Manager cubes_manager;

    string tag_tile = "Tile_End_Trigger";
    string loot_cube_tag = "Loot_Cube";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag_tile))
            tiles_manager.Tile_Passed();

        if (other.CompareTag(loot_cube_tag) && !cubes_manager.Check_If_Cubes_Limitted())
            Trigger_Loot_Cube(other);
    }

    private void Trigger_Loot_Cube(Collider other)
    {
        cubes_manager.Cube_Attach();
        other.transform.gameObject.SetActive(false);
    }
}