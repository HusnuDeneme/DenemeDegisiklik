using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity2Float : MonoBehaviour
{

	public LibPdInstance pdPatch;
	
	public Transform targetLocation;
	public Transform sensorBounds;


	void Start()
	{

		float proximity = Vector3.Distance(targetLocation.position, sensorBounds.position);

		float note1 = 1.0f;
		float note2 = 2.0f;
		float volume = 0.5f;
		pdPatch.SendFloat("note1", note1);
		pdPatch.SendFloat("note2", note2);
		pdPatch.SendFloat("volume", volume);
	}
	void Update()
	{
		float proximity = 10f;
		if (proximity > 10.0f)
		{
			pdPatch.SendFloat("note1", 6f);
			pdPatch.SendFloat("volume", 0.1f);
		}
		//pdPatch.SendFloat("proximity", proximity);
	}
}