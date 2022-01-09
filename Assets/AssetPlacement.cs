using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPlacement : MonoBehaviour
{
    private float minz, minx, maxx, maxz;
    public Vector3 center;
    public GameObject[] bathroom,kitchen,regular,saloon,bedroom;
    void Start()
    {
        StartCoroutine(DelayAction());
    }
    IEnumerator DelayAction()
    {

        yield return new WaitForSeconds(7);

        bathroom = GameObject.FindGameObjectsWithTag("Bathroom");

        for (int i = 0; i < bathroom.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < bathroom[i].transform.childCount; z++)
            {
                if (bathroom[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = bathroom[i].gameObject.transform.GetChild(z).position.x;
                if (bathroom[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = bathroom[i].gameObject.transform.GetChild(z).position.x;
                if (bathroom[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = bathroom[i].gameObject.transform.GetChild(z).position.z;
                if (bathroom[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = bathroom[i].gameObject.transform.GetChild(z).position.z;


            }
            center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
            Instantiate(Resources.Load("Assets_BathroomProps/prefabs/bathtub") as GameObject, new Vector3(minx+3, -0.5f, maxz-2), Quaternion.Euler(new Vector3(-90, 0, 0))) ;
            Instantiate(Resources.Load("Assets_BathroomProps/prefabs/sink2") as GameObject, new Vector3(minx + 3, 1f, minz + 0.5f), Quaternion.Euler(new Vector3(-90, 0, 0)));
           Instantiate(Resources.Load("Assets_BathroomProps/prefabs/toilet1") as GameObject, new Vector3(maxx - 3, 0.79f, minz + 2f), Quaternion.Euler(new Vector3(-90, 0, 90)));
            Instantiate(Resources.Load("Alstrainfinite/KitchenAppliances/Prefabs/Washer") as GameObject, new Vector3(maxx - 2, 1.5f, minz + 8), Quaternion.Euler(new Vector3(0, -90, 0)));
        }

        kitchen = GameObject.FindGameObjectsWithTag("Kitchen");
        for (int i = 0; i < kitchen.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < kitchen[i].transform.childCount; z++)
            {
                if (kitchen[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = kitchen[i].gameObject.transform.GetChild(z).position.x;
                if (kitchen[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = kitchen[i].gameObject.transform.GetChild(z).position.x;
                if (kitchen[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = kitchen[i].gameObject.transform.GetChild(z).position.z;
                if (kitchen[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = kitchen[i].gameObject.transform.GetChild(z).position.z;
            }
            center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
            if (maxx - minx > maxz - minz)
            {
                Debug.Log("GENÝS");
                Instantiate(Resources.Load("Alstrainfinite/KitchenAppliances/Prefabs/Fridge") as GameObject, new Vector3(((maxx+minx)/2)-7, 1.5f, minz + 2), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Alstrainfinite/KitchenAppliances/Prefabs/Stove") as GameObject, new Vector3((((maxx + minx) / 2)+3)+0.50f, 0.5f, maxz - 1), Quaternion.Euler(new Vector3(0, -180, 0)));
                for(int b=(int)(minx+1);b< (int)((maxx + minx) / 2) + 3;b=b+2)
                {
                    Instantiate(Resources.Load("Alstrainfinite/Prefabs/Cabinet4") as GameObject, new Vector3(b, -0.5f, maxz - 1), Quaternion.Euler(new Vector3(0, -180, 0)));
                }
            }
            else
            {
                Debug.Log("Z FARKI BUYUK");
                Instantiate(Resources.Load("Alstrainfinite/KitchenAppliances/Prefabs/Fridge") as GameObject, new Vector3(maxx-2, 1.5f, (maxz+minz)/ 2), Quaternion.Euler(new Vector3(0, -90, 0)));
                Instantiate(Resources.Load("Alstrainfinite/KitchenAppliances/Prefabs/Stove") as GameObject, new Vector3(minx + 2, 0.5f, (maxz + minz) / 2), Quaternion.Euler(new Vector3(0, 90, 0)));

            }

        }
        bedroom = GameObject.FindGameObjectsWithTag("Bedroom");
        for (int i = 0; i < bedroom.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < bedroom[i].transform.childCount; z++)
            {
                if (bedroom[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = bedroom[i].gameObject.transform.GetChild(z).position.x;
                if (bedroom[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = bedroom[i].gameObject.transform.GetChild(z).position.x;
                if (bedroom[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = bedroom[i].gameObject.transform.GetChild(z).position.z;
                if (bedroom[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = bedroom[i].gameObject.transform.GetChild(z).position.z;
            }
            center = new Vector3((maxx + minx) / 2, -0.5f, (maxz + minz) / 2);
            if (maxx - minx > maxz - minz)                                                     
             {
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/LongBeds/Long Bed Type 1") as GameObject, new Vector3(maxx-3.5f, -0.5f, ((maxz + minz) / 2) + 1.5f), Quaternion.Euler(new Vector3(0, -90, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/BedDesks/Bed Desk Type 2") as GameObject, new Vector3(maxx-3f, -0.5f, ((maxz + minz) / 2)+5 ), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/BedDesks/Bed Desk Type 2") as GameObject, new Vector3(maxx-3f , -0.5f, ((maxz + minz) / 2)-3 ), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/DressingTables/DressingTable Type5") as GameObject, new Vector3(minx + 3.5f, -0.5f, ((maxz + minz) / 2) + 1.5f), Quaternion.Euler(new Vector3(0, 90, 0)));
            }
            else
            {
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/LongBeds/Long Bed Type 1") as GameObject, new Vector3(((maxx + minx) / 2), -0.5f, minz + 3.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/BedDesks/Bed Desk Type 2") as GameObject, new Vector3(((maxx + minx) / 2)-3.5f, -0.5f,  minz + 3), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/BedDesks/Bed Desk Type 2") as GameObject, new Vector3(((maxx + minx) / 2)+3.5f, -0.5f, minz + 3), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Bedrooms/DressingTables/DressingTable Type5") as GameObject, new Vector3(((maxx + minx) / 2), -0.5f, maxz - 3.5f), Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            Instantiate(Resources.Load("Customizable_Furnture/Prefabs/Decoration/Rugs/Square Rug") as GameObject, center, Quaternion.Euler(new Vector3(0, -90, 0)));
        }

        regular = GameObject.FindGameObjectsWithTag("Regular Room");
        for (int i = 0; i < regular.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < regular[i].transform.childCount; z++)
            {
                if (regular[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = regular[i].gameObject.transform.GetChild(z).position.x;
                if (regular[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = regular[i].gameObject.transform.GetChild(z).position.x;
                if (regular[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = regular[i].gameObject.transform.GetChild(z).position.z;
                if (regular[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = regular[i].gameObject.transform.GetChild(z).position.z;
            }
            center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
        }

        saloon = GameObject.FindGameObjectsWithTag("Saloon");
        for (int i = 0; i < saloon.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < saloon[i].transform.childCount; z++)
            {
                if (saloon[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = saloon[i].gameObject.transform.GetChild(z).position.x;
                if (saloon[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = saloon[i].gameObject.transform.GetChild(z).position.x;
                if (saloon[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = saloon[i].gameObject.transform.GetChild(z).position.z;
                if (saloon[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = saloon[i].gameObject.transform.GetChild(z).position.z;
            }
            center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
        }

    }
}
