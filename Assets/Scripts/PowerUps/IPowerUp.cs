using UnityEngine;

public interface IPowerUp
{
    void Activate(GameObject gameObject);
    void Deactivate(GameObject gameObject);
}