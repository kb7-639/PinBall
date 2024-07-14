using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o�[��\������e�L�X�g
    private GameObject gameoverText;

    //�X�R�A�̏����l
    private int Point = 0;

    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        //�V�[������Score�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameOverText�ɃQ�[���I�[�o�[��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        
    }

    //�Փˎ��ɌĂ΂꓾��֐�
    void OnCollisionEnter(Collision other)
    {

        //�e�I�u�W�F�N�g�ɂԂ������瓾�_��ǉ�����
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.Point += 50;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.Point += 1;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.Point += 100;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.Point += 200;
        }

        this.scoreText.GetComponent<Text>().text = "SCORE " + this.Point;
    }

}
