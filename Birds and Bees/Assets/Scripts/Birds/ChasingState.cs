using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     This Script is resposible for chasing.
     If Bee is in range , it switches states to eating;
 */


class ChasingState : BirdState
{
    Bee chaseBee;
    public ChasingState(Bird bird, Bee bee) : base(bird)
    {
        chaseBee = bee;
    }
    public override void Enter()
    {
        if (bird.energy < bird._maxEnergy * 1 / 4)
        {
            bird.SetState(new BackToNestState(bird));
            return;
        }
        bird.isChasing = true;
    }

    public override void GameUpdate()
    {
        if (bird.energy < bird._maxEnergy * 1 / 4)
        {
            bird.SetState(new BackToNestState(bird));
        }




        //if bee has hide in hive
        if (chaseBee != null && (Vector3.Distance(bird.transform.position, chaseBee.transform.position) < ChaseController.instance.detectionRange) && GameLogic.instance.bees.Contains(chaseBee.gameObject))
        {
            bird.Move(chaseBee.transform.position, 0.8f);
            if ((Vector3.Distance(bird.transform.position, chaseBee.transform.position) < 0.3f))
            {
                GameLogic.instance.bees.Remove(chaseBee.gameObject);
                Destroy(chaseBee.gameObject);
                bird.SetState(new EatingState(bird));
            }
        }
        else
        {
            bird.SetState(new FlyingState(bird));

        }





    }

    public override void Exit()
    {
        bird.isChasing = false;
    }


}


