using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
   This Script is resposible for placing hive with the mouse click at the start of Game
   and storing bees in list
*/

public class GameLogic : MonoBehaviour
{
    public GameObject beeHive;
    public GameObject bee;
    private Transform hive;
    private bool isHivePlaced = false;

    [HideInInspector]
    public List<GameObject> bees = new List<GameObject>();
    public static GameLogic instance;

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

    void Start()
    {
        hive = Instantiate(beeHive.transform, Camera.main.ScreenToWorldPoint(Input.mousePosition),Quaternion.identity);     
    }

    void Update()
    {
        if (!isHivePlaced)
        {
            hive.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
            if (Input.GetMouseButtonDown(0))
            {             
                isHivePlaced = true;

                for (int i = 0; i < 4; i++)
                {
                   bees.Add(Instantiate(bee, hive.position + new Vector3(Random.Range(-3,3),Random.Range(-3,3),0),Quaternion.identity));
                    bees[i].GetComponent<Bee>().SetHive(hive.transform);
                }

                hive = null;
         
            }
        }
    }
}
