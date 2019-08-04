using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string description;

    public abstract void Apply();
}