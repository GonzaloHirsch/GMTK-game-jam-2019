using UnityEngine;

public class CameraControllerVisualization : ObjectWithFOV
{
    public float maxAngleOpening = 60f;
    public float velocity = 3f;
    public bool isActive = true;

    private int direction = 1;
    private float totalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        DrawMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            UpdateRotation();
        }
    }

    private void UpdateRotation()
    {
        float step = velocity * Time.deltaTime;

        if (direction == 1)
        {
            transform.Rotate(new Vector3(0, 0, step));
            totalRotation += step;
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -step));
            totalRotation -= step;
        }

        if (Mathf.Abs(totalRotation) > maxAngleOpening / 2)
        {
            direction = direction * -1;
        }
    }
}
