using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    The script is responsible for bee gather flowers
    and sets the bee state to look for flowers again after it has been finished.
 */


class GatheringState : BeeState
{
    float time;
    public GatheringState(Bee bee) : base(bee)
    {
    }

    public override void Enter()
    {
        bee.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void GameUpdate()
    {
        time += Time.deltaTime;
        if (time >= 2f)
        {
            time = 0;
            try    // If during gahering, the bee was killed
            {
                bee.currentPayload += 1;
                bee.SetState(new SearchingState(bee));
            }
            catch { }
        }
      
    }

    public override void Exit()
    {
        
    }

}