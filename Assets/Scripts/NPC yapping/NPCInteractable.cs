using UnityEngine;
using Yarn.Unity;

public class NPCInteractable : MonoBehaviour
{
    public string startNode = "Start";  // The Yarn node name
    public DialogueRunner dialogueRunner;
    public GameObject ChamThan;

    public void Interact()
    {
        if (dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner is NOT assigned on " + gameObject.name);
            return;
        }
        else
        {
            if (!dialogueRunner.IsDialogueRunning)
            {
                dialogueRunner.StartDialogue(startNode);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChamThan.SetActive(true);
            var movement = other.GetComponent<PlayerMovement>();
            movement.currentNPC = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChamThan.SetActive(false);
            var movement = other.GetComponent<PlayerMovement>();
            movement.currentNPC = null;
        }
    }

}
