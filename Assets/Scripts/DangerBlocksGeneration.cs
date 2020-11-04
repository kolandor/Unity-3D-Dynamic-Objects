using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBlocksGeneration : MonoBehaviour
{
    public GameObject DangerObjectPrefab;

    public bool Generate = true;

    public float ObjectsCount = 20;

    public float DistanceBetweenObjects = 0;

    public float SecondsSpawnFrequency = 2;

    public int GenerationProbability = 3;

    public
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBlocks", 0, SecondsSpawnFrequency);
    }

    // Update is called once per frame
    void SpawnBlocks()
    {
        if (DangerObjectPrefab == null)
        {
            throw new System.Exception("DangerBlockPrefab link not found!");
        }

        //Colider size calculate from center, so this is half of objets size and i multiply it
        float zSizeOfObjest = DangerObjectPrefab.GetComponent<BoxCollider>().size.z * 2;

        for (float i = 0; i < ObjectsCount; i++)
        {
            if (Random.Range(1, 100) <= GenerationProbability)
            {
                float positionX = transform.position.x;
                float positionY = transform.position.y;
                float positionZ = transform.position.z + zSizeOfObjest * i + DistanceBetweenObjects * i;

                Instantiate(DangerObjectPrefab, new Vector3(positionX, positionY, positionZ), DangerObjectPrefab.transform.rotation);
            }
        }
    }
}
