using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjectDestroyer : MonoBehaviour
{
    public string TargetObjectName;
    private GameObject _targetObject;

    public bool DestroyTargetObjectByGoalTrget = true;

    public bool SelfDestroyObjectByGoalTrget = false;

    public float DestroyDistanceFromTarget = 0.5f;

    public float DestroyTimeByGoalTrget = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        if (!string.IsNullOrEmpty(TargetObjectName))
        {
            _targetObject = GameObject.Find(TargetObjectName);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (DestroyTargetObjectByGoalTrget 
            && _targetObject != null
            && other.gameObject.name == TargetObjectName)
        {
            Destroy(_targetObject, DestroyTimeByGoalTrget);

            MoveObject move = _targetObject.GetComponent<MoveObject>();
            if (move != null)
            {
                move.MoveByKey = move.Move = false;
                Invoke("StopEnemyCar", 0.5f);
            }

            if (SelfDestroyObjectByGoalTrget)
            {
                Destroy(gameObject, DestroyTimeByGoalTrget);
            }
            Invoke("ChangeScene", DestroyTimeByGoalTrget);
        }
    }

    private void StopEnemyCar()
    {
        gameObject.GetComponent<MoveBlock>().Move = false;
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
