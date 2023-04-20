using System.Xml.Serialization;
using UnityEngine;

public class PlayerPieceMovement : MonoBehaviour
{
    public GameObject playerPieceOutline;
    public GameObject homeRing;
    public GameObject level1Ring;
    public GameObject level2Ring;
    public GameObject level3Ring;
    public Rigidbody rb;
    public bool isMoving = false;
    public Vector3 currentPosition;
    public Vector3 dropPositionHome = new Vector3(23.2915001f, 1.2859f, -3.86030006f);
    public Vector3 dropPositionLevel1 = new Vector3(23.4123001f, 1.2859f, -3.8513999f);
    public Vector3 dropPositionLevel2 = new Vector3(23.5366001f, 1.2859f, -3.74589992f);
    public Vector3 dropPositionLevel3 = new Vector3(23.7136993f, 1.2859f, -3.75200009f);

    private void Start()
    {
        playerPieceOutline.SetActive(false);
    }

    private void Update()
    {
        if (isMoving)
        {
            playerPieceOutline.SetActive(true);
            if (GetComponent<CapsuleCollider>().bounds.Intersects(homeRing.GetComponent<CapsuleCollider>().bounds))
            {
                playerPieceOutline.transform.SetPositionAndRotation(dropPositionHome, new Quaternion(0f, 0f, 0f, 0f));
            }
            if (GetComponent<CapsuleCollider>().bounds.Intersects(level1Ring.GetComponent<CapsuleCollider>().bounds))
            {
                playerPieceOutline.transform.SetPositionAndRotation(dropPositionLevel1, new Quaternion(0f, 0f, 0f, 0f));
            }
            if (GetComponent<CapsuleCollider>().bounds.Intersects(level2Ring.GetComponent<CapsuleCollider>().bounds))
            {
                playerPieceOutline.transform.SetPositionAndRotation(dropPositionLevel2, new Quaternion(0f, 0f, 0f, 0f));
            }
            if (GetComponent<CapsuleCollider>().bounds.Intersects(level3Ring.GetComponent<CapsuleCollider>().bounds))
            {
                playerPieceOutline.transform.SetPositionAndRotation(dropPositionLevel3, new Quaternion(0f, 0f, 0f, 0f));
            }
        }
    }

    public void isGrabbed()
    {
        isMoving = true;      
    }

    public void isNotGrabbed()
    {
        isMoving = false;
        playerPieceOutline.SetActive(false);
        rb.velocity = Vector3.zero;
        transform.SetPositionAndRotation(playerPieceOutline.transform.position, playerPieceOutline.transform.rotation);
    } 
}