using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



/*
    This Script is responsible for the automatic detection of Birds and Bees
*/



class ChaseController : MonoBehaviour
{
    public static ChaseController instance;
    public float detectionRange;
    public GameObject[] birds;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    

    public Transform[] BeesInRange(Transform chaser)
    {
        List<Transform> beesInRange = new List<Transform>();

        foreach (GameObject b in GameLogic.instance.bees)
        {
            if (Vector2.Distance(chaser.position, b.transform.position) < detectionRange)
            {
                beesInRange.Add(b.transform);
            }
        }

        if (beesInRange.Count == 0)
        {
            return null;
        }

        return beesInRange.ToArray();
    }

    public Transform closestObject(Vector3 origin,Transform[] objects)
    {
        float minDist = Mathf.Infinity;
        Transform minTrans = null;

        foreach (Transform trans in objects)
        {
            float dist = Vector3.Distance(trans.position, origin);
            if (dist < minDist)
            {
                minTrans = trans;
                minDist = dist;
            }
        }

        return minTrans;
    }

    public bool IsAnyBirdInRange(Bee bee)
    {
        if(Vector3.Distance(birds[0].transform.position, bee.transform.position) < detectionRange)
        {
            return true;
        }
        if (Vector3.Distance(birds[1].transform.position, bee.transform.position) < detectionRange)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if(BeesInRange(birds[0].transform) != null)
        {
            foreach(Transform b in BeesInRange(birds[0].transform))
            {
                b.GetComponent<Bee>().SetState(new BeeFlyingState(b.GetComponent<Bee>(), null));
            }
            if (!birds[0].GetComponent<Bird>().isChasing)
            {
                birds[0].GetComponent<Bird>().SetState(new ChasingState(birds[0].GetComponent<Bird>(), BeesInRange(birds[0].transform)[Random.Range(0, BeesInRange(birds[0].transform).Length)].GetComponent<Bee>()));
                birds[0].GetComponent<Bird>().isChasing = true;
            }
        }
        if (BeesInRange(birds[1].transform) != null && !birds[1].GetComponent<Bird>().isChasing)
        {
            foreach (Transform b in BeesInRange(birds[1].transform))
            {
                b.GetComponent<Bee>().SetState(new BeeFlyingState(b.GetComponent<Bee>(), null));
            }
            if (!birds[1].GetComponent<Bird>().isChasing)
            {
                birds[1].GetComponent<Bird>().SetState(new ChasingState(birds[1].GetComponent<Bird>(), BeesInRange(birds[1].transform)[Random.Range(0, BeesInRange(birds[1].transform).Length)].GetComponent<Bee>()));
                birds[1].GetComponent<Bird>().isChasing = true;
            }
        }


    }
   
}

