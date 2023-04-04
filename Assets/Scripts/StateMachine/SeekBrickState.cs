using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : State
{
    int targetBrick;
    public override void OnStart(BotController botController)
    {
        targetBrick = Random.Range(2, 6);
    }

    public override void OnUpdate(BotController botController)
    {
        //botController.SetDestionation(GetPosBrickClosest(botController));

        //if (botController.IsDestination)
        //{ 
        //    if(botController.listBrickCharater.Count == targetBrick)
        //    {
        //       //build Brick
        //    }
        //}
        if (botController.navMeshAgent.remainingDistance < 0.1f)
        {
            if (botController.listBrickCharater.Count >= 10)
            {
                botController.ChangeState(botController.BuildBrickState);
            }
            else
            {
                MoveToBrickClosest(botController);
            }
        }
    }

    public override void OnExit(BotController botController)
    {
       
    }


   Vector3 vt3;
    public Vector3 GetPosBrickClosest(BotController botController)
    {  
        for(int i = 0; i< botController.brickGenerator.spawnedBricks.Length ; i++)
        {
            if (botController.characterColor == botController.brickGenerator.spawnedBricks[i].brickColorName)
            {
                vt3 = botController.brickGenerator.spawnedBricks[i].position;
            }
        }
        return vt3;
    }

    public void MoveToBrickClosest(BotController botController)
    {

        botController.navMeshAgent.SetDestination(GetPosBrickClosest(botController));
    }

    public void CreateListBrickClosest(BotController botController)
    {
        botController.listBrickCharater.Clear();
        botController.brickGeneratorObject = GameObject.Find("BrickGenerator");
        if(botController.brickGeneratorObject!= null )
        {
            for(int i = 0; i < botController.brickGeneratorObject.transform.childCount -1; i++)
            {
                Brick brick = botController.brickGeneratorObject.transform.GetChild(i).GetComponent<Brick>();

                botController.listBrickCharater.Add(brick.transform);
            }
        }
    }
}
