using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacle_cases = new List<GameObject>();
    [SerializeField] List<GameObject> loot_cases = new List<GameObject>();
    [Space]
    [SerializeField] List<Collider> obtacle_colliders = new List<Collider>();
    [SerializeField] List<GameObject> loot_cubes = new List<GameObject>();

    private void Start()
    {
        Select_Obstacle_Case();
        Select_Loot_Case();
    }

    public void Select_Obstacle_Case()
    {
        foreach (var _tmp in obstacle_cases)
            _tmp.SetActive(false);

        int rnd_indx = Random.Range(0, obstacle_cases.Count);

        for (int i = 0; i < obstacle_cases.Count; i++)
            if (i == rnd_indx)
                obstacle_cases[i].SetActive(true);
    }

    public void Select_Loot_Case()
    {
        foreach (var _tmp in loot_cases)
            _tmp.SetActive(false);

        int rnd_indx = Random.Range(0, loot_cases.Count);

        for (int i = 0; i < loot_cases.Count; i++)
            if (i == rnd_indx)
                loot_cases[i].SetActive(true);
    }

    public void Disable_Interaction()
    {
        StartCoroutine(Wait_To_Disable());
    }

    IEnumerator Wait_To_Disable()
    {
        yield return new WaitForEndOfFrame();

        foreach (var _tmp_col in obtacle_colliders)
            _tmp_col.enabled = false;
    }

    public void Enable_Interaction()
    {
        foreach (var _tmp_col in obtacle_colliders)
            _tmp_col.enabled = true;
    }

    public void Enable_Cubes()
    {
        foreach (var item in loot_cubes)
            item.SetActive(true);
    }
}