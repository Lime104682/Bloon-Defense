using System.Collections.Generic;
using UnityEngine;

public class Move_Bloon : MonoBehaviour
{
    [Header("Path")]
    [SerializeField] 
    private Transform pathParent;
    [SerializeField] 
    private float moveSpeed = 0.1f;

    private List<Transform> waypoints = new List<Transform>();
    private int curindex = 0;

    void Start()
    {
        pathParent = GameObject.Find("Path").transform;
        
        if (pathParent == null)
        {
            Debug.Log("pathParent 없음");
            return;
        }

        // Path 하위의 웨이포인트 자동 수집
        foreach (Transform child in pathParent)
        {
            waypoints.Add(child);
        }

        if (waypoints.Count < 0)
        {
            Debug.Log("waypoints 없음");
            return;
        }

        //시작 위치 지정
        transform.position = waypoints[0].position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (curindex >= waypoints.Count)
            return;

        Transform target = waypoints[curindex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.fixedDeltaTime
        );

        // 목표 지점 도착 체크
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            curindex++;

            // 마지막 지점 도착
            if (curindex >= waypoints.Count)
            {
                ReachGoal();
            }
        }
    }

    void ReachGoal()
    {
        // TODO: 라이프 감소
        Destroy(gameObject);
    }
}
