using UnityEngine;

public class StartJoustArea : MonoBehaviour
{
    [SerializeField] private GameObject startJoustText;

    public static bool canJoust = false;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canJoust = true;
            }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canJoust = false;
            startJoustText.SetActive(false);
        }
    }
}
