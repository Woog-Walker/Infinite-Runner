using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class Canvas__Manager : MonoBehaviour
{
    [SerializeField] Player_Movement player_movement_script;

    [Header("start stuff")]
    [SerializeField] Image image_hand;
    [SerializeField] TMP_Text start_text;
    [Space]
    [SerializeField] GameObject button_restart;
    [SerializeField] TMP_Text text_restart;
    [SerializeField] Button button_restartt;
    // test comm
    public static Canvas__Manager UI_Instance { get; private set; }

    private void Awake()
    {
        if (UI_Instance == null)
            UI_Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Move_Icon_Right();
    }

    private void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.N) && !player_movement_script.has_started)        
            BTN_Start();  
        
#else

        if (Input.touchCount > 0 && !player_movement_script.has_started)        
            BTN_Start();

#endif

    }

    public void BTN_Start()
    {
        player_movement_script.Start_Movement();


        start_text.rectTransform.DOLocalMove(new Vector3(start_text.transform.localPosition.x, start_text.transform.localPosition.y - 2000, start_text.transform.localPosition.z), 1);
        image_hand.rectTransform.DOLocalMove(new Vector3(image_hand.transform.localPosition.x, image_hand.transform.localPosition.y - 2000, image_hand.transform.localPosition.z), 1)
            .OnComplete(() =>
            {
                start_text.enabled = false;
                image_hand.enabled = false;
            });

        player_movement_script.has_started = true;
    }

    public void Move_Icon_Right()
    {
        image_hand.rectTransform.DOLocalMove(new Vector3(150, image_hand.transform.localPosition.y, image_hand.transform.localPosition.z), 2)
            .OnComplete(() => { Move_Icon_Left(); })
            .SetEase(Ease.InOutCubic);
    }

    public void Move_Icon_Left()
    {
        image_hand.rectTransform.DOLocalMove(new Vector3(-150, image_hand.transform.localPosition.y, image_hand.transform.localPosition.z), 2)
            .OnComplete(()=> { Move_Icon_Right(); })
            .SetEase(Ease.InOutCubic);
    }

    public void Restart_Level()
    {
        SceneManager.LoadScene(0);
    }

    public void Over_UI()
    {
        button_restart.SetActive(true);
        text_restart.enabled = true;
    }
}