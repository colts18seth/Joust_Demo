using UnityEngine;

public class ResetView : MonoBehaviour
{
    public Transform mountPosition;
    public GameObject player;

    private CharacterController _controller;
    private HorseBehavior _horseBehavior;
    private Camera _playerHead;

    private void Awake()
    {
        _horseBehavior = FindObjectOfType<HorseBehavior>();
        _playerHead = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _controller = FindObjectOfType<CharacterController>();
    }

    public void ResetViewMethod()
    {
        if (_horseBehavior.IsMounted)
        {
            var rotationAngleY = mountPosition.rotation.eulerAngles.y - _playerHead.transform.rotation.eulerAngles.y;
            player.transform.Rotate(0, rotationAngleY, 0);

            var distanceDiff = mountPosition.position - _playerHead.transform.position;
            player.transform.position += distanceDiff;

            _controller.height = _horseBehavior.MountHeight;
        }
    }
}