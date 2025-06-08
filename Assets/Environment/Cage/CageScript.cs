using UnityEngine;

public class CageScript : MonoBehaviour, TimeAffected
{
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
