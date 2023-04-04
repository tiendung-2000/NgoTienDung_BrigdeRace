using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public BrickGenerator brickGenerator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("bot"))
        {   
            other.GetComponent<CharacterController>().brickGenerator = this.brickGenerator;

            brickGenerator.gameObject.SetActive(true);
            brickGenerator.ShuffleBrick();
        }
    }

}
