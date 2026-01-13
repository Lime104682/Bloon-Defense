using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Managers : MonoBehaviour
{
    //매니저 생성 및 유무확인
    static Managers s_instance;
    static bool s_init = false;

    //각 스크립트 생성
    ResourceManager _resource = new ResourceManager();
    DataManager _data = new DataManager();

    //각 스크립트 접근, 매니저가 생성되었다면 생성된 스크립트 반환
    //매니저가 초기화 되기 전에 접근하는 것을 방지
    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static DataManager Data { get { return Instance?._data; } }

    //매니저 싱글톤 생성 혹은 반환 
    public static Managers Instance
    {
        get
        {
            if (s_init == false)
            {
                GameObject go = GameObject.Find("Managers");
                if (go == null)
                {
                    go = new GameObject() { name = "Managers" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();

                s_init = true;
            }

            return s_instance;
        }

    }

}
