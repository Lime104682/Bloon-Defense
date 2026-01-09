using System;
using UnityEngine;

public class BloonManager : MonoBehaviour
{
    public static event Action<BloonManager> OnBloonDead;

    protected int maxHP = 1;
    protected int curHP;
    [SerializeField]
    protected float moveSpeed = 0.1f;

    private void OnEnable()
    {
        curHP = maxHP;
    }

    public void Hit()
    {
        curHP--;

        if (curHP <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
        OnBloonDead?.Invoke(this);
    }
}
