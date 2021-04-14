using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
     Makes bee unload payload at defined rate and dance
 */

class DancingState : BeeState
{
    public DancingState(Bee bee) : base(bee)
    {
    }

    private float time;
    private float Speed = 10f;
    public override void Enter()
    {
        bee.transform.position += new Vector3(Random.Range(-2, 3), Random.Range(-1, 1), 0);
    }

    public override void GameUpdate()
    {
        time += Time.deltaTime;

        bee.transform.position += new Vector3(Mathf.Cos(time * Speed) * 0.4f, Mathf.Sin(time * Speed) * 0.4f, 0);

        if(bee.currentPayload <= 0)
        {
            // resetting
            bee.currentPayload = 0;
            bee.SetState(new HiveState(bee));
        }

        bee.currentPayload -= 0.2f * Time.deltaTime;    
    }

}

