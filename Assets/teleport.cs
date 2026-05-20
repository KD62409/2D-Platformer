using System.Collections;
using UnityEngine;

public class teleprt : MonoBehaviour
{
    public Transform teleport
        ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.transform.position = teleport.transform.position;
        StartCoroutine(TeleportPlayer(1.0f));

    }
    IEnumerator TeleportPlayer(float timeToTeleport)
    {
        yield return new WaitForSeconds(timeToTeleport);
        teleport.gameObject.SetActive(true);
    }
}
