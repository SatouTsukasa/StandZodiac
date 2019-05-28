using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Novel
{

    public class Change1Component : AbstractComponent
    {
        // Start is called before the first frame update
        public Change1Component()
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

}
