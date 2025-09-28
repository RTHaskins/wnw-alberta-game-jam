using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour
{
    PlayerInput playerinput;
    InputAction leapAction;
    Animator animator;
    
    private bool playerEntered = false;
    private bool destroyed = false;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //playerinput = GameObject.FindAnyObjectByType<PlayerInput>();
        leapAction = InputSystem.actions.FindAction("Boom");
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (playerEntered)
        {
            if (leapAction.WasPressedThisFrame())
            {
                animator.SetTrigger("Boom");
                destroyed = true;
            }
        }
        if (destroyed)
        {
            timer = timer + Time.deltaTime;
            if (timer > 2f)
            {
                Destroy(gameObject);
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
    }
    

    // Update is called once per frame
    
}
