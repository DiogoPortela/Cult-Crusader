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
    public KeyCode weapon1 = KeyCode.Alpha1;
    public KeyCode weapon2 = KeyCode.Alpha2;
    public KeyCode weapon3 = KeyCode.Alpha3;
    public KeyCode weapon4 = KeyCode.Alpha4;
    public KeyCode weapon5 = KeyCode.Alpha5;
    [RuntimeInitializeOnLoadMethod]
    private static void Init()
    {
        Instance = Resources.LoadAll<Settings>("")[0];
    }
}
