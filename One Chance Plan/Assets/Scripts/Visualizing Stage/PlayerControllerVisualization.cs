using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVisualization : PlayerController
{
    public GameObject player;

    public float Velocity = 2f;
    public float ViewingDistance = 4f;
    public bool isActive = true;
    public float awareness = 0f;
    public float offset = 1f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            UpdateDirection();

            UpdateMovement();

            UpdateView();
        }

        Debug.Log(awareness);
    }

    private void InitVariables()
    {
        this.direction = new Vector3
        {
            z = 0f
        };
    }

    private void UpdateDirection()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private void UpdateMovement()
    {
        player.transform.position += direction.normalized * Time.deltaTime * Velocity;
    }

    private void UpdateView()
    {
        Vector2 v2 = (Vector2)player.transform.position + ((Vector2)direction.normalized * offset);
        RaycastHit2D raycast = Physics2D.Raycast(v2, direction.normalized, ViewingDistance);

        HandleRaycast(raycast);
        
        Debug.DrawRay(v2, direction.normalized, Color.red, 1f);
    }

    /// <summary>
    /// Handles the raycast when the player is moving between the fog.
    /// In case the ray hits a gameobject tagged with "Fog", it's destroyed.
    /// </summary>
    /// <param name="raycastHit">Raycast hit.</param>
    private void HandleRaycast(RaycastHit2D raycastHit)
    {
        if (raycastHit.collider != null && raycastHit.collider.gameObject.tag.Equals("Fog"))
        {
            Destroy(raycastHit.collider.gameObject);
        } else if (raycastHit.collider != null && raycastHit.collider.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("INTE");
            if (Input.GetKeyDown(KeyCode.E)){
                raycastHit.collider.gameObject.GetComponent<Interactable>().Interact();
                Debug.Log("HIT");
            }
        }
    }

    public void RaiseAwareness(float increment)
    {
        awareness += increment;
    }
}
