using UnityEngine;

public class PortalKeyScript : MonoBehaviour
{
    public CapsuleCollider2D keyCollider;
    private PortalGateScript gate;
    private AudioManager audioManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gate = GameObject.FindGameObjectWithTag("PortalGate").GetComponent<PortalGateScript>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.PlaySound("PowerPortal");
        gate.PowerGate();
        Destroy(gameObject);
    }

}
