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

        }

        public override void start()
        {


        }

    }

}
