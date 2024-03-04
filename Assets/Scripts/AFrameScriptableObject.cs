using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AFRameObject", order = 1)]
public class AFrameScriptableObject : ScriptableObject
{
    public string objectName;

    public string htmlStart, htmlEnd;
    public GameObject physicalObject;
}