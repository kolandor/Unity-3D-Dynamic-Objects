using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public bool Move = true;

    public float Speed = 1;

    public bool SelfDestroyByTime = true;

    public int SelfDestroyTime = 20;

    public bool UseForceForward = false;

    public float AccelerationFactor = 1;

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
        //Add force to rigidBody (Requires improvement)
        //https://answers.unity.com/questions/769441/how-do-i-make-a-gameobject-accelerate.html
        if (UseForceForward)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward);
        }
        else//Static object movement
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }
}
