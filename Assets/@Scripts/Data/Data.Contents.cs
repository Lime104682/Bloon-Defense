using System;
using System.Collections.Generic;
using UnityEditor.AdaptivePerformance.Editor.Metadata;
using UnityEngine;

/*TODO
 * JSON 데이터 파싱하는 곳
 */

namespace Data
{
    #region RoundData
    [Serializable]
    public class RoundData
    {
        //라운드
        public int round;
        //각 풍선 웨이브
        public List<WaveData> waves;
    }

    [Serializable]
    public class WaveData
    {
        //타입
        public string type; 
        //갯수
        public int count;
    }

    [Serializable]
    public class RoundDataLoader : ILoader<int, RoundData>
    {
        public List<RoundData> rounds = new List<RoundData>();

        public Dictionary<int, RoundData> MakeDict()
        {
            Dictionary<int, RoundData> dict = new Dictionary<int, RoundData>();
            foreach (var Rounds in rounds)
                dict.Add(Rounds.round, Rounds);
            return dict;
        }
    }
    #endregion

    #region RoundRewardsData
    [Serializable]
    public class RoundRewardsData
    {
        //라운드
        public int round;
        //각 풍선 웨이브
        public string message;
    }

    [Serializable]
    public class RoundRewardsDataLoader : ILoader<int, RoundRewardsData>
    {
        public List<RoundRewardsData> roundRewards = new List<RoundRewardsData>();

        public Dictionary<int, RoundRewardsData> MakeDict()
        {
            Dictionary<int, RoundRewardsData> dict = new Dictionary<int, RoundRewardsData>();
            foreach (var RoundReward in roundRewards)
                dict.Add(RoundReward.round, RoundReward);
            return dict;
        }
    }
    #endregion

    #region BloonData
    public class BloonData
    {

    }
    #endregion

    #region TowersData
    public class TowersData
    {

    }
    #endregion

}
