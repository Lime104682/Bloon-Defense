using UnityEngine;

/*
 * 투사체에게 붙일 스크립트
 */

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 8f;

    private Vector3 direction;
    private Vector3 startPos;

    public void Init(Vector3 targetPos)
    {
        startPos = transform.position;
        direction = (targetPos - startPos).normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        // 공격 범위 밖으로 나가면 삭제
        if (Vector3.Distance(startPos, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}