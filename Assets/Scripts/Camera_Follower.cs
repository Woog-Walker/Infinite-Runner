using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera_Follower : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform camera;
    [SerializeField] Transform camera_holder;
    [Space]
    [SerializeField] float offset_x;
    [SerializeField] float offset_y;
    [SerializeField] float offset_z;

    float shake_duration = 0.3f;
    float shake_strength = 0.3f;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        camera_holder.transform.position = new Vector3(player.position.x + offset_x, player.position.y + offset_y, player.position.z + offset_z);
    }

    public void Camera_Shake()
    {
        camera.DOShakePosition(shake_duration, shake_strength);
    }
}