using UnityEngine;
using Zenject;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movement_speed;
    [SerializeField] float turn_velocity;
    [SerializeField] float speedModifier;
    [Space]
    [SerializeField] float clamp_x_axis;

    float tmp_speed;
    private Touch touch;
    bool can_interract = false;

    private void Start()
    {
        tmp_speed = movement_speed;
        movement_speed = 0;
    }

    private void FixedUpdate()
    {
        if (!can_interract) return;

        transform.Translate(Vector3.forward * Time.fixedDeltaTime * movement_speed);

#if UNITY_EDITOR
        Editor_Controller();
#endif

#if UNITY_ANDROID
        Android_Touch_Controller();
#endif
    }

    private void Android_Touch_Controller()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                {
                    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    new Vector3((transform.position.x + touch.deltaPosition.x) * speedModifier, transform.position.y, transform.position.z),
                    Time.fixedDeltaTime);

                    if (transform.position.x > clamp_x_axis)
                        transform.position = new Vector3(clamp_x_axis, transform.position.y, transform.position.z);
                }

                if (touch.deltaPosition.x < 0 && transform.position.x > -clamp_x_axis)
                {
                    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    new Vector3((transform.position.x + touch.deltaPosition.x) * speedModifier, transform.position.y, transform.position.z),
                    Time.deltaTime);

                    if (transform.position.x < -clamp_x_axis)
                        transform.position = new Vector3(-clamp_x_axis, transform.position.y, transform.position.z);
                }
            }
        }
    }

    private void Editor_Controller()
    {
        if (Input.GetKey(KeyCode.D))
            Turn_Right();

        if (Input.GetKey(KeyCode.A))
            Turn_Left();
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
        can_interract = true;
        movement_speed = tmp_speed;
    }

    public void Stop_Movemenet()
    {
        can_interract = false;
        movement_speed = 0;
    }
}