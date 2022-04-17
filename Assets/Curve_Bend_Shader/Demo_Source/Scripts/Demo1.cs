namespace CurioAssets
{
    using System.Collections;
    using UnityEngine;

    public class Demo1 : MonoBehaviour
    {
        CurveControl curveControl;
        private void Start()
        {
            curveControl = GetComponent<CurveControl>();
        }
        private void OnEnable()
        {
            if (curveControl == null) curveControl = GetComponent<CurveControl>();
            curveControl.CurveOn = true;
            isInProcess = false;
            StopAllCoroutines();
            switch (UIManager.Instance.ExampleId)
            {
                case 0:
                    ChangeCurve0();
                    break;
                case 1:
                    ChangeCurve1();
                    break;
                case 2:
                    ChangeCurve2();
                    break;
                case 3:
                    ChangeCurve3();
                    break;
            }
        }
        bool isInProcess = false;
        void ChangeCurve0()
        {
            if (!isInProcess)
            {
                isInProcess = true;
                float currValue = curveControl.Curve1;
                float finalValue = currValue > 0 ? -1 : 1;
                StartCoroutine(ChangeCurveDirection0(currValue, finalValue));
            }
        }

        IEnumerator ChangeCurveDirection0(float startValue, float endValue, float seconds = 3f)
        {
            float animationTime = 0f;
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                curveControl.Curve1 = Mathf.Lerp(startValue, endValue, lerpValue);
                curveControl.Curve2 = Mathf.Lerp(startValue, endValue, lerpValue);
                yield return null;
            }
            curveControl.Curve1 = endValue;
            curveControl.Curve2 = endValue;
            isInProcess = false;
        }
        void ChangeCurve1()
        {
            if (!isInProcess)
            {
                isInProcess = true;
                float currValue = curveControl.Curvature;
                float finalValue = currValue > 0 ? -5 : 3;
                StartCoroutine(ChangeCurveDirection1(currValue, finalValue));
            }
        }
        IEnumerator ChangeCurveDirection1(float startValue, float endValue, float seconds = 3f)
        {
            float animationTime = 0f;
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                curveControl.Curvature = Mathf.Lerp(startValue, endValue, lerpValue);
                yield return null;
            }
            curveControl.Curvature = endValue;
            isInProcess = false;
        }
        void ChangeCurve2()
        {
            if (!isInProcess)
            {
                isInProcess = true;
                float currValue = curveControl.Curvature;
                float finalValue = currValue > 0 ? -1 : 1;
                StartCoroutine(ChangeCurveDirection2(currValue, finalValue));
            }
        }
        IEnumerator ChangeCurveDirection2(float startValue, float endValue, float seconds = 3f)
        {
            float animationTime = 0f;
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                curveControl.Curvature = Mathf.Lerp(startValue, endValue, lerpValue);
                yield return null;
            }
            curveControl.Curvature = endValue;
            isInProcess = false;
        }

        void ChangeCurve3()
        {
            if (!isInProcess)
            {
                isInProcess = true;
                float prevValue = curveControl.Curve1;
                float newValue = prevValue > 0 ? -1 : 1;
                float prevValue1 = curveControl.Curve2;
                float newValue1 = newValue > 0 ? -1 : 1;
                StartCoroutine(ChangeCurveDirection3(prevValue, newValue, prevValue1, newValue1));
            }
        }
        IEnumerator ChangeCurveDirection3(float startValue, float endValue, float startValue1, float endValue1, float seconds = 3f)
        {
            float animationTime = 0f;
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                curveControl.Curve1 = Mathf.Lerp(startValue, endValue, lerpValue);
                curveControl.Curve2 = Mathf.Lerp(startValue1, endValue1, lerpValue);
                yield return null;
            }
            curveControl.Curve1 = endValue;
            curveControl.Curve2 = endValue1;
            isInProcess = false;
        }
    }
}