using UnityEngine;

[System.Serializable]

//[CreateAssetMenu(menuName = "Dia")]
public class DialogueInfo : MonoBehaviour
{
    [Header("Speaker Details")]
    public Texture avatar;
    public string speakerName;
    [TextArea(10, 29)]
    public string[] sentences;
    public AudioClip[] clips;
    public GameObject speakerPrefab;
}
