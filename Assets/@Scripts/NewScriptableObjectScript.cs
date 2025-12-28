using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class NewScriptableObjectScript : ScriptableObject
{
    public enum FantasyClass
    {
        Knight,
        Wizard,
        Thief
    };

    public FantasyClass myClass;
    public int Level;
    public float Exp;
    public string Name;
}
