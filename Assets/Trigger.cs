using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private float minz, minx, maxx, maxz;
    public GameObject Roomsound, Kitchensound,Bathroomsound,Saloonsound,spotlight;
    public GameObject[] roomy;
    public GameObject player;
    public Vector3 center;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Ttrigger");
       

    }

    IEnumerator Ttrigger()
    {
        yield return new WaitForSeconds(0.3f);
        //   rooms = GameObject.Find("RoomAssets");

        Debug.Log("TRÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝGGGGGGGGGGGGGEEEEEEEEEEEERRRRRRRRRR");
        Debug.Log(roomy);
        Destroy(GameObject.FindWithTag("EditorOnly"));
        roomy = GameObject.FindGameObjectsWithTag("Bathroom");

        for (int i = 0; i < roomy.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < roomy[i].transform.childCount; z++)
            {
                if (roomy[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = roomy[i].gameObject.transform.GetChild(z).position.z;
                if (roomy[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = roomy[i].gameObject.transform.GetChild(z).position.z;
            }
            if (player.transform.position.x < maxx & player.transform.position.x > minx & player.transform.position.z < maxz & player.transform.position.z > minz)
            {
                Debug.Log("BANYO MÜZÝÐÝ");
                center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
                GameObject Roomsounds = Instantiate(Bathroomsound, center, transform.rotation);
                spotlight.transform.position = new Vector3(center.x, 5f, center.z);
                yield break;
            }

        }
        roomy = GameObject.FindGameObjectsWithTag("Kitchen");

        for (int i = 0; i < roomy.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < roomy[i].transform.childCount; z++)
            {
                if (roomy[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = roomy[i].gameObject.transform.GetChild(z).position.z;
                if (roomy[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = roomy[i].gameObject.transform.GetChild(z).position.z;
            }
            if (player.transform.position.x < maxx & player.transform.position.x > minx & player.transform.position.z < maxz & player.transform.position.z > minz)
            {
                Debug.Log("MUTFAK MÜZÝÐÝ");
                center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
                GameObject Roomsounds = Instantiate(Kitchensound, center, transform.rotation);
                spotlight.transform.position = new Vector3(center.x, 5f, center.z);
                yield break;
            }

        }

        roomy = GameObject.FindGameObjectsWithTag("Bedroom");

        for (int i = 0; i < roomy.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < roomy[i].transform.childCount; z++)
            {
                if (roomy[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = roomy[i].gameObject.transform.GetChild(z).position.z;
                if (roomy[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = roomy[i].gameObject.transform.GetChild(z).position.z;
            }
            if (player.transform.position.x < maxx & player.transform.position.x > minx & player.transform.position.z < maxz & player.transform.position.z > minz)
            {
                Debug.Log("YATAK ODASI MÜZÝÐÝ");
                center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
                GameObject Roomsounds = Instantiate(Roomsound, center, transform.rotation);
                spotlight.transform.position = new Vector3(center.x, 5f, center.z);
                yield break;
            }

        }
        roomy = GameObject.FindGameObjectsWithTag("Regular Room");

        for (int i = 0; i < roomy.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < roomy[i].transform.childCount; z++)
            {
                if (roomy[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = roomy[i].gameObject.transform.GetChild(z).position.z;
                if (roomy[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = roomy[i].gameObject.transform.GetChild(z).position.z;
            }
            if (player.transform.position.x < maxx & player.transform.position.x > minx & player.transform.position.z < maxz & player.transform.position.z > minz)
            {
                Debug.Log("DÜZ NORMAL ODA MÜZÝÐÝ");
                center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
                GameObject Roomsounds = Instantiate(Roomsound, center, transform.rotation);
                spotlight.transform.position = new Vector3(center.x, 5f, center.z);
                yield break;
            }

        }
        roomy = GameObject.FindGameObjectsWithTag("Saloon");

        for (int i = 0; i < roomy.Length; i++)
        {
            maxx = -30;
            maxz = -30;
            minx = 30;
            minz = 30;
            for (int z = 0; z < roomy[i].transform.childCount; z++)
            {
                if (roomy[i].gameObject.transform.GetChild(z).position.x > maxx)
                    maxx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.x < minx)
                    minx = roomy[i].gameObject.transform.GetChild(z).position.x;
                if (roomy[i].gameObject.transform.GetChild(z).position.z < minz)
                    minz = roomy[i].gameObject.transform.GetChild(z).position.z;
                if (roomy[i].gameObject.transform.GetChild(z).position.z > maxz)
                    maxz = roomy[i].gameObject.transform.GetChild(z).position.z;
            }
            if (player.transform.position.x < maxx & player.transform.position.x > minx & player.transform.position.z < maxz & player.transform.position.z > minz)
            {
                Debug.Log("SALON MÜZÝÐÝ");
                center = new Vector3((maxx + minx) / 2, 0, (maxz + minz) / 2);
                GameObject Roomsounds = Instantiate(Saloonsound, center, transform.rotation);
                spotlight.transform.position = new Vector3(center.x, 5f, center.z);
                yield break;
            }

        }
    }
}