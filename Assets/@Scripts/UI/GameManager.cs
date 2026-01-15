using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

#region UIKit 접근자들
/*
 * UI Document 컴포넌트 가져와서 할당
 *  var root = GetComponent<UIDocument>().rootVisualElement;
 * 
 * --------------------------------------------------------------------------------------
 * 
 * 버튼
 * 특정 버튼의 클릭 감지
 * // Q는 Query...을 축약한거. 자세한건 구글 검색 ㄱㄱ
 *  root.Q<Button>("Dart-Button").clicked += () => {실행코드}
 * 
 * 마우스 포인터가 특정 UI위에 올라왔는지 감지
 *  root.Q<Button>("Dart-Button").RegisterCallback<PointerEnterEvent>(_ => {실행코드});
 *  
 * 마우스 포인터가 특정 UI위에서 벗어났는지 감지
 *  root.Q<Button>("Dart-Button").RegisterCallback<PointerLeaveEvent>(_ => {실행코드});
 * 
 * --------------------------------------------------------------------------------------
 * 
 * 이미지
 * 특정 이미지를 할당
 *  image = root.Q<Image>("Tower-Manu");
 * 
 * 이미지의 Inlined Styles의 Display의 Display 값 접근
 *  image.style.display = DisplayStyle.Flex; //가시화
 *  image.style.display = DisplayStyle.None; //비가시화
 *  
 * --------------------------------------------------------------------------------------
 * 
 * 
*/
#endregion

// Side_UIDocument 스크립트
public class GameManager : MonoBehaviour
{
    private bool DartButton_ishover = false;

    private Image towerManu_image;
    private Image towerUpgrade_image;
    private Button start_button;
    private Button dart_button;
    private Button tack_button;
    private Button ice_button;
    private Button bomb_button;
    private Button super_button;


    public Texture2D Dart_Tower_texture;
    public Texture2D Task_Tower_texture;
    public Texture2D Ice_Tower_texture;
    public Texture2D Bomb_Tower_texture;
    public Texture2D Super_Tower_texture;

    private void Awake()
    {
        //초기화
        var root = GetComponent<UIDocument>().rootVisualElement;
        towerManu_image = root.Q<Image>("Tower-Manu");
        towerUpgrade_image = root.Q<Image>("Tower-Manu");
        start_button = root.Q<Button>("Start-Button");
        dart_button = root.Q<Button>("Dart-Button");
        tack_button = root.Q<Button>("Tack-Button");
        ice_button = root.Q<Button>("Ice-Button");
        bomb_button = root.Q<Button>("Bomb-Button");
        super_button = root.Q<Button>("Super-Button");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region Dart
        dart_button.clicked += () =>
        {
            Debug.Log("Dart-Button이 클릭되었습니다.");
        };

        dart_button.RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Dart 타워 버튼 위에 마스가 올라갔습니다.");
            towerManu_image.image = Dart_Tower_texture;
        });

        dart_button.RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            towerManu_image.image = null;
        });
        #endregion
        #region Tack
        tack_button.clicked += () =>
        {
            Debug.Log("Tack-Button이 클릭되었습니다.");
        };

        tack_button.RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Tack 타워 버튼 위에 마스가 올라갔습니다.");
            towerManu_image.image = Task_Tower_texture;
        });

        tack_button.RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            towerManu_image.image = null; 
        });
        #endregion
        #region Ice
        ice_button.clicked += () =>
        {
            Debug.Log("Ice-Button이 클릭되었습니다.");
        };

        ice_button.RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Ice 타워 버튼 위에 마스가 올라갔습니다.");
            towerManu_image.image = Ice_Tower_texture;
        });

        ice_button.RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            towerManu_image.image = null;
        });
        #endregion
        #region Bomb
        bomb_button.clicked += () =>
        {
            Debug.Log("Bomb-Button이 클릭되었습니다.");
        };

        bomb_button.RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Bomb 타워 버튼 위에 마스가 올라갔습니다.");
            towerManu_image.image = Bomb_Tower_texture;
        });

        bomb_button.RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            towerManu_image.image = null;
        });
        #endregion
        #region Super
        super_button.clicked += () =>
        {
            Debug.Log("Super-Button이 클릭되었습니다.");
        };

        super_button.RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Super 타워 버튼 위에 마스가 올라갔습니다.");
            towerManu_image.image = Super_Tower_texture;
        });

        super_button.RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            towerManu_image.image = null;
        });
        #endregion

        start_button.clicked += () =>
        {
            Debug.Log("Super-Button이 클릭되었습니다.");
            SideUITK_VM.StartRoundButton();
            start_button.style.display = DisplayStyle.None;
        };
    }

}
