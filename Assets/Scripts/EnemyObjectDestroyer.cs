using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjectDestroyer : MonoBehaviour
{
    public string TargetObjectName;
    private GameObject _targetObject;

    public bool TargetDestroyObjectByGoalTrget = true;

    public bool SelfDestroyObjectByGoalTrget = false;

    public float DestroyDistanceFromTarget = 0.5f;

    public float DestroyTimeByGoalTrget = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(TargetObjectName))
        {
            _targetObject = GameObject.Find(TargetObjectName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetObject != null &&
            Vector3.Distance(transform.position, _targetObject.transform.position) <= DestroyDistanceFromTarget)
        {
            Destroy(_targetObject, DestroyTimeByGoalTrget);

            MoveObject move = _targetObject.GetComponent<MoveObject>();
            if(move != null)
            {
                move.MoveByKey = move.Move = false;
            }

            if (SelfDestroyObjectByGoalTrget)
            {
                Destroy(gameObject, DestroyTimeByGoalTrget);
            }
            Invoke("ChangeScene", DestroyTimeByGoalTrget);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
