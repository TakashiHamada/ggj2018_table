using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour {

    [SerializeField] SectionDetectore _sectionDetectore;
    [SerializeField] TableInput _tableInput;
    [SerializeField] QuizBase _quizBase;
    [SerializeField] DisplayManager _displayManager;
    [SerializeField] SoundManager _soundManager;

    public float limitTime = 5.0f;
    private float nowTime = 0.0f;

    private int nowType = 0;
    private bool[] nowButton = new bool[4];
    private int nowGoalNum = 0;

    private bool isUpdate = true;

    private int nowRotationID = 0;

    private int goalID = 0;

    ////////////////////////////
    // 押しながら回す関連

    // ちゃんとおしっぱでうごいた数
    private int correctCount = 0;

    // 時計回り？
    private bool isClockwise;


    ///////////////////////////

    // ボタンの状態を調べます
    bool CalcButtonSate()
    {
        if((nowButton[0] == _tableInput.GetButton(0)) &&
            (nowButton[1] == _tableInput.GetButton(1)) &&
              (nowButton[2] == _tableInput.GetButton(2)) &&
                (nowButton[3] == _tableInput.GetButton(3))
            )
        {
            Debug.Log("ボタン状態正解");
            return true;
        }
        return false;
    }
    
    // ランダムにクイズ情報を生成
    void RandomSet()
    {
        int tmpIndex = _quizBase.GetRandomQuizIndex();
        nowType = _quizBase.GetQuizType(tmpIndex);
        nowButton[0] = _quizBase.GetButtonState(tmpIndex, 0);
        nowButton[1] = _quizBase.GetButtonState(tmpIndex, 1);
        nowButton[2] = _quizBase.GetButtonState(tmpIndex, 2);
        nowButton[3] = _quizBase.GetButtonState(tmpIndex, 3);
        nowGoalNum = _quizBase.GetPositionNum(tmpIndex);
        if (nowType == 0)
        {
            nowGoalNum = Mathf.Abs(nowGoalNum);
        }

        int tmpButton0 = (nowButton[0]) ? 1 : 0;
        int tmpButton1 = (nowButton[1]) ? 1 : 0;
        int tmpButton2 = (nowButton[2]) ? 1 : 0;
        int tmpButton3 = (nowButton[3]) ? 1 : 0;
        
        // UIセット
        _displayManager.ShowIntroduction(nowType, tmpButton0, tmpButton1, tmpButton2, tmpButton3, nowGoalNum);

        Debug.Log(_quizBase.GetQuizString(tmpIndex));
    }

    // クイズ開始
    void BeginQuiz()
    {
        RandomSet();
        nowTime = limitTime;
        isUpdate = true;
        correctCount = 0;
        nowRotationID = _sectionDetectore.GetCurrentId();

        if(nowType == 0)
        {
            goalID = nowGoalNum;
        }
        else
        {
            if(nowGoalNum > 0)
            {
                isClockwise = true;
            }
            else
            {
                isClockwise = false;
            }
            goalID = nowGoalNum;
        }
    }

    // 前押しのタイプアップデート
    void UpdateBeforePush()
    {

        if (nowRotationID != _sectionDetectore.GetCurrentId())
        {
            int difference = _sectionDetectore.GetCurrentId() - nowRotationID;
            
            if (isClockwise)
            {
                if (difference < -6 && CalcButtonSate())
                {
                    difference = 1;
                    correctCount += difference;
                }
                else
                {
                    if(difference > 0 && CalcButtonSate())
                    {
                        correctCount += difference;
                    }
                }
            }
            else
            {
                if (difference > 6 && CalcButtonSate())
                {
                    difference = 1;
                    correctCount += difference;
                }
                else
                {
                    if (difference < 0 && CalcButtonSate())
                    {
                        correctCount += difference;
                    }
                }
            }

            nowRotationID = _sectionDetectore.GetCurrentId();
            Debug.Log("nowRotationID:" + nowRotationID);
        }


        if (correctCount == goalID)
        {
            _soundManager.PlaySECorrect();
            Debug.Log("正解！");
            BeginQuiz();
        }
    }

    // 後押しのタイプアップデート
    void UpdateAfterPush()
    {
        if (nowRotationID != _sectionDetectore.GetCurrentId())
        {
            nowRotationID = _sectionDetectore.GetCurrentId();
            Debug.Log("nowRotationID:" + nowRotationID);
        }


        if (nowRotationID == goalID)
        {
            //Debug.Log("押し待ち");
            if (CalcButtonSate())
            {
                _soundManager.PlaySECorrect();
                Debug.Log("正解！");
                BeginQuiz();
            }
        }
    }
    

    IEnumerator sleep(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    

    // Use this for initialization
    void Start () {
        _sectionDetectore = GameObject.Find("Detectore").GetComponent<SectionDetectore>();
        _tableInput = GameObject.Find("Input").GetComponent<TableInput>();
        _displayManager = GameObject.Find("Canvas").GetComponent<DisplayManager>();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _soundManager.PlayBGM();

        isUpdate = true;

        StartCoroutine("sleep", 1);
        BeginQuiz();
    }
	
	// Update is called once per frame
	void Update () {

        if(isUpdate)
        {
            nowTime -= Time.deltaTime;
            if (nowTime <= 0.0f)
            {
                //Debug.Log("タイムオーバー！");
                //isUpdate = false;
            }

            switch (nowType)
            {
                case 0:
                    UpdateAfterPush();
                    break;
                case 1:
                    UpdateBeforePush();
                    break;
            }


        }
    }
}
