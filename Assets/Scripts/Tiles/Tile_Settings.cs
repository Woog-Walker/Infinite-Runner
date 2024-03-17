using System.Collections.Generic;
using UnityEngine;

public class Tile_Settings : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacle_cases = new List<GameObject>();
    [SerializeField] List<GameObject> loot_cases = new List<GameObject>();

    #region OBSTACLES CASES
    public void Select_Obstacle_Case()
    {
        int rnd_inx = Random.Range(0, obstacle_cases.Count);

        obstacle_cases[rnd_inx].SetActive(true);
    }

    public void Hide_Obstacle_Case()
    {
        foreach (var tmp_case in obstacle_cases)
            if (tmp_case.activeInHierarchy)
                tmp_case.SetActive(false);
    }
    #endregion

    #region LOOT CASES
    public void Select_Loot_Case()
    {
        foreach (var tmp_loot in loot_cases)
            tmp_loot.SetActive(false);

        int rnd_indx = Random.Range(0, loot_cases.Count);
        loot_cases[rnd_indx].SetActive(true);

        // enable all loot cubes in case

        foreach (Transform tmp_loot in loot_cases[rnd_indx].transform)
            tmp_loot.gameObject.SetActive(true);
    }

    public void Hide_Loot_Case()
    {
        foreach (var tmp_case in loot_cases)
            if (tmp_case.activeInHierarchy)
            {
                // disable all loot cubes in case

                foreach (Transform tmp_loot in tmp_case.transform)
                    tmp_loot.gameObject.SetActive(false);

                tmp_case.SetActive(false);
            }
    }
    #endregion

    private void OnEnable()
    {
        Select_Loot_Case();
        Select_Obstacle_Case();
    }
}