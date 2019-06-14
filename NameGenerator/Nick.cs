using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    abstract class Nick
    {
        protected String description;
        protected Char[] consonants;
        protected Char[] vowels;
        protected Random rnd_engine;
        public abstract String giveNick(int syllables);
    }

    class SimpleLatinNick : Nick
    {
        public SimpleLatinNick()
        {
            description = "Default method of generating";
            consonants = new Char[]{'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','z'};
            vowels = new Char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
            rnd_engine = new Random(Guid.NewGuid().GetHashCode());
        }
        private String makeSyllable()
        {
            StringBuilder syllable = new StringBuilder("");

            int syl_length = rnd_engine.Next(2,5);
            int syl_vowel_place = rnd_engine.Next(syl_length);

            var str_temp = new List<String>();
            for (int i = 0; i < syl_length; i++)
            {
                if (i != syl_vowel_place) syllable.Append(consonants[rnd_engine.Next(consonants.GetLength(0))]);
                else syllable.Append(vowels[rnd_engine.Next(vowels.GetLength(0))]);
            }

            return syllable.ToString();
        }
        public override String giveNick(int syllables)
        {
            String nick = "";
            if (syllables<1)return "error";

            for (int i = 0; i < syllables; i++)
            {
                nick = nick + makeSyllable();
            }

                return nick;
        }
    }

    class AdvancedLatinNick : SimpleLatinNick
    {
        protected String makeAdvancedSyllable(Boolean is_vowel_before)
        {
            StringBuilder syllable = new StringBuilder("");

           int syl_length;
           int syl_vowel_place;
           int long_syl = rnd_engine.Next(0, 2);
           if (!is_vowel_before)
           {
               syl_length = rnd_engine.Next(2, 3); 
               syl_vowel_place = 0;
           }
           else
           {
               syl_length = rnd_engine.Next(2, 4);
               syl_vowel_place = rnd_engine.Next(syl_length);
           }
           
  

            var str_temp = new List<String>();
            for (int i = 0; i < syl_length; i++)
            {
                if (i != syl_vowel_place) syllable.Append(consonants[rnd_engine.Next(consonants.GetLength(0))]);
                else syllable.Append(vowels[rnd_engine.Next(vowels.GetLength(0))]);
            }
           if (syl_vowel_place!=(syl_length-1)) syllable.Append('!');

            return syllable.ToString();
        }

       public override string giveNick(int syllables)
       {
           String nick = "";
           if (syllables < 1) return "error";

           for (int i = 0; i < syllables; i++)
           {
               if(nick.Length>0 && nick.EndsWith("!"))
               {
                   nick = nick.Trim('!');
                   nick = nick + makeAdvancedSyllable(false);
               }
               else
                   nick = nick + makeAdvancedSyllable(true);
           }
           nick = nick.Trim('!');
           return nick;
       }

    }

    class AdvancedEnglishNick : AdvancedLatinNick
    {
        public AdvancedEnglishNick()
        {
            description = "Default method of generating";
            consonants = new Char[]{'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','y','z'};
            vowels = new Char[] { 'a', 'e', 'i', 'o', 'u' };
            rnd_engine = new Random(Guid.NewGuid().GetHashCode());
        }
    }

    class AdvancedPolishNick : AdvancedLatinNick
    {
        public AdvancedPolishNick()
        {
            description = "Default method of generating";
            consonants = new Char[] { 'b', 'c','ć', 'd', 'f', 'g', 'h', 'j', 'k', 'l','ł', 'm', 'n', 'p', 'r', 's','ś', 't', 'w', 'y', 'z','ź','ż'};
            vowels = new Char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
            rnd_engine = new Random(Guid.NewGuid().GetHashCode());
        }
    }

    class NickProducer
    {
        public String nickGeneration(String type, int syllables)
        {
            Nick nick = null;
            switch (type)
            {
                case "default_latin"    : { nick = new SimpleLatinNick(); }
                break;
                case "advanced_latin"   : { nick = new AdvancedLatinNick(); }
                break;
                case "advanced_english":  { nick = new AdvancedEnglishNick(); }
                break;
                case "advanced_polish": { nick = new AdvancedPolishNick(); }
                break;
            }

            /*if (type.Equals("default_latin")) { nick = new SimpleLatinNick(); }
            else if (type.Equals("advanced_latin")) { nick = new AdvancedLatinNick(); }
            else if (type.Equals("advanced_english")) { nick = new AdvancedEnglishNick(); }*/

            return nick.giveNick(syllables);
        }
    }
}
