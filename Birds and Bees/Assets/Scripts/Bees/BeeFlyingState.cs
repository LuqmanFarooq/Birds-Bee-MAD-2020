using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This script is responsible for bee fleeing
 */

class BeeFlyingState : BeeState
{
    public BeeFlyingState(Bee bee,Transform chaser) : base(bee)
    {
    }
    Vector3 point;
 
    public override void Enter()
    {
        bee.GetComponent<SpriteRenderer>().color = Color.red;
        point =bee.hive.position;   
    }

    public override void GameUpdate()
    {
     
        bee.Move(point, 0.3f);
       

        if (Vector3.Distance(bee.transform.position, point) < 0.1f)
        {
            bee.SetState(new HiveState(bee));
        }
    }
   
}

