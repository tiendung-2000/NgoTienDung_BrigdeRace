using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerColor : MonoBehaviour
{
    public List<CharacterController> listCharacter;
    
    
    CharacterController character;

    private void Awake()
    {
         CharacterController character = FindObjectOfType<CharacterController>();
    }
    void Start()
    {
       

        //for (int i = 0; i < listCharacter.Count; i++)
        //{
        //    Rand = Random.Range(0, 3);
        //    for (int j = 0; j < 100; j++)
        //    {
        //        if (temp.Contains(Rand))
        //        {
        //            Rand = Random.Range(0, 3);
        //        }
        //        else
        //        {
        //            print(Rand);
                    
                   
        //            break;
        //        }

            
            
        //    }temp.Add(Rand);
            
        //    character.RandomCharacterColor(listCharacter[i].CharacterRenderer, (ColorType)Rand);

        }
    }



   

