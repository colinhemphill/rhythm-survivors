using UnityEngine;

public class BoundsUtils
{
    public Bounds GetMaxBounds(GameObject gameObject)
    {
        var b = new Bounds(gameObject.transform.position, Vector3.zero);
        foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }
}
