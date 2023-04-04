using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    public NavMeshAgent navMeshAgent;

    public State currentState;
    public Transform botRenderer;

    public LayerMask groundLayer;
    
    public BuildBrickState BuildBrickState = new BuildBrickState();
    public SeekBrickState SeekBrickState = new SeekBrickState();

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //ChangeState(new SeekBrickState());
        currentState = SeekBrickState;

        Rand = UnityEngine.Random.Range(0, 3);
        for (int j = 0; j < 100; j++)
        {
            if (temp.Contains(Rand))
            {
                Rand = UnityEngine.Random.Range(0, 3);
            }
            else break;

        }
        RandomCharacterColor(botRenderer, (ColorType)Rand);
        temp.Add(Rand);
    }

    Vector3 des;
    internal void SetDestionation(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
        des = point;
    }

    public bool IsDestination => Vector3.Distance(transform.position, des) < 0.1f;

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate(this);
        }
    }
    protected override void CharacterMoving()
    {

    }

    public override void RandomCharacterColor(Transform botRenderer, ColorType colorType)
    {
        base.RandomCharacterColor(botRenderer, colorType);
    }
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnStart(this);
        }
    }
}
