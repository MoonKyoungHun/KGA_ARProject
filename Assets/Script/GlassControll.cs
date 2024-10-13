using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GlassControll : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

    [SerializeField] GameObject[] glassPrefabs;

    private GameObject glassTracker;

    private void Awake()
    {
        glassTracker = Instantiate(glassPrefabs[0]);

    }

    private void OnEnable()
    {
        faceManager.facesChanged += OnFaceChange;
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChange;
    }

    private void OnFaceChange(ARFacesChangedEventArgs args)
    {
        // 추적중인 얼굴에 변경사항(위치, 회전)이 있을 때
        if (args.updated.Count > 0)                 // 하나만 적용하는 중
        {
            // ARFace를 가져와서
            ARFace face = args.updated[0];

            Vector3 glassPos = face.transform.TransformPoint(face.vertices[6]);             // 6번 위치에 표시한다.
            glassTracker.transform.position = glassPos;
        }
    }
}
