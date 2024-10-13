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
        // �������� �󱼿� �������(��ġ, ȸ��)�� ���� ��
        if (args.updated.Count > 0)                 // �ϳ��� �����ϴ� ��
        {
            // ARFace�� �����ͼ�
            ARFace face = args.updated[0];

            Vector3 glassPos = face.transform.TransformPoint(face.vertices[6]);             // 6�� ��ġ�� ǥ���Ѵ�.
            glassTracker.transform.position = glassPos;
        }
    }
}
