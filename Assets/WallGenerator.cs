using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    private List<WallData> buindingData = new List<WallData>();
    public int width;
    public int length;
    public int random1;
    public int random2;
    public int count = 0;
    public int random11;
    public Transform prefab;
    public List<int> pivotlist = new List<int>();
    public List<int> kapilist = new List<int>();
    public List<int> centerlist = new List<int>();
    public ArrayList dimensionlist = new ArrayList();
    public GameObject[] kapiwall;
    public GameObject Roomtrigger;

    void Start()
    {
        DefineRoomCenters();
        InstantiateRoomCenters();
        GenerateWall();
        InstantiateWalls();
    }

    public void DefineRoomCenters()
    {
        Debug.Log("DENEME");
        int maxx = width;
        int minx = -1 * width;
        int maxz = length;
        int minz = -1 * length;
        int rrandom = 2;

        // ilk dýþkapý parametreleri / ilk oda bölünnmesi
        random1 = (minz + maxz) / 2;
        int kapi = Random.Range(minz, maxz);
        kapilist.Add(kapi + 300);
        kapilist.Add(random1 + 300);
        pivotlist.Add(random1 + 300);
        int[] dimensionmin = { maxx, minx, random1, minz };
        int[] dimensionmax = { maxx, minx, maxz, random1 };
        dimensionlist.AddRange(dimensionmin);
        dimensionlist.AddRange(dimensionmax);
        rrandom = 1;

        for (int a = 0; a < dimensionlist.Count; a++)
        {
            if (dimensionlist.Count > a * 4 + 3)
            {
                if (Mathf.Abs((int)dimensionlist[a * 4] - (int)dimensionlist[a * 4 + 1]) * Mathf.Abs((int)dimensionlist[a * 4 + 2] - (int)dimensionlist[a * 4 + 3]) > 500)
                {
                    random2 = Divide((int)dimensionlist[a * 4], (int)dimensionlist[a * 4 + 1], (int)dimensionlist[a * 4 + 2], (int)dimensionlist[a * 4 + 3]);
                    if (random2 != 311)
                    {


                        if ((int)dimensionlist[a * 4] - (int)dimensionlist[a * 4 + 1] < (int)dimensionlist[a * 4 + 2] - (int)dimensionlist[a * 4 + 3])
                        {
                            int[] dimensionminn = { (int)dimensionlist[a * 4], (int)dimensionlist[a * 4 + 1], random2, (int)dimensionlist[a * 4 + 3] };
                            int[] dimensionmaxx = { (int)dimensionlist[a * 4], (int)dimensionlist[a * 4 + 1], (int)dimensionlist[a * 4 + 2], random2 };
                            dimensionlist.AddRange(dimensionminn);
                            dimensionlist.AddRange(dimensionmaxx);
                            dimensionlist.RemoveRange(a * 4, 4);
                            a = a - 1;
                        }
                        else
                        {
                            int[] dimensionminn = { random2, (int)dimensionlist[a * 4 + 1], (int)dimensionlist[a * 4 + 2], (int)dimensionlist[a * 4 + 3] };
                            int[] dimensionmaxx = { (int)dimensionlist[a * 4], random2, (int)dimensionlist[a * 4 + 2], (int)dimensionlist[a * 4 + 3] };
                            dimensionlist.AddRange(dimensionminn);
                            dimensionlist.AddRange(dimensionmaxx);
                            dimensionlist.RemoveRange(a * 4, 4);
                            a = a - 1;
                        }
                    }
                }


                //  for (int s = 0; s < pivotlist.Count; s++)
                //  {
                //       Debug.Log("pivotlist");
                //       Debug.Log(pivotlist[s]);
                //  }
            }
        }

        // Her odalarýn duvarlarýnýn max ve min deðerleri
        for (int z = 0; z < dimensionlist.Count; z++)
        {
            //Debug.Log(dimensionlist[z]);
            int random22 = ((int)dimensionlist[z + 2] + (int)dimensionlist[z + 3]) / 2;
            int random33 = ((int)dimensionlist[z] + (int)dimensionlist[z + 1]) / 2;
            centerlist.Add(random22);
            centerlist.Add(random33);
            z = z + 3;
        }
    }


    public int Divide(int xmax, int xmin, int zmax, int zmin)
    {
        if (xmax - xmin < zmax - zmin)
        {
            if(zmin + 20>zmax || zmax-20<zmin)
            {
                return 311;
            }
            int decide = Random.Range(1, 3);
            if (decide==1)
            {
                random11 = (zmin + zmax) / 2 - Random.Range(2, 7);
            }
            else
            {
                random11 = (zmin + zmax) / 2 + Random.Range(2, 7);
            }
            int kapi = Random.Range(xmin+5, xmax-5);
            kapilist.Add(kapi + 300);
            kapilist.Add(random11 + 300);
            pivotlist.Add(random11 + 300);
            return random11;
        }
        else
        {
            if (xmin + 20 >xmax || xmax - 20 < xmin)
            {
                return 311;
            }
            int decide = Random.Range(1, 3);
            if (decide == 1)
            {
                random11 = (xmin + xmax) / 2 - Random.Range(2, 7);
            }
            else
            {
                random11 = (xmin + xmax) / 2 + Random.Range(2, 7);
            }
            int kapi = Random.Range(zmin+2, zmax-2);
            pivotlist.Add(random11);
            kapilist.Add(random11);
            kapilist.Add(kapi);
            return random11;
        }
    }



    private void InstantiateRoomCenters()
    {

        for (int i = 0; i < centerlist.Count; i++)
        {
            GameObject roomCenter = new GameObject("RoomRoot");
            // Instantiate(roomCenter, new Vector3(centerlist[i], 0, centerlist[i + 1]), Quaternion.identity);
            roomCenter.transform.position = new Vector3(centerlist[i], 0, centerlist[i + 1]);
            Debug.Log(centerlist[i]);
            Debug.Log(centerlist[i + 1]);
            i++;
        }
    }

    private void GenerateWall()
    {
        int totalroomNumber = centerlist.Count / 2;
        Debug.Log(totalroomNumber);
        for (int roomNumber = 0; roomNumber < totalroomNumber * 4; roomNumber++)
        {
            WallData roomData = new WallData();  // odanýn tüm duvarlarýnýn listesi
            //Vector3 roomcenter = new Vector3((dimensionlist[roomNumber] + dimensionlist[roomNumber + 1]/2), 0, (dimensionlist[roomNumber+2] + dimensionlist[roomNumber + 3] / 2));

            for (int z = (int)dimensionlist[roomNumber + 3]; z < (int)dimensionlist[roomNumber + 2]; z++)
                {
                    //   if (x==0 || z==0 || x==9 || z==9) { // do not generate inside room
                    Vector3 unitPosition = new Vector3((int)dimensionlist[roomNumber], 0, z);
                    bool isSharedWall = false;
                string roomRoot = "Room0" + roomNumber;
                Vector3 unitRotation = new Vector3(-180, 90, 180);
                    WallUnitData unitData = new WallUnitData(unitPosition, isSharedWall, roomRoot, unitRotation);
                    roomData.data.Add(unitData);
                    //  }
                }
                for (int z = (int)dimensionlist[roomNumber + 3]; z < (int)dimensionlist[roomNumber + 2]; z++)
                {
                   
                    Vector3 unitPosition = new Vector3((int)dimensionlist[roomNumber+1], 0, z);
                    bool isSharedWall = false;
                string roomRoot = "Room0" + roomNumber;
                Vector3 unitRotation = new Vector3(0, 90, 180);

                WallUnitData unitData = new WallUnitData(unitPosition, isSharedWall, roomRoot, unitRotation);
                    roomData.data.Add(unitData);
                    
                }
                for (int x = (int)dimensionlist[roomNumber + 1]; x < (int)dimensionlist[roomNumber]; x++)
                {
                   
                    Vector3 unitPosition = new Vector3(x, 0, (int)dimensionlist[roomNumber + 3]);
                    bool isSharedWall = false;
                    string roomRoot = "Room0" + roomNumber;
                Vector3 unitRotation = new Vector3(0, 0, 0);

                    WallUnitData unitData = new WallUnitData(unitPosition, isSharedWall, roomRoot, unitRotation);
                    roomData.data.Add(unitData);
                   
                }
                for (int x = (int)dimensionlist[roomNumber + 1]; x < (int)dimensionlist[roomNumber]; x++)
                {
                    
                    Vector3 unitPosition = new Vector3(x, 0, (int)dimensionlist[roomNumber + 2]);
                    bool isSharedWall = false;
                string roomRoot = "Room0" + roomNumber;
                Vector3 unitRotation = new Vector3(180, 0, 0);
                WallUnitData unitData = new WallUnitData(unitPosition, isSharedWall, roomRoot,unitRotation);
                    roomData.data.Add(unitData);
                   
                }
            
            buindingData.Add(roomData);
            roomNumber = roomNumber + 3;
        }

    }


    private void InstantiateWalls()
    {
        // i<buindingData.Count
        for (int i = 0; i < buindingData.Count; i++)
        {
            Debug.Log("KAAAAAAAAAAAAAAAA");
            Debug.Log(i);
            // k<buindingData[i].data.Count
            GameObject Room = new GameObject();
            Room.tag = "Room";
            for (int k = 0; k < buindingData[i].data.Count; k++)
            {

                WallUnitData currentData = buindingData[i].data[k];
                //  Debug.Log("Buindingdata");
                //  Debug.Log(buindingData[i].data[k]);
                //  Transform currentParent = GameObject.Find(currentData.roomRoot).transform;
                
                Room.name = currentData.roomRoot;         
            Instantiate(Resources.Load("WallPrefab") as GameObject, currentData.position, Quaternion.Euler(currentData.rotation)).transform.parent = GameObject.Find(Room.name).transform;
                // Debug.Log(buindingData[i].data[k].position);

               
                //   Debug.Log(currentData.position);
            }
        }
        for (int i = 0; i < kapilist.Count; i++)
        {
            if(kapilist[i]>200 || kapilist[i+1]>200)
            {
             Instantiate(Resources.Load("Wall_Kapili") as GameObject, new Vector3(kapilist[i]-300, 6f, kapilist[i + 1]-300), Quaternion.Euler(new Vector3(0, 0, 0))).transform.parent = this.transform;
            }
            Instantiate(Resources.Load("Wall_Kapili") as GameObject, new Vector3(kapilist[i], 6f, kapilist[i + 1]), Quaternion.Euler(new Vector3 (180,90,180))).transform.parent = this.transform;
            i = i + 1;
            // Kapýlar buraya instantiate edilecek
        }
 

        // Kapýlarýn bulunduðu yerdeki duvarlarý kaldýrma
        kapiwall = GameObject.FindGameObjectsWithTag("Wallpanel");
        for (int i=0; i < kapilist.Count; i++)
        {
            if(kapilist[i]>200)
            {
                kapilist[i] = kapilist[i] - 300;
                kapilist[i+1] = kapilist[i + 1] - 300;
            }
            Vector3 removelocation = new Vector3(kapilist[i], 0, kapilist[i + 1]);
            Debug.Log(kapilist.Count);
            GameObject Roomtriggerr = Instantiate(Roomtrigger, removelocation, transform.rotation); 
            for (int c = 0; c<kapiwall.Length;c++)
            {
                if(Vector3.Distance(kapiwall[c].transform.position, removelocation) <= 2)
                {
                    Destroy(kapiwall[c]);
                    
                }
            }
            i = i + 1;
        }

     


    }
}
