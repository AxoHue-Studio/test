using UnityEngine;

[CreateAssetMenu(fileName ="NewObjectDialogue", menuName ="Object Dialogue")]
public class ObjectDialogue : ScriptableObject
{
    public string objectName;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
}
