using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Generator : MonoBehaviour
{
    [SerializeField] List<GameObject> list_tiles = new List<GameObject>();

    private float spawn_poisition = 150;
    private float offset_axis = 30;

    [SerializeField] GameObject last_elem;

    public void Tile_Passed()
    {
        StartCoroutine(Delay_To_Move_Platform());
    }

    IEnumerator Delay_To_Move_Platform()
    {
        yield return new WaitForSeconds(2);

        GameObject tmp_obj = list_tiles[0];
        list_tiles.RemoveAt(0);
        list_tiles.Add(tmp_obj);

        last_elem = list_tiles[list_tiles.Count - 1];
        last_elem.transform.position = new Vector3(0, 0, spawn_poisition);

        spawn_poisition += offset_axis;

        foreach (var item in list_tiles)
            item.GetComponent<Tile_Manager>().Enable_Interaction();

        last_elem.GetComponent<Tile_Manager>().Enable_Cubes();
    }
}