using Unity.VisualScripting;
using UnityEngine;

public class SliceFruit : Fruit
{
    [SerializeField] private GameObject _bottlePrefab;
    [SerializeField] private Color _color;
    [SerializeField] private int _index;
    public override void DeselectObject()
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

    public override void CheckCollider(Collider2D col)
    {
        if (col.CompareTag("Juicer"))
        {
            var obj = Instantiate(_bottlePrefab, transform.position, Quaternion.identity);
            obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
            obj.transform.GetComponent<Bottle>().SetIndex(_index);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
