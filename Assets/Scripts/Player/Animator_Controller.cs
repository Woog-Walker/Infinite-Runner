using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    [SerializeField] List<Rigidbody> body_parts = new List<Rigidbody>();    
    [SerializeField] Rigidbody part_to_push;
    [SerializeField] float power;

    [SerializeField] Animator animtor;

    public void Animation_Jump()
    {
        animtor.SetTrigger("Jump");
    }

    public void Ragdoll_Push()
    {
        animtor.enabled = false;

        foreach (var tmp_part in body_parts)
            tmp_part.isKinematic = false;

        part_to_push.AddForce(Vector3.up * power);
        part_to_push.AddForce(Vector3.forward * power);

        Handheld.Vibrate();
    }
}