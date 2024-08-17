using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcohol : MonoBehaviour, IBarObject
{
    [SerializeField] private Transform _origin;
    [SerializeField] private LayerMask _layer;

    [SerializeField] private Color _color;

    public void DeselectObject()
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];

        int hit = Physics2D.RaycastNonAlloc(transform.position, Vector3.forward, hits, Mathf.Infinity, _layer);

        if (hit >= 1)
        {
            var obj = hits[0].collider.gameObject.GetComponent<Cup>();
            obj.FillCup(_color);
        }

        transform.position = _origin.position;
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
