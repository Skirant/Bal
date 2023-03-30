using UnityEngine;

[ExecuteAlways]
public class CameraAspect : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float _aspect = 9f / 16f;

    // Update is called once per frame
    void Update()
    {
        float width = Screen.height * _aspect;
        float w = width / Screen.width;

        float x = (1 - w) / 2f;

        _camera.rect = new Rect(x, 0, w, 1);
    }
}
