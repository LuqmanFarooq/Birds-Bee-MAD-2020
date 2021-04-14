using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   Sets deafult values for the Bird,
   moves the attached object,update states and color of sprite base on energy level
*/


public class Bird : StateMachine
{
    public Transform path;
    public Transform nest;
    public float speed;
    public float energy = 10;
    public float _maxEnergy;
    public bool isChasing = false;
    SpriteRenderer birdRenderer;

    void Start()
    {
        transform.position = nest.position;
        birdRenderer = GetComponent<SpriteRenderer>();
        SetState(new RestingState(this));    

    }

    public void SetEnergyToMax()
    {
        energy = _maxEnergy;
    }
    public void Move(Vector3 PosToMoveTo, float useEnergy)
    {
        transform.position = Vector2.MoveTowards(transform.position, PosToMoveTo, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

        energy -= useEnergy * Time.deltaTime;

       transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, PosToMoveTo - transform.position), 7 * Time.deltaTime);

    }
  
    private void FixedUpdate()
    {
        BirdState.GameUpdate();

        if (energy < _maxEnergy * 1 / 3)
        {
            birdRenderer.color = Color.red;
        }
        else if(energy < _maxEnergy * 1 / 2)
        {
            birdRenderer.color = Color.yellow;
        }
        else
        {
            birdRenderer.color = Color.green;
        }

    }

}



   

