using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public bool Move = true;

    public float Speed = 1;

    public bool SelfDestroyByTime = true;

    public int SelfDestroyTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        if(SelfDestroyByTime)
        {
            Destroy(gameObject, SelfDestroyTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
