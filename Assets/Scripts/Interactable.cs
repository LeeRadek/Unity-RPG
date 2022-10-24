using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;


    bool isFocued = false;
    Transform player;
    public Transform interactionTransform;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isFocued && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocued=true;
        player = playerTransform;
        hasInteracted = false;
    }


    public void OnDeFocused()
    {
        isFocued=false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmos()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
