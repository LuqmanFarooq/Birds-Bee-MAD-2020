using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
   This Script Allows the birds to fly across predefinied path points,
    starts from the first point on the list of points.
    Path points are configurable from inspector window.
*/


class FlyingState : BirdState
{
    private Transform[] pathPoints;
    private int pathPointCount = 0;

    public FlyingState(Bird bird) : base(bird)
    {
    }
    public override void Enter()
    {
        bird.isChasing = false;
        if (bird.energy < bird._maxEnergy * 1 / 4)
        {
            bird.SetState(new BackToNestState(bird));
            return;
        }

        pathPoints = new Transform[bird.path.childCount];
        for (int i = 0; i < bird.path.childCount; i++)
        {
            pathPoints[i] = bird.path.GetChild(i);
        }

    }


    public override void GameUpdate()
    {
        if (pathPoints != null)
        {

            bird.Move(pathPoints[pathPointCount].position, 0.4f);

            if ((Vector3.Distance(bird.transform.position, pathPoints[pathPointCount].position) < 0.1))
            {
                pathPointCount++;
                if (pathPointCount == pathPoints.Length - 1)
                {
                    pathPointCount = 0;
                }
            }
        }
        if (bird.energy < bird._maxEnergy * 1 / 4)
        {
            bird.SetState(new BackToNestState(bird));
            return;
        }
    }
    public override void Exit()
    {
    }

}

