using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Managers.Resource.LoadAllAsync<Object>("AllLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                Debug.Log("Addressables 로드 완료");
                Managers.Data.Init();
                StartLoad();
            }
        });
    }

    private void StartLoad()
    {
        //말풍선 json 확인용
        foreach (var rewardData in Managers.Data.RoundRewardDic.Values)
        {
            Debug.Log($"라운드 : {rewardData.round}, 말풍선 : {rewardData.message}");
        }

        //RoundManager 생성
        var roundManager = Managers.Resource.Instantiate("RoundManager.prefab");
        var RM = roundManager.GetComponent<RoundManager>();

        var path = GameObject.Find("Path");

        RM.SpawnPoint = path.transform.GetChild(0);

        //UI 생성
        var pop_UITK = Managers.Resource.Instantiate("POP_UIDocument.prefab");
        var side_UITK = Managers.Resource.Instantiate("Side_UIDocument.prefab");
    }
}
