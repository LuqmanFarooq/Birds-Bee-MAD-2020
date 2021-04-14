using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is responsible for setting map borders, storing flowers, and setting map sizes.



public class Map : MonoBehaviour
{
    public float size;
    public Transform mapSprite;


    public GameObject flowerPrefab;

    public int amountOfFlowers;


    private Vector2 center;

    public static Map area;


    public static List<GameObject> flowersObj = new List<GameObject>();

    private void Awake()
    {
        if (area != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            area = this;
        }
    }

    public static Bounds mapBoundary;

    void Start()
    {
        center = Camera.main.transform.position;
        mapSprite.localScale = new Vector3(size * 2 + 10, size+1, 0);

        spawnFlowers(amountOfFlowers);

        mapBoundary.center = center;
        mapBoundary.size = new Vector3(size * 2 + 10, size,5);

    }

   

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(center, new Vector3(size*2+10, size,5));
    }


    void spawnFlowers(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            flowersObj.Add(Instantiate(flowerPrefab, new Vector3(Random.Range(-size  , size ), Random.Range(-size /2, size/2 ),1), Quaternion.identity));
        }

    }
    

   
}
