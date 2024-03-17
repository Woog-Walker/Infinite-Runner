using UnityEngine;
using DG.Tweening;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform _camera;
    [SerializeField] Transform camera_holder;
    [Space]
    [SerializeField] Vector3 camera_offset;
    [SerializeField] Vector3 camera_rotation;
        
    float cam_shake_duration = 0.3f;
    float cam_shake_strenght = 0.3f;

    private void FixedUpdate()
    {
        SetCameraPosition();
        SetCameraRotation();
    }

    private void SetCameraPosition()
    {
        camera_holder.transform.position = new Vector3(player.position.x + camera_offset.x, player.position.y + camera_offset.y, player.position.z + camera_offset.z);
    }

    private void SetCameraRotation()
    {
        camera_holder.transform.rotation = Quaternion.Euler(camera_rotation.x, camera_rotation.y, camera_rotation.z);
    }

    public void Camera_Shake()
    {
        _camera.DOShakePosition(cam_shake_duration, cam_shake_strenght);
    }
}