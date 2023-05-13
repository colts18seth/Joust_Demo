using System.Collections.Generic;
using UnityEngine;

public class LanceBehavior : MonoBehaviour
{
    public float breakDot = 0.95f;
    public float breakSpeed = 5.5f;
    
    private JoustBehavior _joustBehavior;
    private LanceSpawnerBehavior _spawner;
    private GameObject _fullLance;
    private GameObject _brokenLanceHandle;
    private GameObject _brokenLanceTip;
    private Rigidbody _rbLance;
    private ParticleSystem _woodChips;
    private List<GameObject> childObjects = new List<GameObject>();
    private bool _isInstantiated = false;

    private void Awake()
    {
        _spawner = GameObject.Find("LanceSpawner").GetComponent<LanceSpawnerBehavior>();
        _joustBehavior = GameObject.Find("Global Vars").GetComponent<JoustBehavior>();

        // Get rigidbody from Lance
        _rbLance = GetComponent<Rigidbody>();

        // Loop over children to get all types of breaks
        foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            Transform childTransform = child.transform;
            childObjects.Add(childTransform.gameObject);
        }

        _fullLance = childObjects[0];

        // Get random broken from childObjects between 1 and childcount - 2
        // (don't want full lance which is 0 or Grabpoints or Button Interactor which are the last two in the list)
        _brokenLanceHandle = childObjects[Random.Range(1, childObjects.Count - 2)];
        childObjects.Clear();
        foreach (Transform child in _brokenLanceHandle.GetComponentInChildren<Transform>())
        {
            Transform childTransform = child.transform;
            childObjects.Add(childTransform.gameObject);
        }

        _brokenLanceTip = childObjects[0];
        _woodChips = childObjects[1].GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if lance hits enemy
        if (collision.gameObject.tag.Contains("Enemy") && !_isInstantiated)
        {
            // get direction of enemy armor/shield and lance
            Vector3 collisionNormal = collision.contacts[0].normal;
            Vector3 lanceDirection = transform.forward;
            // get angle of impact
            float dot = Vector3.Dot(collisionNormal, lanceDirection);

            // get speed of lance
            float speed = _rbLance.velocity.magnitude;

            // if angle is straight enough and speed is fast enough
            if (Mathf.Abs(dot) >= breakDot && speed >= breakSpeed)
            {
                // break lance
                _brokenLanceHandle.SetActive(true);
                _brokenLanceTip.transform.parent = null;
                _woodChips.Play();
                _fullLance.SetActive(false);
                _rbLance.ResetCenterOfMass();
                _spawner.clearDebris(_brokenLanceTip, gameObject);
                _isInstantiated = true;
                _joustBehavior.AddScore(collision.gameObject.tag);
                StartCoroutine(_joustBehavior.ReturnToJoustStart());
            }
            else
            {
                Debug.Log("Speed: " + speed + " - Dot: " + dot);
            }
        }
    }
}