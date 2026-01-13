using System;
using UnityEngine;

public enum BloonType
{
    Red = 1,
    Blue,
    Green,
    Yellow,
    Black,
    White
}

public class BloonManager : MonoBehaviour
{
    public static event Action<BloonManager> OnBloonDead;
    public static event Action<BloonManager> OnBloonHit;

    [SerializeField]
    protected int maxHP = 1;

    protected int curHP;
    public BloonType bloontype;
    [SerializeField]
    protected float moveSpeed = 0.1f;

    public void Init()
    {
        curHP = maxHP;
        bloontype = (BloonType)curHP;
    }

    public void Hit()
    {
        curHP--;
        OnBloonHit?.Invoke(this);

        if (curHP <= 0)
        {
            Die();
        }
        else 
        {
            ChangeBloonType();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
        OnBloonDead?.Invoke(this);
    }

    protected void ChangeBloonType()
    {
        //새 풍선 타입 확인
        BloonType newType = (BloonType)curHP;

        //기존 위치값 저장
        Vector3 pos = transform.position;

        //기존 경로 저장
        Move_Bloon move = GetComponent<Move_Bloon>();
        int nextIndex = move != null ? move.GetCurrentIndex() : 0;

        //어드레서블 키 값 예)RedBloon.prefab,YellowBloon.prefab...
        string key = $"{newType}Bloon.prefab";

        //다음 풍선 생성
        var nextBloon = Managers.Resource.Instantiate(key);

        //생성된 풍선의 BM에 정보 전달
        var newBM = nextBloon.GetComponent<BloonManager>();
        newBM.bloontype = newType;

        //생성된 풍선의 BM에 정보 전달
        var newMB = nextBloon.GetComponent<Move_Bloon>();
        if (newMB != null)
            newMB.SetSpawnState(pos, nextIndex);

        //Type만 변경이고 풍선은 살아있는 거니까 Destroy
        Destroy(gameObject);
    }


}
