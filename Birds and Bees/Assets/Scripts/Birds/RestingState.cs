using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This Script is responsible for bird rest and fly around path after regaining energy.
*/

class RestingState : BirdState
{
    private Transform[] pathPoints;

    public RestingState(Bird bird) : base(bird)
    {
    }
    public override void Enter()
    {
        bird.isChasing = false;
    }
    public override void GameUpdate()
    {
        if (bird.energy < bird._maxEnergy)
        {
            bird.energy += 5 * Time.deltaTime;
        }
        else
        {
            bird.SetState(new FlyingState(bird));
        }
    }
    public override void Exit()
    {

    }


}

