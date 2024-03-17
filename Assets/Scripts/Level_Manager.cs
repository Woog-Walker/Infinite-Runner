using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Level_Manager : MonoBehaviour
{
    [Inject] Canvas_Manager canvas_manager;
    [Inject] Player_Movement player_movement;
    [Inject] Animator_Controller animator_controller;
    [Space]
    [SerializeField] int targetFPS;

    bool has_level_started = false;

    private void Start()
    {
        Application.targetFrameRate = targetFPS;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
            Start_Level();
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
         Start_Level();
#endif
    }

    void Start_Level()
    {
        if (has_level_started) return;

        has_level_started = true;

        canvas_manager.StartMatchUI();
        player_movement.Start_Movement();
    }

    public void End_Level()
    {
        player_movement.Stop_Movemenet();
        animator_controller.Ragdoll_Push();

        canvas_manager.Over_UI();
    }

    public void Restart_Level()
    {
        SceneManager.LoadScene(0);
    }
}