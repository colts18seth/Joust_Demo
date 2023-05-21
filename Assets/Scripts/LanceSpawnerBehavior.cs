using System.Collections;
using UnityEngine;

public class LanceSpawnerBehavior : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lance;

    public void clearDebris(GameObject[] oldlances)
    {
        foreach(GameObject lance in oldlances)
        {
            Destroy(lance, 5f);
        }
        Instantiate(lance, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //StartCoroutine(InstantiateLance(lance));        
    }

    public void clearDebris(GameObject _brokenLanceTip, GameObject oldLance)
    {
        Destroy(oldLance, 5f);
        Destroy(_brokenLanceTip, 5f);
        Instantiate(lance, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //StartCoroutine(InstantiateLance(lance));        
    }

    private IEnumerator InstantiateLance(GameObject lance)
    {
        yield return new WaitForSeconds(2f);

        Instantiate(lance, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}