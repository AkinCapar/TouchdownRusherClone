namespace CurioAssets
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        public GameObject[] examples;
        public Text txt;
        int _exampleId;
        public int ExampleId
        {
            get { return _exampleId; }
            set
            {
                _exampleId = Mathf.Clamp(value, 0, examples.Length - 1); txt.text = (_exampleId + 1).ToString();
                for (int i = 0; i < examples.Length; i++)
                {
                    examples[i].SetActive(i == _exampleId);
                }
            }
        }
        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<UIManager>();
                }

                return _instance;
            }
        }
        public void ChangeExample(bool next)
        {
            if (next) ExampleId++;
            else ExampleId--;
        }
    }
}