using System.Collections.Generic;
using UnityEngine;

/*TODO
 * 데이터 초기화 하고 관리하는 곳
 * 
 * 각 데이터는 필요한 곳에 알려줌
 */
public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Data.RoundData> RoundDic { get; private set; } 
        = new Dictionary<int, Data.RoundData>();
    public Dictionary<int, Data.RoundRewardsData> RoundRewardDic { get; private set; }
        = new Dictionary<int, Data.RoundRewardsData>();

    public void Init()
    {
        RoundDic = LoadJson<Data.RoundDataLoader, int, Data.RoundData>("RoundData.json").MakeDict();
        RoundRewardDic = LoadJson<Data.RoundRewardsDataLoader, int, Data.RoundRewardsData>("RoundRewards.json").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
