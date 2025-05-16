using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject cam;
    public float parallax;

    private float startX;

    private void Start()
    {
        startX = transform.position.x;
    }

    private void Update()
    {
        float dist = cam.transform.position.x * parallax;

        transform.position = new Vector3(startX + dist, transform.position.y, transform.position.z);
    }
}
