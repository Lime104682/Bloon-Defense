using UnityEngine;

[CreateAssetMenu(fileName = "SideUITK_VM", menuName = "Scriptable Objects/SideUITK_VM")]
public class SideUITK_VM : ScriptableObject
{
    //게임 시스템 속성값
    public int Round;
    public int Money;
    public int Lives;

    //타워 구매 가격
    public int Cost;

    //타워 공격 스피드(Slow, Medium, Fast, Hypersonic)
    public string Speed;

    //타워 스킬 1,2 가격값
    public int Skill01_Price;
    public int Skill02_Price;

    //타워 공격 범위 
    public int Range;

    //타워 판매 가격
    public int Sell;

    //Round 종료 후 보상 및 설명 풍선말
    public string Speech_Bubble;


    private void OnEnable()
    {
        BloonManager.OnBloonHit += HandleBloonHit;
    }

    private void OnDisable()
    {
        BloonManager.OnBloonHit -= HandleBloonHit;
    }

    //풍선 피격시 Money++
    private void HandleBloonHit(BloonManager bloon)
    {
        Money++;
    }
}
