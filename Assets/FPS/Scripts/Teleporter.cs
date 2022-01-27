using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2022-01-26
public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public Transform teleport_To;

    public bool overlapse = false;

    PlayerCharacterController playerController;
    
    private void Start()
    {
        playerController = player.GetComponent<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, Teleporter>(playerController, this, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!overlapse && other.tag == "Player")
        {
            overlapse = true; //A lock until the teleport is completed entirely (I.e. doesn't teleport back and forth)
            playerController.enable = false;
            player.transform.position = new Vector3(teleport_To.transform.position.x + 0.5f, 0.5f, teleport_To.transform.position.z + 0.5f);

            waiter(0.01f); //re-enable player control
            waiter(5f); //cooldown
            overlapse = false;
        }
    }

    private void waiter(float t)
    {
        StartCoroutine(waitCount(t));
    }

    IEnumerator waitCount(float t)
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(t);
        playerController.enable = true;
    }
}
