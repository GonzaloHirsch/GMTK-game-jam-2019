using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string description;

    public Sprite sprite;

    public abstract void Apply();
}