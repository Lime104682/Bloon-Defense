using UnityEngine;
using UnityEngine.UIElements;

public class SideUITK_MB : MonoBehaviour
{
    private Button start_button;

    private void Awake()
    {
        //초기화
        var root = GetComponent<UIDocument>().rootVisualElement;
        start_button = root.Q<Button>("Start-Button");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_button.clicked += () =>
        {
            Debug.Log("Super-Button이 클릭되었습니다.");
            SideUITK_VM.StartRoundButton();
        };
    }
}
