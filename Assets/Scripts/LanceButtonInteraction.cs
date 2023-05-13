using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LanceButtonInteraction : MonoBehaviour
{
    private bool canClick = true;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider belongs to a UI button
        if (other.CompareTag("Button") && canClick)
        {
            canClick = false;

            // Get the UI button component
            Button button = other.GetComponent<Button>();

            // Perform button click or trigger desired events
            button.onClick.Invoke();

            StartCoroutine(EnableClickAfterDelay());
        }
    }

    private IEnumerator EnableClickAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        canClick = true;
    }
}