namespace CurioAssets
{
    using UnityEngine;
    [ExecuteInEditMode]
    public class CurveControl : MonoBehaviour
    {
        [SerializeField]
        bool _curveOn = true;
        public Transform pos;
        [SerializeField]
        float _curvature = 1f, curve1 = 1f, curve2 = 1f, _slantX = 1f, _slantZ = 1f, _flatMargin = 0f,
           _flatMargin2 = 0f;

        private int idCurvedOrigin, idCurveMode, idCurve, idCurve1, idCurve2, idBias, idFlatness, idFlatness2;
        private Vector3 _Slant = Vector3.zero;

        public bool CurveOn
        {
            get { return _curveOn; }
            set
            {
                if (value == _curveOn) return;
                _curveOn = value;
                RefreshValues();
            }
        }
        public float Curvature
        {
            get { return _curvature; }
            set
            {
                if (value == _curvature) return;
                _curvature = value;
                RefreshValues();
            }
        }
        public float Curve1
        {
            get { return curve1; }
            set
            {
                if (value == curve1) return;
                curve1 = value;
                RefreshValues();
            }
        }
        public float Curve2
        {
            get { return curve2; }
            set
            {
                if (value == curve2) return;
                curve2 = value;
                RefreshValues();
            }
        }
        public float FlatMargin
        {
            get { return _flatMargin; }
            set
            {
                if (value == _flatMargin) return;
                _flatMargin = value;
                RefreshValues();
            }
        }
        public float FlatMargin2
        {
            get { return _flatMargin2; }
            set
            {
                if (value == _flatMargin2) return;
                _flatMargin2 = value;
                RefreshValues();
            }
        }
        public float SlantX
        {
            get { return _slantX; }
            set
            {
                if (value == _slantX) return;
                _slantX = value;
                RefreshValues();
            }
        }
        public float SlantZ
        {
            get { return _slantZ; }
            set
            {
                if (value == _slantZ) return;
                _slantZ = value;
                RefreshValues();
            }
        }
        public Vector3 originPos
        {
            get
            {
                if (pos) { return pos.position; }
                else if (Camera.main)
                    return Camera.main.transform.position;
                else
                    return Vector3.zero;
            }
        }
        void Start()
        {
            idCurvedOrigin = Shader.PropertyToID("_CurveOrigin");
            idCurveMode = Shader.PropertyToID("_CurveStlye");

            idCurve = Shader.PropertyToID("_Curvature");
            idCurve1 = Shader.PropertyToID("_Curve1");
            idCurve2 = Shader.PropertyToID("_Curve2");

            idFlatness = Shader.PropertyToID("_Flatness");
            idFlatness2 = Shader.PropertyToID("_Flatness2");

            idBias = Shader.PropertyToID("_Slant");
        }
        internal static bool running = false;
        public CurveType CurveMode;


        private void Update()
        {
            Shader.SetGlobalVector(idCurvedOrigin, originPos);
        }
        private void OnEnable()
        {
            RefreshValues();
        }
        private void OnDisable()
        {
            CurveOn = false;
            RefreshValues();
        }
        public void RefreshValues()
        {
            if (CurveOn)
                Shader.EnableKeyword("CURVE_ACTIVE");
            else
                Shader.DisableKeyword("CURVE_ACTIVE");
            Shader.SetGlobalVector(idCurvedOrigin, originPos);
            Shader.SetGlobalInt(idCurveMode, (int)CurveMode);
            switch (CurveMode)
            {
                default:
                case CurveType.Basic:
                    Shader.SetGlobalFloat(idCurve1, curve1);
                    Shader.SetGlobalFloat(idCurve2, curve2);
                    Shader.SetGlobalFloat(idFlatness, _flatMargin);
                    break;
                case CurveType.Globe:
                    Shader.SetGlobalFloat(idCurve, _curvature);
                    _Slant.x = _slantX;
                    _Slant.z = _slantZ;
                    Shader.SetGlobalVector(idBias, _Slant);
                    Shader.SetGlobalFloat(idFlatness, _flatMargin);
                    break;
                case CurveType.Planer:
                    Shader.SetGlobalFloat(idCurve, _curvature);
                    Shader.SetGlobalFloat(idCurve1, curve1);
                    Shader.SetGlobalFloat(idCurve2, curve2);
                    Shader.SetGlobalFloat(idFlatness, _flatMargin);
                    Shader.SetGlobalFloat(idFlatness2, _flatMargin2);
                    break;
            }

        }
    }

    public enum CurveType
    {
        Basic = 0,
        Globe,
        Planer
    }
}