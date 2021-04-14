using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     This Script is responsible for Making bird go home for rest to regain energy. 
 */

class BackToNestState : BirdState
{

    public BackToNestState(Bird bird) : base(bird)
    {
    }

    public override void GameUpdate()
    {
        bird.Move(bird.nest.position, 0.8f);
        if ((Vector3.Distance(bird.transform.position, bird.nest.position) < 0.1f))
        {
            bird.SetState(new RestingState(bird));
        }
    }

}

