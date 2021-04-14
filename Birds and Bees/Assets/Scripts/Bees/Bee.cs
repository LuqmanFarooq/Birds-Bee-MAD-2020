using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This Script Sets the deafult values for Bee,
    moves the attached object and update states
*/


public class Bee : StateMachine
{
    public float speed = 12;
    public float energy = 2;
    public float maxEnergy = 3;
    public float maxPayload = 2;
    public float currentPayload = 0;

   [HideInInspector] public Transform hive;

    void Start()
    {
        SetState(new SearchingState(this));
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(6f);
        SetState(new BeeFlyingState(this, null));
    }
    public void SetHive(Transform hive)
    {
        this.hive = hive;
    }
    public void Move(Vector3 PosToMoveTo, float useEnergy)
    {
        transform.position = Vector2.MoveTowards(transform.position, PosToMoveTo, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

        energy -= useEnergy * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        BeeState.GameUpdate();
    }
}// class
