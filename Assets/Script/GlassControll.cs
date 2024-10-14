using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GlassControll : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

    [SerializeField] GameObject[] glassPrefabs;

    private GameObject glassTracker;

    public void Awake()
    {
        for (int i = 0; i < glassPrefabs.Length; i++)
        {
            glassTracker = Instantiate(glassPrefabs[i]);

            glassTracker.SetActive(false);
        }

    }

    private void OnEnable()
    {
        faceManager.facesChanged += OnFaceChange;
    }

    //private void OnDisable()
    //{
    //    faceManager.facesChanged -= OnFaceChange;
    //}

    private void OnFaceChange(ARFacesChangedEventArgs args)
    {
        // 추적중인 얼굴에 변경사항(위치, 회전)이 있을 때
        if (args.updated.Count > 0)
        {
            // ARFace를 가져와서
            ARFace face = args.updated[0];

            Vector3 glassPos = face.transform.TransformPoint(face.vertices[6]);             // 6번 위치에 표시한다.
            glassTracker.transform.position = glassPos;
            glassTracker.SetActive(true);
        }
        else if (args.removed.Count > 0)
        {
            glassTracker.SetActive(false);
        }
    }

    public void Glass1()
    {
        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[0]);
    }

    public void Glass2()
    {
        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[1]);
    }

    public void Glass3()
    {
        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[2]);
    }

    public void Glass4()
    {
        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[3]);
    }

    public void Glass5()
    {
        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[4]);
    }

    public void RandomGlass()
    {
        int random = Random.Range(0, glassPrefabs.Length);

        glassTracker.SetActive(false);

        glassTracker = Instantiate(glassPrefabs[random]);

    }
}
