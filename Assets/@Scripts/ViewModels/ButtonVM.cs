using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum TowerType
{
    Dart, Tack, Ice, Bomb, Super
}

[CreateAssetMenu(fileName = "ButtonVM", menuName = "Scriptable Objects/ButtonVM")]
public class ButtonVM : ScriptableObject
{
    ////NEW GAME 버튼 클릭 여부
    //[SerializeField]
    //private bool _isNewGameBT;
    ////Start Round 버튼 클릭 여부
    //[SerializeField]
    //private bool _isStartRoundBT;

    public static event Action OnNewGameButton;
    public static event Action OnstartRoundButton;

    public static event Action<TowerType> OnTowerButton;

    public void NewGameButton() => OnNewGameButton?.Invoke();
    public static void StartRoundButton() => OnstartRoundButton?.Invoke();

    public void TowerButton(TowerType type) => OnTowerButton?.Invoke(type);
}
