using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

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

public class GameManager : MonoBehaviour
{
    public bool DartButton_ishover = false;
    
    private Image image;
    public Texture2D Dart_Tower_texture;
    public Texture2D Task_Tower_texture;
    public Texture2D Ice_Tower_texture;
    public Texture2D Bomb_Tower_texture;
    public Texture2D Super_Tower_texture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        image = root.Q<Image>("Tower-Manu");

        #region Dart
        root.Q<Button>("Dart-Button").clicked += () =>
        {
            Debug.Log("Dart-Button이 클릭되었습니다.");
        };

        root.Q<Button>("Dart-Button").RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Dart 타워 버튼 위에 마스가 올라갔습니다.");
            image.image = Dart_Tower_texture;
        });

        root.Q<Button>("Dart-Button").RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            image.image = null;
        });
        #endregion
        #region Tack
        root.Q<Button>("Tack-Button").clicked += () =>
        {
            Debug.Log("Tack-Button이 클릭되었습니다.");
        };

        root.Q<Button>("Tack-Button").RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Tack 타워 버튼 위에 마스가 올라갔습니다.");
            image.image = Task_Tower_texture;
        });

        root.Q<Button>("Tack-Button").RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            image.image = null; 
        });
        #endregion
        #region Ice
        root.Q<Button>("Ice-Button").clicked += () =>
        {
            Debug.Log("Ice-Button이 클릭되었습니다.");
        };

        root.Q<Button>("Ice-Button").RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Ice 타워 버튼 위에 마스가 올라갔습니다.");
            image.image = Ice_Tower_texture;
        });

        root.Q<Button>("Ice-Button").RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            image.image = null;
        });
        #endregion
        #region Bomb
        root.Q<Button>("Bomb-Button").clicked += () =>
        {
            Debug.Log("Bomb-Button이 클릭되었습니다.");
        };

        root.Q<Button>("Bomb-Button").RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Bomb 타워 버튼 위에 마스가 올라갔습니다.");
            image.image = Bomb_Tower_texture;
        });

        root.Q<Button>("Bomb-Button").RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            image.image = null;
        });
        #endregion
        #region Super
        root.Q<Button>("Super-Button").clicked += () =>
        {
            Debug.Log("Super-Button이 클릭되었습니다.");
        };

        root.Q<Button>("Super-Button").RegisterCallback<PointerEnterEvent>(_ =>
        {
            DartButton_ishover = true;
            Debug.Log("Super 타워 버튼 위에 마스가 올라갔습니다.");
            image.image = Super_Tower_texture;
        });

        root.Q<Button>("Super-Button").RegisterCallback<PointerLeaveEvent>(_ =>
        {
            DartButton_ishover = false;
            image.image = null;
        });
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
    }


}
