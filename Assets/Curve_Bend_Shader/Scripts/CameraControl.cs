namespace CurioAssets
{
    using UnityEngine;
    public class CameraControl : MonoBehaviour
    {
        [Range(0, 0.5f)]
        public float cullH;
        Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void OnPreCull()
        {
            float ar = cam.aspect;
            float fov = cam.fieldOfView;
            float viewPortHeight = Mathf.Tan(Mathf.Deg2Rad * fov * 0.5f);
            float viewPortwidth = viewPortHeight * ar;

            float newfov = fov * (1 + cullH);
            float newheight = Mathf.Tan(Mathf.Deg2Rad * newfov * 0.5f);
            float newar = viewPortwidth / (newheight);

            cam.projectionMatrix = Matrix4x4.Perspective(newfov, newar, cam.nearClipPlane, cam.farClipPlane);
        }

        private void OnPreRender()
        {
            cam.ResetProjectionMatrix();
        }
    }
}