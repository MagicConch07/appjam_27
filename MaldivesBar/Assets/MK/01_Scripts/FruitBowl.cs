using UnityEngine;

public class FruitBowl : MonoBehaviour, IBarObject
{
    [SerializeField] private GameObject _prefab = null;

    public void DeselectObject()
    {
        throw new System.NotImplementedException();
    }

    public GameObject GetObject()
    {
        var prefab = Instantiate(_prefab, transform.position, Quaternion.identity);
        return prefab;
    }
}
