using UnityEngine;

public class PortalGateScript : MonoBehaviour
{

    public SpriteRenderer portalSpriteRend;
    public Sprite PoweredPortal;

    public BoxCollider2D gateCollider;
    private bool powered = false;


    private AudioManager audioManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerGate()
    {
        powered = true;
        portalSpriteRend.sprite = PoweredPortal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (powered)
        {
            audioManager.PlaySound("NextLevel");
            SceneController.instance.NextLevel();
        }
    }
}
