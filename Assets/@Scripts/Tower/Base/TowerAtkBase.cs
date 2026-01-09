using UnityEngine;

public class TowerAtkBase : MonoBehaviour
{
    protected Transform _target;
    public float Speed = 10f;

    public virtual void Init(Transform target)
    {
        _target = target;
    }

    protected virtual void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.position,
            Speed * Time.deltaTime
        );
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Move_Bloon bloon)) return;

        bloon.Hit();          
        Destroy(gameObject);  
    }
}