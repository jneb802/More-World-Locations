using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoreWorldLocations
{
    internal class RunestoneManager
    {
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private AssetBundle translationBundle;

        public void AddlocalizationsEnglish()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
              { "MWL_runestone", "Runestone" },
              { "Hjortkult_Topic_1", "this is a topic 1" },
              { "Hjortkult_Label_1", "this is a label 1" },
              { "Hjortkult_Text_1", "this is a text 1" },
              { "Hjortkult_Topic_2", "this is a topic 2" },
              { "Hjortkult_Label_2", "this is a label 2" },
              { "Hjortkult_Text_2", "this is a text 2" },
              { "Hjortkult_Topic_3", "this is a topic 3" },
              { "Hjortkult_Label_3", "this is a label 3" },
              { "Hjortkult_Text_3", "this is a text 3" },
            });
        }

        public void JSONS()
        {
            if (translationBundle == null)
            {
                return;
            }

            TextAsset[] textAssets = translationBundle.LoadAllAssets<TextAsset>();

            foreach (var textAsset in textAssets)
            {
                var lang = textAsset.name.Replace("_MoreOreDeposits", "");
                Localization.AddJsonFile(lang, textAsset.text);
            }
        }
    }
}
