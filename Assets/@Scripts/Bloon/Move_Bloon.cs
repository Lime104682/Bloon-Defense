using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO
 * 해당 Round 체크
 * Round에 맞는 풍선등급과 각 등급에 맞는 풍선갯수 만큼 
 * 0.1초(?)마다 풍선 인스턴스(Pool에서 꺼내기)
 * (자세히 기획하면 어느 순간에 어떤 등급의 풍선이 몇개씩 생성되는지에 대한 
 * 데이터도 있어야 되겠지만 여기선 축소함 -> Round.js)
 * 
 * 투사체 등의 풍선의 공격을 감지했다면 curHP -1, VM에 알려줘서 Money +1
 * 풍선 curHP가 0이라면 풍선 Pool에 반환
 * 풍선 curHP가 0이 아니라면 curHP에 맞는 이미지로 Sprite 변경
 * (curHP : 1 = 적색 , 2 = 청색 , 3 = 녹색 , 4 = 황색 , 5 = 흑색 , 6 = 백색)
 * 
 * 마지막 지점에 도착했다면 curHP를 SO에 알려줘 그만큼 Lives에서 빼기
 * 풍선 삭제
 * 
 * 
 * 인스턴스(Pool에서 꺼내거나 생성)된 풍선들을 관리할 상위 혹은 구독 스크립트 만들기
 * 예를 들어 해당 Round에 maxHP == 1인 풍선 5개를 만들어야 되면 
 * maxHP == 1인 풍선 5개를 만들었는지 확인하고 관리하는 스크립트임
 * 이제 여기서 
 * 맵에 남은 풍선이 존재하지 않는걸 확인했다면 SO에 알려줘서
 * Round +1 하고 해당 라운드 통과 보상도 알려줘서 그만큼 Money도 증가
 * 
 * 
 * 변수
 * int maxHP;
 * int curHP;
 * 
 */

public class Move_Bloon : BloonManager
{
    private Transform pathParent;

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
            base.moveSpeed * Time.fixedDeltaTime
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
        base.Die();
    }
}
