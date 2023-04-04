using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBrickState : State
{
    public override void OnStart(BotController botController)
    {
        MoveToNextPlatform(botController);
    }

    public override void OnUpdate(BotController botController)
    {
        if (botController.listBrickCharater.Count == 0)
        {
            botController.ChangeState(botController.SeekBrickState);
        }
    }

    public override void OnExit(BotController botController)
    {

    }

    private void MoveToNextPlatform(BotController botController)
    {
        Debug.Log("Build");

        int nextPlatform = botController.currentPlatform;

        RaycastHit nextPlatformLevel;
        Vector3 targetPos = botController.transform.position;
        for (int i = 0; i < 100; i++)
        {
            if (Physics.Raycast(botController.transform.position + Vector3.forward * i + new Vector3(0f, 1000f, 0f), Vector3.down, out nextPlatformLevel, Mathf.Infinity, botController.groundLayer))
            {
                if (nextPlatformLevel.transform.name == "Ground" + nextPlatform.ToString())
                {
                    targetPos = nextPlatformLevel.point;
                    break;
                }
            }
        }
        botController.navMeshAgent.SetDestination(targetPos);
    }
}

