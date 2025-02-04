
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private float rotatespeed;
    private void Update()
    {
        SetCircleRotate();

    }
    private void SetCircleRotate()
    {
        transform.Rotate(Vector3.forward * rotatespeed * Time.deltaTime);
    }

}
