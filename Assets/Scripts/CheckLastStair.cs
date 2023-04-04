using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLastStair : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(ICloseDoor());
        }
    }

    IEnumerator ICloseDoor()
    {
        yield return new WaitForSeconds(0.5f);
        door.SetActive(true);
        door.GetComponent<MeshRenderer>().enabled = false;
    }
}
