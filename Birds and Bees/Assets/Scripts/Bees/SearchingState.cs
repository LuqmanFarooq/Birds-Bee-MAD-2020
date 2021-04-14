using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
    This script is responsible for  moving  bees randomly on map
    and searching for flowers in defined range.            
*/

class SearchingState : BeeState
{
    public SearchingState(Bee _bee) : base(_bee)
    {
    }
    
    Vector3 pathPoint;
    List<GameObject> flowers = new List<GameObject>();

    float detectionRange = 5;
    public override void Enter()
    {
        bee.GetComponent<SpriteRenderer>().color = Color.black;
        if (bee.currentPayload < bee.maxPayload)
        {

            pathPoint = bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
            
            flowers = Map.flowersObj;
        }
        else
        {
            bee.SetState(new BeeFlyingState(bee, null));
        }
    }  

    public Transform FlowerInRange()
    {
        List<Transform> _flowersInRange = new List<Transform>();

        foreach (GameObject b in flowers)
        {
            if (Vector2.Distance(bee.transform.position, b.transform.position) < detectionRange)
            {
                _flowersInRange.Add(b.transform);
            }
        }

        if (_flowersInRange.Count == 0)
        {
            return null;
        }


        float minDist = Mathf.Infinity;
        Transform tMin = null;

        foreach (Transform t in _flowersInRange)
        {
            float dist = Vector2.Distance(t.position, bee.transform.position);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;
    }

    public override void GameUpdate()
    {
        if(bee.energy < (bee.maxEnergy / 1/2))
        {
            pathPoint = bee.hive.position;
            bee.Move(pathPoint, 0f);
            if (Vector3.Distance(bee.transform.position, pathPoint) < 0.1f)
            {
                bee.SetState(new HiveState(bee));
                
            }
        }

        if (FlowerInRange() != null)
        {
            bee.Move(FlowerInRange().position, 0.1f);
            if (Vector2.Distance(bee.transform.position, FlowerInRange().position) < 0.1f)
            {
                GameObject flower = FlowerInRange().gameObject;
                Map.flowersObj.Remove(flower);
                Destroy(flower);
                bee.SetState(new GatheringState(bee));
            }

        }
        else
        {
            //if outside of simulation area
            if (!Map.mapBoundary.Contains(pathPoint))
            {
                pathPoint = bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
            }

            if (Vector3.Distance(bee.transform.position, pathPoint) < 0.1f)
            {
                pathPoint = bee.transform.position + new Vector3(Random.Range(-3, 4), Random.Range(-3, 4), 0);
              
            }

            bee.Move(pathPoint, 0.1f);
   
        }
    
    
    }

    public override void Exit()
    {
        Debug.Log("Exited searching");
    }

}