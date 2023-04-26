using MalbersAnimations.Controller;
using UnityEngine;

public class BreakLance : MonoBehaviour
{
    public GameObject Lance;
    public GameObject brokenLanceHandle;
    public GameObject brokenLanceTip;
    public Rigidbody rbLance;
    public Rigidbody rbLanceTip;
    public ParticleSystem woodChips;
    public float breakDot = 0.95f;
    public float breakSpeed = 5.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            Vector3 lanceDirection = transform.forward;
            float dot = Vector3.Dot(collisionNormal, lanceDirection);
            float speed = rbLance.velocity.magnitude;
            if(Mathf.Abs(dot) >= breakDot && speed >= breakSpeed)
            {
                brokenLanceHandle.SetActive(true);
                brokenLanceTip.transform.parent = null;
                woodChips.Play();
                Lance.SetActive(false);
                rbLance.ResetCenterOfMass();
            }
            else
            {
                Debug.Log("Speed: " + speed + " - Dot: " + dot);
            }
        }
    }
}