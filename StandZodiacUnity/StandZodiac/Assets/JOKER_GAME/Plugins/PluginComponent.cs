using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Novel
{

    public class ChangeComponent : AbstractComponent
    {
        // Start is called before the first frame update
        public ChangeComponent()
        {
            this.arrayVitalParam = new List<string>
            {
                "name"};
        }

        public override void start()
        {
            SceneManager.LoadScene(this.param["name"]);
        }
    }

     public class JoinComponent : AbstractComponent
    {
        public JoinComponent()
        {
            this.arrayVitalParam = new List<string>
            {
                "move"};

            //           //必須項目
            //           this.arrayVitalParam = new List<string> {
            //"var","arg1","arg2"
            //};

            //           this.originalParam = new Dictionary<string, string> {
            //{"var",""},
            //{"arg1",""},
            //{"arg2",""},
            //};

        }

        public override void start()
        {
           // GameObject cube = GameObject.Find("Cube");
           // if (this.param["move"] == "0")
          //  {
            //    cube.GetComponent<MoveController>().move = MoveController.MOVE.HORIZONTAL;
           // }
           /// else
          //  {
          //      cube.GetComponent<MoveController>().move = MoveController.MOVE.VERTICAL;
          //  }

            //string var_name = this.param["var"];
            //string arg1 = this.param["arg1"];
            //string arg2 = this.param["arg2"];

            //Debug.Log(arg1);
            //Debug.Log(arg2);

            //string arg_result = arg1 + arg2;

            ////変数に結果を格納
            //StatusManager.variable.set(var_name, arg_result);

            ////次のシナリオに進む処理
            //this.gameManager.nextOrder();

        }

    }

}
