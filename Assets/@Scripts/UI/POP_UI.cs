using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Analytics.IAnalytic;
using static UnityEngine.Rendering.DebugUI.MessageBox;


//POP_UIDocument.prefab 스크립트
public class POP_UI : MonoBehaviour
{
    private VisualElement _startVE;
    private VisualElement _clearVE;
    private VisualElement _overVE;

    private Button _newgameBT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _startVE = root.Q<VisualElement>("Start_UI");
        _clearVE = root.Q<VisualElement>("Clear_UI");
        _overVE = root.Q<VisualElement>("Over_UI");

        _newgameBT = root.Q<Button>("NEW_GAME-Button");

        _newgameBT.RegisterCallback<ClickEvent>(CloseButtonClicked);
    }

    private void CloseButtonClicked(ClickEvent evt)
    {
        //evt가 호출된 콜백이 등록된 요소, 추후 재사용성으로 고민 ㄱㄱ
        var target = evt.currentTarget;
        Debug.Log($"Target : {target}");

        //_startVE 비활성화 하고 부모도 비활성화,
        //나중에 _clearVE,_overVE 활성화 할 때 부모도 같이 활성화 해야 됨
        _startVE.style.display = DisplayStyle.None;
        _startVE.parent.style.display = DisplayStyle.None;

        //NEW GAME 버튼 클릭 감지
    }
}
