using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldForScreenKeyboardPanelAdjuster : MonoBehaviour {

    // Assign panel here in order to adjust its height when TouchScreenKeyboard is shown
    public GameObject panel;

    private TMP_InputField m_inputField;
    private RectTransform m_panelRectTrans;
    private Vector2 m_panelOffsetMinOriginal;
    private float m_panelHeightOriginal;
    private float m_currentKeyboardHeightRatio;

    public void Start() {
        m_inputField = transform.GetComponent<TMP_InputField>();
        m_panelRectTrans = panel.GetComponent<RectTransform>();
        m_panelOffsetMinOriginal = m_panelRectTrans.offsetMin;
        m_panelHeightOriginal = m_panelRectTrans.rect.height;
    }

    public void LateUpdate () {
        if (m_inputField.isFocused) {
            float newKeyboardHeightRatio = GetKeyboardHeightRatio();
            if (m_currentKeyboardHeightRatio != newKeyboardHeightRatio) {
                Debug.Log("InputFieldForScreenKeyboardPanelAdjuster: Adjust to keyboard height ratio: " + newKeyboardHeightRatio);
                m_currentKeyboardHeightRatio = newKeyboardHeightRatio;
                m_panelRectTrans.offsetMin = new Vector2(m_panelOffsetMinOriginal.x, m_panelHeightOriginal * m_currentKeyboardHeightRatio);
            }
        } else if (m_currentKeyboardHeightRatio != 0f) {
            if (m_panelRectTrans.offsetMin != m_panelOffsetMinOriginal)
            {
                StartCoroutine(DelayedExecute());
            }
            
            m_currentKeyboardHeightRatio = 0f;
        }
    }

    private IEnumerator DelayedExecute()
    {
        Debug.Log("InputFieldForScreenKeyboardPanelAdjuster: Revert to original");
        m_panelRectTrans.offsetMin = m_panelOffsetMinOriginal;
        yield return new WaitForSeconds(0.5f);
    }

    private float GetKeyboardHeightRatio() {
        if (Application.isEditor) {
            return 0.4f; // fake TouchScreenKeyboard height ratio for debug in editor        
        }

#if UNITY_ANDROID        
        using (AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            AndroidJavaObject view = unityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");
            using (AndroidJavaObject rect = new AndroidJavaObject("android.graphics.Rect")) {
                view.Call("getWindowVisibleDisplayFrame", rect);
                return (float)(Screen.height - rect.Call<int>("height")) / Screen.height;
            }
        }
#else
        return (float)TouchScreenKeyboard.area.height / Screen.safeArea.height;
#endif
    }

}
