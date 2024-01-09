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
    internal class TextManager
    {
        public static CustomLocalization Localization = Jotunn.Managers.LocalizationManager.Instance.GetLocalization();

        private AssetBundle translationBundle;

        public void AddlocalizationsEnglish()
        {
            Localization = Jotunn.Managers.LocalizationManager.Instance.GetLocalization();
            Localization.AddTranslation("English", new Dictionary<string, string>
            {
                { "MWL_runestone", "Runestone" },
                { "Hjortkult_Topic_1", "The Hjortkult's Initiation" },
                { "Hjortkult_Label_1", "Hjortkult lore 1" },
                { "Hjortkult_Text_1", "Hearken, young kin, to the tale of Eikthyr, our mighty lord of antlers. In shadows of ancient woods, we bow, our hearts and swords to him we vow. Fear not, for in his strength we partake; as Hjortkult's blood, in his image, we wake." },
                { "Hjortkult_Topic_2", "The Lament of a Hjortkult Survivor" },
                { "Hjortkult_Label_2", "Hjortkult lore 2" },
                { "Hjortkult_Text_2", "Under a sky cloaked in weeping clouds, Eikthyr, in wrath, descended. The night, as black as raven's plume, saw our haven in flames upended. Our prayers, once sweet, turned bitter gall, as he, our god, heralded our fall. Escaped I, through fate's thin thread, leaving behind the Hjortkult's dead." },
                { "Hjortkult_Topic_3", "A Chant for Eikthyr's Favor" },
                { "Hjortkult_Label_3", "Hjortkult lore 3" },
                { "Hjortkult_Text_3", "Eikthyr, O Eikthyr, mighty and vast, bless us, your kin, till ages last. Our sacrifices laid at your feet, our worship, humble, our offerings, sweet. For your boon, we yearn and pray, in your shadow, we live and fray" },
                { "Tyggrason_Topic_1", "Tyggrason’s Proclamation" },
                { "Tyggrason_Label_1", "Tyggrason Lore 1" },
                { "Tyggrason_Text_1", "Hear, kin of the fjord! The Tyggrason embrace Christ's path, a god of peace, not war. His realm, unseen, promises eternal peace. Let us cast aside our old gods, for this Christ speaks not of war and conquest, but of forgiveness and life everlasting." },
                { "Tyggrason_Topic_2", "Tyggrason’s Order" },
                { "Tyggrason_Label_2", "Tyggrason Lore 2" },
                { "Tyggrason_Text_2", "Rise, ye brave of heart! Take up this cause as your sword, this faith as your shield. Spread this word of the Christian god, for in His name, we find a bond stronger than any forged by mortal hands. This is our quest, our destiny, to weave a new saga under Christ's watchful eye." },
                { "Tyggrason_Topic_3", "Tyggrason’s Prayer" },
                { "Tyggrason_Label_3", "Tyggrason Lore 3" },
                { "Tyggrason_Text_3", "O mighty Lord, guide us, Thy warriors. In Thy strength, we confront our trials. Be our refuge, our guiding star. In Thee, our trust resides. Amen." },
                { "Midgard_Topic_1", "Meadows of Promise" },
                { "Midgard_Label_1", "Midgard Lore 1" },
                { "Midgard_Text_1", "Beneath the golden sun, our boots kissed the Meadows green embrace. My heart, ablaze with Odins fire, spoke to my kinsmen, Here, in this untouched land, we forge our saga. Stand tall, for glory awaits!" },
                { "Midgard_Topic_2", "A Letter to Midgard" },
                { "Midgard_Label_2", "Midgard Lore 2" },
                { "Midgard_Text_2", "To those in our beloved Midgard, know this – in the Blackforest's shadowed heart, our blades sang a fierce song. Each fallen beast, a testament to our unwavering spirit. Our confidence, unbroken, grows with each darkened mile we conquer." },
                { "Midgard_Topic_3", "Swamp of Shadows" },
                { "Midgard_Label_3", "Midgard Lore 3" },
                { "Midgard_Text_3", "In the Swamp's mire, our courage faced a foe unseen. Mist-clad horrors whispered dread, and the bravest of us felt a cold grip of terror. 'Twas a land not of men, but of lurking, unseen threats, testing our resolve." },
                { "Midgard_Topic_4", "Midgard’s Despair" },
                { "Midgard_Label_4", "Midgard Lore 4" },
                { "Midgard_Text_4", "In the cruel Mountains, sickness took hold like a silent beast. Our eyes cast skyward, we trembled at the shadows of creatures circling above. Fear gnawed at our hearts; hope seemed but a distant memory in this frozen hell." },
                { "Midgard_Topic_5", "Harald's Final Stand" },
                { "Midgard_Label_5", "Midgard Lore 5" },
                { "Midgard_Text_5", "Upon the vast Plains, with my few hardened warriors by my side, I gazed upon the horizon. Our numbers thinned, yet our resolve, like tempered steel, only strengthened. 'Tis here, in this endless field, we shall carve our destiny or embrace a warrior's death." },
                { "Edda_Topic_1", "Missive: Edda’s Disappearance " },
                { "Edda_Label_1", "Edda Lore 1" },
                { "Edda_Text_1", "In the cold grasp of Niflheim's breath, I scribe this note, heavy with dread. The sacred leaves of Edda's grace, once safe in our keep, now lost without trace. The skalds, bold in heart, venture through Valheim's dark, seeking what's torn apart. To you, wise keeper of lore, I plea, aid them in this quest, for the power of words, we must not let flee." },
                { "Edda_Topic_2", "Skald's Ode" },
                { "Edda_Label_2", "Edda Lore 2" },
                { "Edda_Text_2", "Through mist and shadow, we stride,\n\nSeekers of Edda's stolen pride.\n\nIn Valheim's vast, whispered land,\n\nSide by side, a bonded band.\n\nOur voices rise, in ancient song,\n\nFor the pages lost, we long." },
                { "Edda_Topic_3", "Chronicles of Brotherhood" },
                { "Edda_Label_3", "Edda Lore 3" },
                { "Edda_Text_3", "In the heart of Valheim's wild, under the watchful eyes of the gods, our kinship grows. Each day, as we chase the whispers of the missing Edda, our spirits entwine like the roots of Yggdrasil. Around the fire, our tales and songs mingle, forging bonds as strong as Mjolnir's might. In this journey, not just pages we seek, but a brotherhood born in the quest for wisdom's peak." },
                { "Eik_Topic_1", "Vigil of the Mighty Oak" },
                { "Eik_Label_1", "Eik Lore 1" },
                { "Eik_Text_1", "Hark! Gather 'round, kin of Eik, beneath the ancient boughs, where whispers of yore echo. In this mighty Oak, our spirits entwine, as steadfast as the roots that delve deep into Midgard's embrace. Its leaves, like warriors' shields, stand guard against the heavens' fury. Here, in its shelter, we stand united, as enduring as the timeless Oak itself" },
                { "Eik_Topic_2", "Meadow's Edge: A Cautionary Verse" },
                { "Eik_Label_2", "Eik Lore 2" },
                { "Eik_Text_2", "Listen well, Children of Eik, to the skald's solemn song. Beyond these meadows, where the Oak's shadow falters, lies a realm of untold perils. Let not curiosity nor folly lead ye astray, for beyond our sacred grove, darkness festers. Here, in the Oak's embrace, lies our sanctuary; beyond, only shadows and misfortune await." },
            });
        }

        public void LoadTranslationJSONS()
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
