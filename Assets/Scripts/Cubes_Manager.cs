using System.Collections.Generic;
using UnityEngine;

public class Cubes_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes_pool_list = new List<GameObject>();
    [SerializeField] List<GameObject> active_cubes_list = new List<GameObject>();
    [Space]
    [SerializeField] GameObject player_GFX;
    [SerializeField] ParticleSystem stack_VFX;
    [SerializeField] Transform cubes_place;
    [Space]
    [SerializeField] Animator_Controller animator_controller;
    [SerializeField] Player_Canvas_Manager player_canvas_manager;

    public int maxed_cubes { get; private set; }
    int active_cubes = 1;
    float start_cube_offset = 0.5f;

    Transform highest_cube;

    private void Start()
    {
        maxed_cubes = cubes_pool_list.Count + maxed_cubes;
    }

    private void FixedUpdate()
    {
        highest_cube = Get_Highest_Cube();
        player_GFX.transform.localPosition = new Vector3(0, highest_cube.localPosition.y + start_cube_offset, 0);
    }

    public void Cube_Attach()
    {
        active_cubes++;

        foreach (var tmp_cube in cubes_pool_list)
        {
            cubes_pool_list.Remove(tmp_cube);
            active_cubes_list.Add(tmp_cube);

            tmp_cube.gameObject.SetActive(true);
            tmp_cube.transform.parent = cubes_place;

            break;
        }

        Play_Stack_VFX();
        Place_Cubes();
        animator_controller.Animation_Jump();
        player_canvas_manager.Animate_PopUp_Text();

        Handheld.Vibrate();
    }

    public void Cube_Deatach(GameObject tmp_cube)
    {
        active_cubes--;

        tmp_cube.transform.parent = null;

        active_cubes_list.Remove(tmp_cube);
        cubes_pool_list.Add(tmp_cube);

        Handheld.Vibrate();
    }

    void Place_Cubes()
    {
        for (int i = 0; i < active_cubes_list.Count; i++)
            active_cubes_list[i].transform.localPosition = new Vector3(0, start_cube_offset + i, 0);
    }


    Transform Get_Highest_Cube()
    {
        float highestY = float.MinValue;

        foreach (GameObject obj in active_cubes_list)
        {
            if (obj.activeInHierarchy)
            {
                float y = obj.transform.localPosition.y;

                if (y > highestY)
                {
                    highestY = y;
                    highest_cube = obj.transform;
                }
            }
        }

        return highest_cube;
    }

    void Play_Stack_VFX()
    {
        stack_VFX.transform.localPosition = new Vector3(0, active_cubes_list.Count + start_cube_offset, 0);
        stack_VFX.Play();
    }

    public bool Check_If_Cubes_Limitted()
    {
        if (active_cubes < maxed_cubes) return false;
        else return true;
    }
}