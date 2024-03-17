using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pool_Tiles : MonoBehaviour
{
    [SerializeField] List<GameObject> tiles_pool = new List<GameObject>();
    [SerializeField] List<GameObject> tiles_onLevel = new List<GameObject>();

    // holder to store tiles
    [SerializeField] Transform pool_holder;

    public GameObject Get_Tile_From_Pool()
    {
        foreach (var tmp_tile in tiles_pool)
        {
            if (!tmp_tile.activeInHierarchy)
            {
                tiles_pool.Remove(tmp_tile);
                tiles_onLevel.Add(tmp_tile);

                tmp_tile.gameObject.SetActive(true);
                tmp_tile.transform.parent = null;

                return tmp_tile;
            }
        }

        return null;
    }

    public void Hide_Tile()
    {
        StartCoroutine(Put_Back_To_Pool());
    }

    IEnumerator Put_Back_To_Pool()
    {
        yield return new WaitForSeconds(1);

        foreach (var tmp_tile in tiles_onLevel)
        {
            if (tmp_tile.activeInHierarchy)
            {
                tmp_tile.SetActive(false);

                tiles_onLevel.Remove(tmp_tile);
                tiles_pool.Add(tmp_tile);

                tmp_tile.transform.parent = pool_holder;
                tmp_tile.transform.position = Vector3.zero;

                break;
            }
        }
    }
}