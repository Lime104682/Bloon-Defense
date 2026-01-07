using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/*TODO
 * 공격 범위 안에 타겟이 감지되었다면
 * 투사체 직진 발사
 * 풍선에 충돌한 투사체 소멸
 * 투사체 공격범위 밖으로 나가면 삭제
 * 
 * 공격 범위 증가 스킬 구매 되었다면 
 * 타워 확인 후 타워에 맞게 Range값 변경
 * 변경된 Rnage 값의 크기만큼 공격 범위 증가
 * 
 * 마우스 포인터가 Tower를 클릭했는지 감지
 * (감지 했다면 VM에 알려주기)
 * 
 * 팔기 버튼 클릭되었다면 모든 변수 초기화, Tower Pool 반환 
 */

public class TowersBase : MonoBehaviour
{
    #region Tower Base Stats
    [Header("Base Stats")]
    public int Cost;
    public float atk_Speed;
    public string Speed_name;
    public int Range;
    #endregion

    [Header("Attack")]
    public Transform FireSocket;

    //현재 타겟 풍선
    private Transform _curTargetBloon;
    private List<Move_Bloon> Bloons = new List<Move_Bloon>();
    protected float angle;

    private Coroutine _CoAtk;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _CoAtk = StartCoroutine(CoStartAtk());
    }

    #region Attack

    private IEnumerator CoStartAtk()
    {
        WaitForSeconds wait = new WaitForSeconds(atk_Speed);

        while (true)
        {
            if (_curTargetBloon != null)
                Attack(_curTargetBloon);

            yield return wait;
        }
    }

    protected virtual void Attack(Transform target)
    {

    }

    #endregion

    #region Targeting

    private void RotateTowersTarget(Vector3 targetPos)
    {
        Vector2 dir = targetPos - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void SelectNextTarget()
    {
        //내 식대로 다듬기

        // 파괴되었거나 비활성화된 Bloon 정리
        Bloons.RemoveAll(b => b == null || !b.gameObject.activeInHierarchy);

        _curTargetBloon = Bloons.Count > 0 ? Bloons[0].transform : null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Move_Bloon>(out var bloon))
            return;

        if (Bloons.Contains(bloon))
            return;

        Bloons.Add(bloon);

        // 첫 타겟이 없으면 바로 지정
        if (_curTargetBloon == null)
            _curTargetBloon = bloon.transform;

        //타겟 감지하자마자 선빵
        //if (_curTargetBloon != null)
        //{
        //    Attack(_curTargetBloon);
        //}
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_curTargetBloon == null)
            return;

        RotateTowersTarget(_curTargetBloon.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Move_Bloon>(out var bloon))
            return;

        if (Bloons.Remove(bloon))
        {
            // 나간 대상이 현재 타겟이면 다음으로 교체
            if (_curTargetBloon == bloon.transform)
                SelectNextTarget();
        }
    }

    #endregion
}
