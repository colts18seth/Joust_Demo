using System.Collections;
using UnityEngine;

public class LanceSpawnerBehavior : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject lance;
    
    public void clearDebris(GameObject _brokenLanceTip, GameObject oldLance)
    {
        Destroy(oldLance, 8f);
        Destroy(_brokenLanceTip, 8f);
        Instantiate(lance, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //StartCoroutine(InstantiateLance(lance));        
    }

    private IEnumerator InstantiateLance(GameObject lance)
    {
        yield return new WaitForSeconds(2f);

        Instantiate(lance, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}