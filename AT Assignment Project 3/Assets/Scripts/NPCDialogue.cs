using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    private bool canSpeak = false;
    [SerializeField] private GameObject objective;
    [SerializeField] private GameObject objectiveComplete;

    [Header("DialogueInfo")]
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private Texture avatar;
   /* public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public RawImage speakerImage;*/


    // Start is called before the first frame update
    void Start()
    {
        Dialogue.SetActive(false);
        objective.SetActive(false);
        objectiveComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {         
            Debug.Log("speaking to person");
            Dialogue.SetActive(true);

            if (CompareTag("Boss"))
            {
                objective.SetActive(true);
            }
        }
        if (AimBehaviourBasic.ObjectiveComplete)
        {
            objective.SetActive(false);
            objectiveComplete.SetActive(true);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = false;
            Dialogue.SetActive(false);
        }

    }
}
