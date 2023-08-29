using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType()== typeof(EventsOnlyInteractables))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message" , interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can only use unityEvents." , MessageType.Info );
            if (interactable.GetComponent<InteractionEvents>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
        }
        else
        {

        
            base.OnInspectorGUI();

            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvents>() == null)
                {
                    interactable.gameObject.AddComponent<InteractionEvents>();
                }
            
            }
            else
            {
                if (interactable.GetComponent<InteractionEvents>() != null)
                {
                    DestroyImmediate(interactable.GetComponent<InteractionEvents>());
                }
            }
        }
    }
}
