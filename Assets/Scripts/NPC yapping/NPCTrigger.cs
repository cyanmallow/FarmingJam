using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Yarn.Unity;

public class NPCTrigger : MonoBehaviour
{
    public GameObject floatingText;
    public DialogueRunner dialogueRunner;
    public string startNode = "Auto";  // The Yarn node name


    private void Awake()
    {
        dialogueRunner.StartDialogue(startNode);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floatingText.SetActive(true);
            dialogueRunner.StartDialogue(startNode);
            Debug.Log("Canvas for evasdropping should now be showing");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floatingText.SetActive(false);
            Debug.Log("Canvas for evasdropping should now be disappearing");
        }
    }
}
