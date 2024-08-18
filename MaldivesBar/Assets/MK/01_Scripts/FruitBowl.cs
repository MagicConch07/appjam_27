using UnityEngine;

public class FruitBowl : MonoBehaviour, IBarObject
{
    [SerializeField] private GameObject _prefab = null;

    public void DeselectObject()
    {
        return;
    }

    public GameObject GetObject()
    {
        var prefab = Instantiate(_prefab, transform.position, Quaternion.identity);
        return prefab;
    }
}
