using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLastStair : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("bot"))
        {
            Debug.Log("trigger");
            door.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("bot"))
        {
            CharacterController character = other.GetComponent<CharacterController>();
            character.currentPlatform++;
            //character.listBrickCharater.Clear();
            //character.bricks.Clear();

            //for(int i = 0; i <= character.bricks.Count -1; i++)
            //{
            //    Destroy(character.bricks[i]);
            //}
            for (int i = character.bricks.Count - 1; i >= 0; i--)
            {
                Destroy(character.bricks[i].gameObject);
                character.bricks.RemoveAt(i);
            }

            
            //if (other.GetComponent<BotController>() != null)
            //    LevelManager.instance.NewStageBrickList(character);
            //LevelManager.instance.SpawnBrick(character.currentStage);
            //character.ClearBrick();
            door.SetActive(true);

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
