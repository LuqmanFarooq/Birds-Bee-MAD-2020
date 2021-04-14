using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Bird states abstract class  
*/

public abstract class BirdState : MonoBehaviour
{
    protected readonly Bird bird;

    public BirdState(Bird bird)
    {
        this.bird = bird;
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
