using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    [SerializeField] LayerMask roomLayer;
    [SerializeField] float yPosition = 0;
    [SerializeField] bool doRotate = false;
    [SerializeField] Vector3 pickUprotation;
    Camera main;
    Vector3 startPosition;
    Vector3 startRotation;
    
    private void Start()
    {
        main = Camera.main;
        startPosition = transform.position;
        startRotation = transform.rotation.eulerAngles;
    }
    private void OnMouseDrag()
    {
        MoveTarget();
    }
    private void OnMouseUp()
    {
        transform.DOMove(startPosition, 1);
        if(doRotate)
            transform.DORotate(startRotation, 1);
    }
    private void MoveTarget() {
        Vector3 vector3 = Cast();
        vector3.z= Mathf.Clamp(vector3.z,-4,6.5f);
        transform.position = vector3;
        if(doRotate)
            transform.DORotate(pickUprotation, 0.1f);
    }

    private Vector3 Cast()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, roomLayer))
            if (hit.collider != null)
                return new Vector3(hit.point.x, yPosition, hit.point.z);
        return new Vector3(0, 0, 0);
    }
}
