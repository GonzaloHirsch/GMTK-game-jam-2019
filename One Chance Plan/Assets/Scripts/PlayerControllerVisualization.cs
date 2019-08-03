using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVisualization : MonoBehaviour
{
    public float Velocity = 2f;
    public float ViewingDistance = 4f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();

        UpdateMovement();

        UpdateView();
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
        transform.position += direction.normalized * Time.deltaTime * Velocity;
    }

    private void UpdateView()
    {
        RaycastHit2D raycast = Physics2D.Raycast(ToVector2(transform.position), direction.normalized, ViewingDistance);

        HandleRaycast(raycast);

        Debug.DrawRay(ToVector2(transform.position), direction.normalized * ViewingDistance, Color.green, 10f);
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
        }
    }

    private Vector2 ToVector2(Vector3 vector)
    {
        return new Vector2()
        {
            x = vector.x,
            y = vector.y
        };
    }
}
