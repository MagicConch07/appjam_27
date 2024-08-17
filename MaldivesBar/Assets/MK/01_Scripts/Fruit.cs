using UnityEngine;

public class Fruit : MonoBehaviour, IBarObject
{
    [SerializeField] private FruitSO _fruit;
    [SerializeField] private LayerMask _layer;

    public void DeselectObject()
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];

        int hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.forward, hits, Mathf.Infinity, _layer);

        if (hit >= 1)
        {
            CheckCollider(hits[0].collider);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    public void CheckCollider(Collider2D col)
    {
        if (col.CompareTag("Knife"))
        {
            Debug.Log("절단");
        }
        else if (col.CompareTag("Juicer"))
        {
            Debug.Log("착즙");
        }
    }
}
