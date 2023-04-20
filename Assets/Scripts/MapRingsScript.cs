using UnityEngine;

public class MapRingsScript : MonoBehaviour
{
    public PlayerPieceMovement PlayerPieceMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerPiece"))
        {
             
        }
    }
}