using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : State
{
    int targetBrick;
    public override void OnStart(BotController botController)
    {
        botController.navMeshAgent.ResetPath();
        targetBrick = Random.Range(2, 6);
    }

    public override void OnUpdate(BotController botController)
    {
        if (botController.navMeshAgent.remainingDistance < 0.5f)
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
        float distanceToClosestBrick = 100000f;

        for (int i = 0; i < botController.bricks.Count; i++)
        {
            if (botController.characterColor == botController.bricks[i].brickColor)
            {
                float distanceToBrick = Vector3.Distance(botController.transform.position, botController.bricks[i].transform.position);
                if (distanceToBrick < distanceToClosestBrick)
                {
                    distanceToClosestBrick = distanceToBrick;
                    closestBrickPos = botController.bricks[i].transform.position;

                    //Debug.Log(closestBrickPos);
                }
            }
        }
        return closestBrickPos;
    }

    public void MoveToBrickClosest(BotController botController)
    {
        CreateListBrickClosest(botController);
        //Debug.Log("Stop");
        botController.navMeshAgent.velocity = Vector3.zero;
        botController.navMeshAgent.SetDestination(GetPosBrickClosest(botController));
    }

    public void CreateListBrickClosest(BotController botController)
    {
        botController.bricks.Clear();
        botController.brickGeneratorObject = GameObject.Find("BrickGenerator");
        if (botController.brickGeneratorObject != null)
        {
            for (int i = 0; i < botController.brickGeneratorObject.transform.childCount - 1; i++)
            {
                Brick brick = botController.brickGeneratorObject.transform.GetChild(i).GetComponent<Brick>();
                if (brick.brickColor == botController.characterColor)
                {
                    botController.bricks.Add(brick);
                }
            }
        }
    }
}
