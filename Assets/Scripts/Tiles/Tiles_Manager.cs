using System.Collections;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class Tiles_Manager : MonoBehaviour
{
    [SerializeField] Vector3 spawn_position;

    [SerializeField] float offset_tile;
    [SerializeField] int start_tiles_quantity;

    [Inject] Pool_Tiles pool_of_tiles;

    float animation_time = 0.75f;
    float tile_height_onSpawn = -30;

    private void Start()
    {
        StartCoroutine(Start_Tiles_Initialization());
    }

    IEnumerator Start_Tiles_Initialization()
    {
        for (int i = 0; i <= start_tiles_quantity; i++)
        {
            Spawn_Next_Tile();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void Spawn_Next_Tile()
    {
        var _tile = pool_of_tiles.Get_Tile_From_Pool();

        _tile.transform.position = new Vector3(spawn_position.x, tile_height_onSpawn, spawn_position.z);
        _tile.transform.DOMove(spawn_position, animation_time).SetEase(Ease.OutSine);

        spawn_position.z += 30;
    }

    public void Tile_Passed()
    {
        Spawn_Next_Tile();
        pool_of_tiles.Hide_Tile();
    }
}