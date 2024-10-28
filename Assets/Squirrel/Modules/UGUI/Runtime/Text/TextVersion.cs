using TMPro;
using UnityEngine;

namespace Squirrel.UGUI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextVersion : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<TextMeshProUGUI>().SetText("Version " +Application.version);
        }
    }
}