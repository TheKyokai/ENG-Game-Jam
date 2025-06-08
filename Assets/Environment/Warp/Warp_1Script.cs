using UnityEngine;

public class Warp_1Script : MonoBehaviour, TimeAffected
{

    private Warp_2Script warp2;
    private PlayerMovement player;
    private bool powered = true;
    private bool active = false;
    private TimeController timeController;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warp2 = GameObject.FindGameObjectWithTag("Warp2").GetComponent<Warp_2Script>();
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
            player.transform.position = new Vector2(warp2.transform.position.x, warp2.transform.position.y);
            warp2.Depower();
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
