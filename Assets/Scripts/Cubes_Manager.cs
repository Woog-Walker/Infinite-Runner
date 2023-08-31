using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Cubes_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes_list = new List<GameObject>();
    [SerializeField] List<GameObject> tmp_list = new List<GameObject>();

    [SerializeField] GameObject player;
    [SerializeField] GameObject highestObject;
    [SerializeField] Animator_Controller animator_Controller;
    [SerializeField] ParticleSystem fx_cube_appear;

    private void FixedUpdate()
    {
        Place_Character();

        if (highestObject != null)
            player.transform.localPosition = new Vector3(
                highestObject.transform.localPosition.x,
                highestObject.transform.localPosition.y + 0.5f,
                highestObject.transform.localPosition.z);
    }

    public void Place_Character()
    {
        highestObject = FindHighestObject();
    }

    GameObject FindHighestObject()
    {
        highestObject = null;
        float highestY = float.MinValue;

        foreach (GameObject obj in cubes_list)
        {
            if (obj.activeInHierarchy)
            {
                float y = obj.transform.localPosition.y;

                if (y > highestY)
                {
                    highestY = y;
                    highestObject = obj;
                }
            }
        }

        return highestObject;
    }

    public void Detach_Cube(GameObject _tmp_cube)
    {
        _tmp_cube.transform.parent = null;

        if (cubes_list.Contains(_tmp_cube))
        {
            cubes_list.Remove(_tmp_cube);
            tmp_list.Add(_tmp_cube);
            Handheld.Vibrate();
        }
    }

    public void Attach_Cube()
    {
        if (tmp_list.Count > 0)
        {
            GameObject firstObject = tmp_list[0];        // Get the first object from the source list.
            tmp_list.RemoveAt(0);                       // Remove the first object from the source list.
            cubes_list.Add(firstObject);               // Add the first object to the destination list.

            firstObject.transform.parent = transform;

            for (int i = 0; i < cubes_list.Count; i++)            
                cubes_list[i].transform.localPosition = new Vector3(0, 0.5f + i, 0);

            fx_cube_appear.transform.localPosition = new Vector3(firstObject.transform.localPosition.x, firstObject.transform.localPosition.y + 0.5f, firstObject.transform.localPosition.z);
            fx_cube_appear.Play();

            // firstObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            // firstObject.transform.DOScale(new Vector3(1, 1, 1), 0.5f);

            animator_Controller.Animation_Jump();
        }
    }
}