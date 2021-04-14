using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This Script is responsible for bird eating bee.
 */


public class EatingState : BirdState
{
    public EatingState(Bird bird) : base(bird)
    {
    }

    public override void Enter()
    {
        bird.SetEnergyToMax();
    }

    float time;
    public override void GameUpdate()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            bird.SetState(new FlyingState(bird));
        }
    }



}
