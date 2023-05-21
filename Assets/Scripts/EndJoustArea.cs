using UnityEngine;

public class EndJoustArea : MonoBehaviour
{
    public static bool endJoust = false;
    public JoustBehavior JoustBehavior;
    private bool _entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_entered)
        {
            _entered = true;
            endJoust = true;
            JoustBehavior.EndTiltWithoutScore();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            endJoust = false;
            _entered = false;
        }
    }
}
