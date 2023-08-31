using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    Animator animtor;

    [Header("ragdoll push forwad")]
    [SerializeField] Rigidbody part_to_push;
    [SerializeField] float power;

    private void Awake()
    {
        animtor = GetComponent<Animator>();
    }

    public void Animation_Jump()
    {
        animtor.SetTrigger("Jump");
    }

    public void Ragdoll_Push()
    {
        animtor.enabled = false;

        part_to_push.AddForce(Vector3.up * power);
        part_to_push.AddForce(Vector3.forward * power);

        Handheld.Vibrate();
    }
}