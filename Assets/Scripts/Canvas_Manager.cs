using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Canvas_Manager : MonoBehaviour
{
    [SerializeField] public TMP_Text[] collect_texts;
    bool can_use_first = true;

    // ingame canvas to show popup nums
    public void PopUp_Collect_Text()
    {
        if (can_use_first)
        {
            collect_texts[0].enabled = true;
            collect_texts[0].transform.position = Vector3.zero;

            float rand_x = Random.Range(-350, 350);
            float rand_y = Random.Range(100, 150);

            collect_texts[0].transform.DOLocalMove(new Vector3(transform.localPosition.x + rand_x, transform.localPosition.y + rand_y, transform.localPosition.z), 0.5f).OnComplete(() =>
            {
                collect_texts[0].enabled = false;
            });

            StartCoroutine(Text_CD());
            return;
        }

        if (!can_use_first)
        {
            collect_texts[1].enabled = true;
            collect_texts[1].transform.position = Vector3.zero;

            float rand_x = Random.Range(-350, 350);
            float rand_y = Random.Range(100, 150);  

            collect_texts[1].enabled = true;
            collect_texts[1].transform.DOLocalMove(new Vector3(transform.localPosition.x + rand_x, transform.localPosition.y + rand_y, transform.localPosition.z), 0.5f).OnComplete(() =>
            {
                collect_texts[1].enabled = false;
            });
        }
    }

    IEnumerator Text_CD()
    {
        can_use_first = false;
        yield return new WaitForSeconds(0.5f);
        can_use_first = false;
    }

}