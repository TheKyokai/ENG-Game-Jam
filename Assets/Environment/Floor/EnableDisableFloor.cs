using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableFloor : StateMachineBehaviour
{
    private BoxCollider2D floorCollider;
    private Renderer objectRenderer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Preuzimamo Collider i Renderer samo jednom
        if (floorCollider == null)
        {
            floorCollider = animator.GetComponent<BoxCollider2D>();
        }

        if (objectRenderer == null)
        {
            objectRenderer = animator.GetComponent<Renderer>();
        }

        // Deaktiviramo collider i vidljivost objekta kada uðemo u stanje
        if (floorCollider != null)
        {
            floorCollider.enabled = false;
        }

        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Aktiviramo collider i vidljivost objekta kada izaðemo iz stanja
        if (floorCollider != null)
        {
            floorCollider.enabled = true;
        }

        if (objectRenderer != null)
        {
            objectRenderer.enabled = true;
        }
    }
}