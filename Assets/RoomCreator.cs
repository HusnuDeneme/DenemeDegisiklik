using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RoomCreator : MonoBehaviour
{
    public GameObject[] rooms;
    public Transform meeple;
    private float minz, minx, maxx, maxz;
    public int[] size, sortedsize;
    public Vector3[] center;
    public float delayTime = 5.0f;
    void Start()
    {
        StartCoroutine(DoDelayAction());
    }
    IEnumerator DoDelayAction()
    {

        yield return new WaitForSeconds(5);
      
        rooms = GameObject.FindGameObjectsWithTag("Room");
        sortedsize = new int[rooms.Length];
        size = new int[rooms.Length];
        center = new Vector3[rooms.Length];
        for (int i = 0; i < rooms.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < rooms[i].transform.childCount; z++)
            {
                if (rooms[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = rooms[i].gameObject.transform.GetChild(z).position.x;
                if (rooms[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = rooms[i].gameObject.transform.GetChild(z).position.x;
                if (rooms[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = rooms[i].gameObject.transform.GetChild(z).position.z;
                if (rooms[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = rooms[i].gameObject.transform.GetChild(z).position.z;

               
            }
            center[i] = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
            sortedsize[i] = (int)(maxx - minx) * (int)(maxz - minz);
            size[i] = (int)(maxx - minx) * (int)(maxz - minz);




        }
        Array.Sort(sortedsize);
        for (int i=0; i<sortedsize.Length;i++)
        {
            // 7 den büyükse 3 tuvalet 2 mutfak 1 salon
            // 10 dan büyükse 3 tuvalet 2 mutfak 2 salon
            for(int z=0; z < sortedsize.Length; z++)
            {
                if (sortedsize[i]==size[z])
                {
                    if (i < 2)
                    {
                        rooms[z].tag = "Bathroom";
                        Debug.Log("ODALAAAR");
                   
                    }
                    else if (i < 3)
                    {
                        rooms[z].tag = "Kitchen";
                    }
                    else if (i < 5)
                    {
                        rooms[z].tag = "Regular Room";
                    }
                    else if (i < 7)
                    {
                        rooms[z].tag = "Bedroom";
                    }
                    else
                    {
                        rooms[z].tag = "Saloon";
                    }
                }

            }
        }

    }
}
