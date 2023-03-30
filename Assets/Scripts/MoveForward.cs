using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float _moveSpeed;
    [SerializeField] private float _moveSpeedMax = 10f;
    [SerializeField] private float _moveSpeedMin = 10f;

    private void Start()
    {
        _moveSpeed = Random.Range(_moveSpeedMin, _moveSpeedMax);
    }

    private void Update()
    {
        transform.position += Vector3.up * (_moveSpeed * Time.deltaTime);
    }

}
