using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControllerVisualization : PlayerController
{
    public static PlayerControllerVisualization Instance;
    public Camera topCamera;

    public float Velocity = 2f;
    public float ViewingDistance = 4f;
    public float offset = 1f;

    public LayerMask playerLayerMask;

    private const float EPSILON = 0.05f;

    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            UpdateDirection();

            UpdateMovement();

            UpdateView();

            RotateView();
        }
    }

    private void Update()
    {
        if (isActive)
        {
            UpdateDirection();
            
            CameraFollow();
        }
    }

    private void CameraFollow()
    {
        Vector3 movement = (Vector2)this.gameObject.transform.position - (Vector2)topCamera.transform.position;

        if (movement.magnitude > EPSILON)
        {
            topCamera.transform.position += movement.normalized * Time.deltaTime * Velocity;
        }
    }

    private void RotateView()
    {
        if (System.Math.Abs(direction.x - 1) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 270) - transform.rotation.eulerAngles);
        }
        else if (System.Math.Abs(direction.x - (-1)) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 90) - transform.rotation.eulerAngles);
        }
        else if (System.Math.Abs(direction.y - 1) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 360) - transform.rotation.eulerAngles);
        }
        else if (System.Math.Abs(direction.y - (-1)) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 180) - transform.rotation.eulerAngles);
        }
    }

    public override void Activate()
    {
        isActive = true;
        topCamera.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        isActive = false;
        topCamera.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void UpdateDirection()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private void UpdateMovement()
    {
        player.transform.position += direction.normalized * Time.fixedDeltaTime * Velocity;
    }

    private void UpdateView()
    {
        Vector2 v2 = (Vector2)player.transform.position + ((Vector2)direction.normalized * offset);

        //RaycastHit2D raycast = Physics2D.Raycast(v2, direction.normalized, ViewingDistance, playerLayerMask);
        RaycastHit2D raycastU = Physics2D.Raycast(v2, Vector3.up, ViewingDistance, playerLayerMask);
        RaycastHit2D raycastD = Physics2D.Raycast(v2, Vector3.down, ViewingDistance, playerLayerMask);
        RaycastHit2D raycastL = Physics2D.Raycast(v2, Vector3.left, ViewingDistance, playerLayerMask);
        RaycastHit2D raycastR = Physics2D.Raycast(v2, Vector3.right, ViewingDistance, playerLayerMask);
        RaycastHit2D raycastUL = Physics2D.Raycast(v2, new Vector3(-1, 1, 0), ViewingDistance, playerLayerMask);
        RaycastHit2D raycastUR = Physics2D.Raycast(v2, new Vector3(1, 1, 0), ViewingDistance, playerLayerMask);
        RaycastHit2D raycastDL = Physics2D.Raycast(v2, new Vector3(-1, -1, 0), ViewingDistance, playerLayerMask);
        RaycastHit2D raycastDR = Physics2D.Raycast(v2, new Vector3(1, -1, 0), ViewingDistance, playerLayerMask);

        //HandleRaycast(raycast);
        HandleRaycast(raycastL);
        HandleRaycast(raycastR);
        HandleRaycast(raycastD);
        HandleRaycast(raycastU);
        HandleRaycast(raycastUL);
        HandleRaycast(raycastUR);
        HandleRaycast(raycastDL);
        HandleRaycast(raycastDR);

        //Debug.Log(Quaternion.Euler(0, 0, 55) * direction.normalized);
        //Debug.Log(Quaternion.Euler(0, 0, -55) * direction.normalized);

        //Debug.DrawRay(v2, direction.normalized, Color.red, 1f);
        //Debug.DrawRay(v2, (Quaternion.Euler(0, 0, 30) * direction.normalized).normalized * ViewingDistance, Color.red, 1f);
        //Debug.DrawRay(v2, (Quaternion.Euler(0, 0, -30) * direction.normalized).normalized * ViewingDistance, Color.red, 1f);
        //Debug.DrawRay(v2, (Quaternion.Euler(0, 0, 60) * direction.normalized).normalized * ViewingDistance, Color.red, 1f);
        //Debug.DrawRay(v2, (Quaternion.Euler(0, 0, -60) * direction.normalized).normalized * ViewingDistance, Color.red, 1f);
    }

    /// <summary>
    /// Handles the raycast when the player is moving between the fog.
    /// In case the ray hits a gameobject tagged with "Fog", it's destroyed.
    /// </summary>
    /// <param name="raycastHit">Raycast hit.</param>
    private void HandleRaycast(RaycastHit2D raycastHit)
    {
        //Debug.Log("RAY");
        if (raycastHit.collider != null && raycastHit.collider.gameObject.tag.Equals("Fog"))
        {
            //Debug.Log("HIT");
            Tilemap map = raycastHit.collider.gameObject.GetComponent<Tilemap>();
            if (map != null)
            {
                //Debug.Log("CHANGE");
                map.SetTile(map.WorldToCell(raycastHit.point), null);
                //collider2D.
            }
        } else if (raycastHit.collider != null && raycastHit.collider.gameObject.tag.Equals("Interactable"))
        {
            if (Input.GetKeyDown(KeyCode.E)){
                raycastHit.collider.gameObject.GetComponent<Interactable>().Interact();
            }
        }
        //else
        //{
        //    Debug.Log("SELF");
        //}
    }
}
