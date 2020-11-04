using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBlocksGeneration : MonoBehaviour
{
    public GameObject DangerBlockPrefab;

    public bool Generate = true;

    public float GenerateDistanceByZ = 30;

    public int GenerationIntensity = 50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (DangerBlockPrefab == null)
        {
            throw new System.Exception("DangerBlockPrefab link not found!");
        }

        if (Generate && Time.frameCount % 60 == 0)
        {
            for (float i = 0; i < GenerateDistanceByZ; i++)
            {
                if (Random.Range(1, 100) <= GenerationIntensity)
                {
                    float distanceX = transform.position.x;
                    float distanceY = transform.position.y;
                    float distanceZ = transform.position.z + i;

                    Instantiate(DangerBlockPrefab, new Vector3(distanceX, distanceY, distanceZ), DangerBlockPrefab.transform.rotation);
                }
            }
        }
    }
}
