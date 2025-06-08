using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Treescript : MonoBehaviour, TimeAffected
{
    private BoxCollider2D treeCollider;
    private Animator animator;
    private TimeController timeController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        timeController.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Dobij trenutni SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if (spriteRenderer.sprite != null)
        {
            // Preuzmi granice (bounds) trenutnog sprite-a
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

            // Postavi velièinu BoxCollider-a u skladu sa trenutnom sprite slikom
            collider.size = spriteSize;

            // Podešavanje offset-a tako da donja ivica ostane fiksna
            collider.offset = new Vector2(0, spriteSize.y / 2);
        }
    }

    public void IntoThePast()
    {
        animator.SetTrigger("IntoPast");
    }

    public void IntoTheFuture()
    {
        animator.SetTrigger("IntoFuture");
    }
}
