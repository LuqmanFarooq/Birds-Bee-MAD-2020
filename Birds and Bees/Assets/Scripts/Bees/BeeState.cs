using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    bee states Abstract class
*/

public abstract class BeeState : MonoBehaviour
{
    protected readonly Bee bee;

    public BeeState(Bee bee)
    {
        this.bee = bee;
    }
    public virtual void Enter()
    {
    }
    public virtual void GameUpdate()
    {
    }
    public virtual void Exit()
    {
    }
}

