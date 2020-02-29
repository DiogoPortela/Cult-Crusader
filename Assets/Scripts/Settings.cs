using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "Settings")]
public class Settings : ScriptableObject
{
    public static Settings Instance;
    public KeyCode playerUp = KeyCode.W;
    public KeyCode playerDown = KeyCode.S;
    public KeyCode playerLeft = KeyCode.A;
    public KeyCode playerRight = KeyCode.D;
    public KeyCode playerThrow = KeyCode.Space;

    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        Instance = Resources.LoadAll<Settings>("")[0];
    }
}
