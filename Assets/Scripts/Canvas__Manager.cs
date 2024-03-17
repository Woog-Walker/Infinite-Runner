using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Zenject;

public class Canvas_Manager : MonoBehaviour
{
    [Header("game starts elements")]
    [SerializeField] GameObject startScreen;
    [SerializeField] Image background_start;
    [SerializeField] Image image_hand;
    [SerializeField] TMP_Text start_text;
    [SerializeField] Color colorTo;
    [Space]

    [Header("game over elements")]
    [SerializeField] GameObject endScreen;
    [SerializeField] TMP_Text text_restart;
    [SerializeField] Button button_restart;

    float anim_time = 0.5f;
    float iconAnimationTime = 1.75f;
    float iconAnimationOffset = 150;

    public static Canvas_Manager UI_Instance { get; private set; }

    Sequence icon_move_seq;

    [Inject] Player_Movement player_movement_script;

    private void Awake()
    {
        DOTween.KillAll();
        icon_move_seq = DOTween.Sequence();
    }

    private void Start()
    {
        Start_Icon_Moving();
    }

    public void StartMatchUI()
    {
        background_start.DOColor(colorTo, anim_time);

        image_hand.rectTransform.DOScale(Vector3.zero, anim_time);
        start_text.rectTransform.DOScale(Vector3.zero, anim_time).OnComplete(() => {
            startScreen.SetActive(false);
        });
    }

    private void Start_Icon_Moving()
    {
        icon_move_seq
            .Append(image_hand.rectTransform.DOLocalMove(new Vector3(iconAnimationOffset, image_hand.transform.localPosition.y, image_hand.transform.localPosition.z), iconAnimationTime).SetEase(Ease.InOutCubic))
            .Append(image_hand.rectTransform.DOLocalMove(new Vector3(-iconAnimationOffset, image_hand.transform.localPosition.y, image_hand.transform.localPosition.z), iconAnimationTime).SetEase(Ease.InOutCubic))
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void Over_UI()
    {
        endScreen.SetActive(true);

        text_restart.rectTransform.DOScale(Vector3.one, anim_time);
        button_restart.transform.DOScale(Vector3.one, anim_time);
    }
}