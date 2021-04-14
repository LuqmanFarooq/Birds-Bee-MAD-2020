using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
  It checks whether bee has a payload and sets bee state to dance to unload it or makes bee recover energy.

*/

class HiveState : BeeState
{
    public HiveState(Bee bee) : base(bee)
    {
    }
    public override void Enter()
    {
        
        bee.GetComponent<SpriteRenderer>().color = Color.black;
        GameLogic.instance.bees.Remove(bee.gameObject);
        if(bee.currentPayload > 0 && !ChaseController.instance.IsAnyBirdInRange(bee))
        {
            bee.SetState(new DancingState(bee));
        }

      
    }
    public override void GameUpdate()
    {
        if (bee.energy <= bee.maxEnergy)
        {
            bee.energy += Time.deltaTime * 0.2f;
        }
        else
        {
            if (!ChaseController.instance.IsAnyBirdInRange(bee))
            {

                bee.SetState(new SearchingState(bee));
            }
        }
        
        if(Vector3.Distance(bee.transform.position,bee.hive.position) > 0.1f)
        {
            bee.Move(bee.hive.position, 0f);
        }

    }

    public override void Exit()
    {    
        GameLogic.instance.bees.Add(bee.gameObject);      
    }

}