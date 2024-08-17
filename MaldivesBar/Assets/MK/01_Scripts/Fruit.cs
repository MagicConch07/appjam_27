using UnityEngine;

public class Fruit : MonoBehaviour, IBarObject
{
    [SerializeField] private FruitSO _fruit;
    [SerializeField] protected LayerMask _layer;

    public virtual void DeselectObject()
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

    public virtual void CheckCollider(Collider2D col)
    {
        if (col.CompareTag("Knife"))
        {
            if (_fruit.sliceObj == null) return;

            Instantiate(_fruit.sliceObj, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
