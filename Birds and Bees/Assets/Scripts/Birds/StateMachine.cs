using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


/*
    This script is responsible for keeping the current states of birds and bees.
    It also checks if new state is different and calls exit function.
 */

public abstract class StateMachine : MonoBehaviour
{
    public BirdState BirdState;
    public BeeState BeeState;
    public void SetState(BirdState state)
    {
        try
        {
            BirdState.Exit();
        }
        catch { }
        BirdState = state;
        BirdState.Enter();
    }
    public void SetState(BeeState state)
    {
        try
        {
            BeeState.Exit();
        }
        catch { }

        BeeState = state;
        BeeState.Enter();
    }



}

