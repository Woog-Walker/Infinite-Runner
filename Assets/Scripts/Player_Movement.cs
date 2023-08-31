using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    [SerializeField] float turn_velocity;
    [SerializeField] float clamp_x_axis;
    [SerializeField] float speedModifier;

    [HideInInspector] public bool has_started = false;

    private Touch touch;
    float tmp_speed;

    private void Start()
    {
        tmp_speed = speed;
        speed = 0;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.D))
            Turn_Right();

        if (Input.GetKey(KeyCode.A))
            Turn_Left();
#else
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }

        Clamp_Player_X_Axi();
#endif
    }

    private void Turn_Right()
    {
        if (transform.position.x < clamp_x_axis)
            transform.position = new Vector3(transform.position.x + turn_velocity, transform.position.y, transform.position.z);
    }

    private void Turn_Left()
    {
        if (transform.position.x > -clamp_x_axis)
            transform.position = new Vector3(transform.position.x - turn_velocity, transform.position.y, transform.position.z);
    }

    public void Start_Movement()
    {
        speed = tmp_speed;
    }

    void Clamp_Player_X_Axi()
    {
        Vector3 player_position = transform.position;
        player_position.x = Mathf.Clamp(player_position.x, -2, 2);
        transform.position = player_position;
    }

    #region from cubes array to tmp
    #endregion

}