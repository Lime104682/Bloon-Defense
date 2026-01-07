using Data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

#region Data

public enum BloonGrade
{
    Red,
    Blue,
    Green,
    Yellow,
    Pink,
    Black
}

[System.Serializable]
public class BloonSpawnData
{
    public BloonGrade Grade;
    public int Count;
}

[System.Serializable]
public class RoundData
{
    public int Round;
    public List<BloonSpawnData> Bloons;
}

[System.Serializable]
public class BloonPrefabEntry
{
    public BloonGrade Grade;
    public GameObject Prefab;
}

#endregion

public class RoundManager : MonoBehaviour
{
    [Header("Round Data")]
    public List<RoundData> Rounds;

    [Header("Bloon Prefabs")]
    public List<BloonPrefabEntry> BloonPrefabs;

    [Header("Spawn Settings")]
    public Transform SpawnPoint;
    public float SpawnInterval = 0.1f;

    private Dictionary<BloonGrade, GameObject> _prefabDict;

    private int _currentRoundIndex = 0;
    private int _aliveBloonCount;

    private Coroutine _spawnCoroutine;

    private bool _roundActive;
    private bool _isSpawning;

    #region Unity LifeCycle

    private void OnEnable()
    {
        Move_Bloon.OnBloonDead += HandleBloonDead;
    }

    private void OnDisable()
    {
        Move_Bloon.OnBloonDead -= HandleBloonDead;
    }

    private void Awake()
    {
        _prefabDict = new Dictionary<BloonGrade, GameObject>();

        foreach (var entry in BloonPrefabs)
        {
            if (!_prefabDict.ContainsKey(entry.Grade))
                _prefabDict.Add(entry.Grade, entry.Prefab);
        }
    }

    private void Update()
    {
        /*옛날거라 6에선 사용 못함
        if (!_roundActive && Input.GetKeyDown(KeyCode.Space))
        {
           StartRound();
        }
        */

        if (!_roundActive && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartRound();
        }
    }

    #endregion

    #region Round Control

    public void StartRound()
    {
        if (_currentRoundIndex >= Rounds.Count)
        {
            Debug.Log("모든 라운드 종료");
            return;
        }

        Debug.Log($"Round {_currentRoundIndex + 1} 시작");

        _aliveBloonCount = 0;
        _roundActive = true;

        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(SpawnRoundCoroutine());
    }

    #endregion

    #region Spawn Logic

    private IEnumerator SpawnRoundCoroutine()
    {
        _isSpawning = true;

        RoundData round = Rounds[_currentRoundIndex];

        foreach (var spawnData in round.Bloons)
        {
            for (int i = 0; i < spawnData.Count; i++)
            {
                SpawnBloon(spawnData.Grade);
                yield return new WaitForSeconds(SpawnInterval);
            }
        }

        _isSpawning = false;

        Debug.Log($"Round {round.Round} 스폰 완료");

        CheckRoundEnd();
    }

    private void SpawnBloon(BloonGrade grade)
    {
        if (!_prefabDict.TryGetValue(grade, out var prefab))
        {
            Debug.LogError($"Bloon Prefab 없음 : {grade}");
            return;
        }

        Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
        _aliveBloonCount++;
    }

    private void HandleBloonDead(Move_Bloon bloon)
    {
        _aliveBloonCount--;
        CheckRoundEnd();
    }

    private void CheckRoundEnd()
    {
        if (!_isSpawning && _aliveBloonCount <= 0)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        Debug.Log($"Round {_currentRoundIndex + 1} 종료");

        _roundActive = false;
        _currentRoundIndex++;
    }

    #endregion
}
