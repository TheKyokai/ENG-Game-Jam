using UnityEngine;
using UnityEngine.UIElements;

public class Warp_2Script : MonoBehaviour, TimeAffected
{

    private Warp_1Script warp1;
    private PlayerMovement player;
    private bool powered = false;
    private bool active = false;
    private TimeController timeController;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warp1 = GameObject.FindGameObjectWithTag("Warp1").GetComponent<Warp_1Script>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        timeController.Subscribe(this);
    }

    public void Power()
    {
        powered = true;
    }

    public void Depower()
    {
        powered = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && powered)
        {
            player.transform.position = new Vector2(warp1.transform.position.x, warp1.transform.position.y);
            warp1.Depower();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (active)
        {
            Power();
        }
        
    }

    public void IntoThePast()
    {
        active = false;
        animator.SetBool("WarpActive", false);
    }

    public void IntoTheFuture()
    {
        active = true;
        animator.SetBool("WarpActive", true);
    }
}
