using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;

    public Interactable focus;

    public LayerMask movementMask;

    PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                
                //Debug.Log("we hit " + hit.collider.name + "" + hit.point);
                playerMovement.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if hit object is interactable 
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
                
            }
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
            focus.OnDeFocused();
            }

            focus = newFocus;
            playerMovement.FollowTarget(newFocus);
        }
        
      
        newFocus.OnFocused(transform);


    }
    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDeFocused();
        }

        
        focus = null;
        playerMovement.StopFollowingTarget();
    }
}
