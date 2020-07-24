using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldForScreenKeyboardPanelAdjuster : MonoBehaviour {

    // Assign panel here in order to adjust its height when TouchScreenKeyboard is shown
    public GameObject panel;

    private TMP_InputField inputField;
    private RectTransform panelRectTrans;
    private Vector2 panelOffsetMinOriginal;
    private float panelHeightOriginal;
    private float currentKeyboardHeightRatio;

    public void Start() {
        inputField = transform.GetComponent<TMP_InputField>();
        panelRectTrans = panel.GetComponent<RectTransform>();
        panelOffsetMinOriginal = panelRectTrans.offsetMin;
        panelHeightOriginal = panelRectTrans.rect.height;
    }

    public void LateUpdate () {
        if (inputField.isFocused) {
            float newKeyboardHeightRatio = GetKeyboardHeightRatio();
            if (currentKeyboardHeightRatio != newKeyboardHeightRatio) {
                Debug.Log("InputFieldForScreenKeyboardPanelAdjuster: Adjust to keyboard height ratio: " + newKeyboardHeightRatio);
                currentKeyboardHeightRatio = newKeyboardHeightRatio;
                panelRectTrans.offsetMin = new Vector2(panelOffsetMinOriginal.x, panelHeightOriginal * currentKeyboardHeightRatio);
            }
        } else if (currentKeyboardHeightRatio != 0f) {
            if (panelRectTrans.offsetMin != panelOffsetMinOriginal)
            {
                StartCoroutine(DelayedExecute());
            }
            
            currentKeyboardHeightRatio = 0f;
        }
    }

    private IEnumerator DelayedExecute()
    {
        Debug.Log("InputFieldForScreenKeyboardPanelAdjuster: Revert to original");
        panelRectTrans.offsetMin = panelOffsetMinOriginal;
        yield return new WaitForSeconds(0.5f);
    }

    private float GetKeyboardHeightRatio() {
        if (Application.isEditor) {
            return 0.4f; // fake TouchScreenKeyboard height ratio for debug in editor        
        }

#if UNITY_ANDROID        
        using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");
            using (AndroidJavaObject rect = new AndroidJavaObject("android.graphics.Rect")) {
                View.Call("getWindowVisibleDisplayFrame", rect);
                return (float)(Screen.height - rect.Call<int>("height")) / Screen.height;
            }
        }
#else
        return (float)TouchScreenKeyboard.area.height / Screen.safeArea.height;
#endif
    }

}
