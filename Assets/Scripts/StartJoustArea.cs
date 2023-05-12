using UnityEngine;

public class StartJoustArea : MonoBehaviour
{
    [SerializeField] private GameObject startJoustText;

    public bool canJoust => _canJoust;
    private bool _canJoust = false;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _canJoust = true;
            }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canJoust = false;
            startJoustText.SetActive(false);
        }
    }
}
