using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class gunScript : MonoBehaviour
{
    public float maxDist;
    public float damage;

    InputAction shoot;

    private void Start()
    {
        shoot = InputSystem.actions.FindAction("Shoot");
    }

    private void Update()
    { 
        if (shoot.IsPressed())
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin,ray.direction);
        }
    }

}
