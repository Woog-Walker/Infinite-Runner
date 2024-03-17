using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Zen_Inititalization : MonoInstaller
{
    [SerializeField] private Level_Manager level_manager;
    [SerializeField] private Pool_Tiles pool_tiles;
    [SerializeField] private Tiles_Manager tiles_manager;
    [SerializeField] private Canvas_Manager canvas_manager;
    [SerializeField] private Player_Canvas_Manager player_canvas_manager;
    [SerializeField] private Cubes_Manager cubes_manager;
    [SerializeField] private Animator_Controller animator_controller;
    [SerializeField] private Camera_Manager camera_manager;
    [SerializeField] private Player_Movement player_movement;

    public override void InstallBindings()
    {
        Container.Bind<Level_Manager>().FromInstance(level_manager);
        Container.Bind<Pool_Tiles>().FromInstance(pool_tiles);
        Container.Bind<Tiles_Manager>().FromInstance(tiles_manager);
        Container.Bind<Canvas_Manager>().FromInstance(canvas_manager);
        Container.Bind<Player_Canvas_Manager>().FromInstance(player_canvas_manager);
        Container.Bind<Cubes_Manager>().FromInstance(cubes_manager);
        Container.Bind<Animator_Controller>().FromInstance(animator_controller);
        Container.Bind<Camera_Manager>().FromInstance(camera_manager);
        Container.Bind<Player_Movement>().FromInstance(player_movement);
    }
}