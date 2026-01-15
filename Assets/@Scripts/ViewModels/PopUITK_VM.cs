using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUITK_VM", menuName = "Scriptable Objects/PopUITK_VM")]
public class PopUITK_VM : ScriptableObject
{
    public static event Action OnNewGameButton;

    public void NewGameButton() => OnNewGameButton?.Invoke();
}
