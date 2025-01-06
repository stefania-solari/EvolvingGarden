using UnityEngine;

public class InteractiveRippleController : MonoBehaviour
{
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CastClickRay();
        }
    }

    private void CastClickRay()
    {
        var camera= Camera.main;
        var mousePosition = Input.mousePosition;

        var ray = camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));

        if(Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject)
        {
            StartRipple(hit.point);

        }
        
    }

    public void StartRipple(Vector3 center)
    {   
        material.SetVector("_RippleCenter", center);
        material.SetFloat("_RippleStartTime", Time.time);
    }
}
