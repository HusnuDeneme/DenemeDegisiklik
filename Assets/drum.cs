using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour
{
    public LibPdInstance pdPatch;

    

    // Update is called once per frame
    void Update()
    {
        float drum = 1.0f;
        pdPatch.SendFloat("drum", drum);
    }
}
