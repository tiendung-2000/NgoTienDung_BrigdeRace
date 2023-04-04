using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : IState
{
    int targetBrick;
    public void OnEnter(BotController botController)
    {
        targetBrick = Random.Range(2, 6);
        botController.SetDestionation(GetPosBrick(botController));
        Debug.Log(GetPosBrick(botController));
    }

    public void OnExecute(BotController botController)
    {
       
      //  botController.SetDestionation(GetPosBrick(botController));

       

        if (botController.IsDestination)
        { 
            if(botController.listBrickCharater.Count == targetBrick)
            {
               
            }
            //+change state finish
            //-botController.SetDestionation(GetPosBrick(botController));

        }
       
        
    }

    public void OnExit(BotController botController)
    {
       
    }


   Vector3 vt3;
    public Vector3 GetPosBrick(BotController bot)
    {  
     
       
        for(int i = 0; i< bot.brickGenerator.spawnedBricks.Length ; i++)
        {
            if (bot.characterColor == bot.brickGenerator.spawnedBricks[i].brickColorName)
            {

                vt3 = bot.brickGenerator.spawnedBricks[i].position;
           
            }
        }
        return vt3;
    }
}
