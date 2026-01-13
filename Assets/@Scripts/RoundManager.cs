using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Data

public enum BloonGrade
{
    Red,
    Blue,
    Green,
    Yellow,
    Black,
    White
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
    

    [Header("Bloon Prefabs")]
    public List<BloonPrefabEntry> BloonPrefabs 
        = new List<BloonPrefabEntry>();

    [Header("Spawn Settings")]
    public Transform SpawnPoint;
    public float SpawnInterval = 0.1f;
    
    private Dictionary<int, Data.RoundData> _roundDic 
        = new Dictionary<int, Data.RoundData>();

    private Dictionary<BloonGrade, GameObject> _prefabDict 
        = new Dictionary<BloonGrade, GameObject>();

    private int _currentRoundIndex = 0;
    private int _aliveBloonCount;

    private bool _roundActive;
    private bool _isSpawning;
    private bool _isStartRoundBT;

    private Coroutine _spawnCoroutine;

    #region Unity LifeCycle

    private void OnEnable()
    {
        BloonManager.OnBloonDead += HandleBloonDead;
        ButtonVM.OnstartRoundButton += _startRoundAction;
    }

    private void OnDisable()
    {
        BloonManager.OnBloonDead -= HandleBloonDead;
        ButtonVM.OnstartRoundButton -= _startRoundAction;
    }

    private void Start()
    {
        _roundDic = Managers.Data.RoundDic;

        Debug.Log($"RoundDic Count = {_roundDic.Count}");

        foreach (var kv in _roundDic)
            Debug.Log($"Round Key = {kv.Key}");

        foreach (var entry in BloonPrefabs)
        {
            if (!_prefabDict.ContainsKey(entry.Grade))
                _prefabDict.Add(entry.Grade, entry.Prefab);
        }
    }

    private void Update()
    {
        if (!_roundActive && _isStartRoundBT)
        {
            StartRound();
        }
    }

    #endregion

    #region Round Control

    public void StartRound()
    {
        int nextRound = _currentRoundIndex + 1;

        if (!_roundDic.ContainsKey(nextRound))
        {
            Debug.Log("모든 라운드 종료");
            return;
        }

        Debug.Log($"Round {_currentRoundIndex + 1} 시작");

        _aliveBloonCount = 0;
        _roundActive = true;
        _isStartRoundBT = false;

        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(SpawnRoundCoroutine());
    }

    #endregion

    #region Spawn Logic

    private IEnumerator SpawnRoundCoroutine()
    {
        _isSpawning = true;

        int roundIndex = _currentRoundIndex + 1;
        var round = _roundDic[roundIndex];

        foreach (var wave in round.waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                SpawnBloon((BloonGrade)System.Enum.Parse(typeof(BloonGrade), wave.type));
                yield return new WaitForSeconds(SpawnInterval);
            }
        }

        _isSpawning = false;

        Debug.Log($"Round {_currentRoundIndex + 1} 스폰 완료");

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

    private void HandleBloonDead(BloonManager bloon)
    {
        _aliveBloonCount--;
        CheckRoundEnd();
    }

    private void _startRoundAction()
    {
        _isStartRoundBT = true;
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
