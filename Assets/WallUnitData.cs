using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUnitData
{
    public Vector3 position;
    public bool isSharedWall;
    public string roomRoot;
    public Vector3 rotation;
    public WallUnitData(Vector3 aPosition, bool shouldSraheWall, string aRoomRoot,Vector3 aRotation)
    {
        position = aPosition;
        isSharedWall = shouldSraheWall;
        roomRoot = aRoomRoot;
        rotation = aRotation;
    }
}
