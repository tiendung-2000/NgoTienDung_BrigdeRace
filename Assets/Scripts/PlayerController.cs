using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public JoystickMove joystickMove;
    public Transform playerRenderer;

    private void Awake()
    {
        joystickMove = GetComponent<JoystickMove>();
        
  
    }
    private void Start()
    {
        Rand = Random.Range(0, 3);
        for (int j = 0; j < 100; j++)
        {
            if (temp.Contains(Rand))
            {
                Rand = Random.Range(0, 3);
            }
            else
                break;
        }
        RandomCharacterColor(playerRenderer, (ColorType)Rand) ;
        temp.Add(Rand);
    }

    protected override void CharacterMoving()
    {
        Stair stair = CheckLayerStair();
        if (stair == null)
        {
            joystickMove.JoystickMoving();
        }
        else
        {
            if (stair.colorType == characterColor)
            {
                joystickMove.JoystickMoving();
            }
            else
            {
                if (listBrickCharater.Count > 0)
                {
                    stair.ChangeColor(characterColor);
                    RemoveBrick();
                }
                else

                {
                    joystickMove.StopMoving();
                }

            }
        }
    }

    public override void RandomCharacterColor(Transform playerRender ,ColorType colorType)
    {
        base.RandomCharacterColor(playerRender,colorType);
    }
}

