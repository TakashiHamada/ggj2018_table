using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour {

    [SerializeField] SectionDetectore _sectionDetectore;
    [SerializeField] QuizBase quizBase;

    public float limitTime = 5.0f;
    private float nowTime = 0.0f;


    private int nowType = 0;
    private bool nowButton0 = false;
    private bool nowButton1 = false;
    private bool nowButton2 = false;
    private bool nowButton3 = false;
    private int nowNum = 0;

    private bool isUpdate = true;

    void RandomSet()
    {
        int tmpIndex = quizBase.GetRandomQuizIndex();
        nowType = quizBase.GetQuizType(tmpIndex);
        nowButton0 = quizBase.GetButtonState(tmpIndex, 0);
        nowButton1 = quizBase.GetButtonState(tmpIndex, 1);
        nowButton2 = quizBase.GetButtonState(tmpIndex, 2);
        nowButton3 = quizBase.GetButtonState(tmpIndex, 3);
        nowNum = quizBase.GetPositionNum(tmpIndex);
    }

    void BeginQuiz()
    {
        RandomSet();
        nowTime = limitTime;
    }

    // Use this for initialization
    void Start () {
        _sectionDetectore = GameObject.Find("Detectore").GetComponent<SectionDetectore>();

        isUpdate = true;
        BeginQuiz();
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log( _sectionDetectore.GetCurrentId());
        //quizBase.GetQuizString(1);

        if(isUpdate)
        {
            nowTime -= Time.deltaTime;
            if (nowTime <= 0.0f)
            {
                Debug.Log("タイムオーバー！");
                isUpdate = false;
            }
        }

        
    }
}
