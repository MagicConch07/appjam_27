using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private LayerMask _objLayer;

    private Camera _camera;
    private GameObject _selectObject = null;

    private bool _isClicking = false;

    private void Awake()
    {
        _camera = Camera.main;

        _inputReader.OnClickEvent += HandleClick;
    }

    private void HandleClick(bool isClick)
    {

        if (isClick == false && _selectObject != null)
        {
            var obj = _selectObject.GetComponent<IBarObject>();
            obj.DeselectObject();
            _selectObject = null;
        }

        _isClicking = isClick;

    }

    private void Update()
    {
        SelectObj();
        MoveObj();
    }

    private void SelectObj()
    {
        if (_isClicking == false || _selectObject != null) return;

        RaycastHit2D[] hits = new RaycastHit2D[1];

        int hit = Physics2D.RaycastNonAlloc(GetMousePosition(), Vector3.forward, hits, Mathf.Infinity, _objLayer);

        if (hit >= 1)
        {
            IBarObject barObj = hits[0].collider.GetComponent<IBarObject>();
            _selectObject = barObj.GetObject();
        }
    }

    private void MoveObj()
    {
        if (_isClicking == false || _selectObject == null) return;

        _selectObject.transform.position = GetMousePosition();
    }

    private Vector2 GetMousePosition()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(_inputReader.MousePos);
        return mousePos;
    }
}
