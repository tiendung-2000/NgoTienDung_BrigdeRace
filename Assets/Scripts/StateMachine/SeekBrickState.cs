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
        if (botController.navMeshAgent.remainingDistance < 0.1f)
        {
            if (botController.listBrickCharater.Count >= 3)
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

    //Vector3 vt3;
    public Vector3 GetPosBrickClosest(BotController botController)
    {
        Vector3 closestBrickPos = botController.transform.position;
        float distanceToClosestBrick = Mathf.Infinity;

        for (int i = 0; i < botController.brickGenerator.spawnedBricks.Length; i++)
        {
            if (botController.characterColor == botController.brickGenerator.spawnedBricks[i].brickColorName)
            {
                float distanceToBrick = Vector3.Distance(botController.transform.position, botController.brickGenerator.spawnedBricks[i].position);
                if (distanceToBrick < distanceToClosestBrick)
                {
                    distanceToClosestBrick = distanceToBrick;
                    closestBrickPos = botController.brickGenerator.spawnedBricks[i].position;

                    Debug.Log(closestBrickPos);
                }
            }
        }
        return closestBrickPos;
    }

    public void MoveToBrickClosest(BotController botController)
    {
        Debug.Log("di chuyen");
        botController.navMeshAgent.SetDestination(GetPosBrickClosest(botController));
    }

    public void CreateListBrickClosest(BotController botController)
    {
        botController.listBrickCharater.Clear();
        botController.brickGeneratorObject = GameObject.Find("BrickGenerator");
        if (botController.brickGeneratorObject != null)
        {
            for (int i = 0; i < botController.brickGeneratorObject.transform.childCount - 1; i++)
            {
                Brick brick = botController.brickGeneratorObject.transform.GetChild(i).GetComponent<Brick>();

                botController.listBrickCharater.Add(brick.transform);
            }
        }
    }
}
