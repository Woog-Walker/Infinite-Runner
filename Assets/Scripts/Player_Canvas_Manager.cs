using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Player_Canvas_Manager : MonoBehaviour
{
    [SerializeField] List<TMP_Text> popUps_texts = new List<TMP_Text>();

    float animation_time = 0.5f;
    float animation_offset = 300;

    public void Animate_PopUp_Text()
    {
        var _text = Get_Text_From_Pool();

        _text.transform.DOLocalMove(new Vector3(0, transform.localPosition.y + animation_offset, 0), animation_time).OnComplete(() =>
        {
            Put_Text_Back_To_Pool(_text);
        });
    }

    TMP_Text Get_Text_From_Pool()
    {
        foreach (var tmp_text in popUps_texts)
        {
            if (!tmp_text.gameObject.activeSelf)
            {
                tmp_text.gameObject.SetActive(true);

                return tmp_text;
            }
        }

        return null;
    }

    void Put_Text_Back_To_Pool(TMP_Text _tmp_text)
    {
        _tmp_text.transform.localPosition = Vector3.zero;
        _tmp_text.gameObject.SetActive(false);
    }
}