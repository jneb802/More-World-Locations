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
    public class RunestoneManager
    {
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private AssetBundle translationBundle;

        public void AddlocalizationsEnglish()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
              {"GoldOre_warp", "Gold ore" },
              { "GoldOre_desc_warp", "Unrefined gold. Use a smelter to refine into gold coins." },
              { "GoldDeposit_warp", "Gold" },
              { "IronDeposit_warp", "Iron" },
              { "SilverDepositSmall_warp", "Silver" },
              { "BlackmetalDeposit_warp", "Blackmetal" }
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
