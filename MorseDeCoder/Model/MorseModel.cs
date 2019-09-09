using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace MorseDeCoder.Model
{
    public class MorseModel : INotifyPropertyChanged
    {
        public MorseModel()
        {
            LoadMorseCode();
            //Latin = "Enter the text in latin alphabet and it will be converted to Morse code, and vice-versa.";
            //Morse = "";
        }

        private Dictionary<string, string> latinToMorse;

        public Dictionary<string, string> LatinToMorse
        {
            get
            {
                return latinToMorse;
            }
            set {}
        }

        public void LoadMorseCode()
        {
            latinToMorse = new Dictionary<string, string>
            {
                { "A", ".-" },
                //latinToMorse.Add("a", ".-");
                { "B", "-..." },
                //latinToMorse.Add("b", "-...");
                { "C", "-.-." },
                //latinToMorse.Add("c", "-.-.");
                { "D", "-.." },
                //latinToMorse.Add("d", "-..");
                { "E", "." },
                //latinToMorse.Add("e", ".");
                { "F", "..-." },
                //latinToMorse.Add("f", "..-.");
                { "G", "--." },
                //latinToMorse.Add("g", "--.");
                { "H", "...." },
                //latinToMorse.Add("h", "....");
                { "I", ".." },
                //latinToMorse.Add("i", "..");
                { "J", ".---" },
                //latinToMorse.Add("j", ".---");
                { "K", "-.-" },
                //latinToMorse.Add("k", "-.-");
                { "L", ".-.." },
                //latinToMorse.Add("l", ".-..");
                { "M", "--" },
                //latinToMorse.Add("m", "--");
                { "N", "-." },
                //latinToMorse.Add("n", "-.");
                { "O", "---" },
                //latinToMorse.Add("o", "---");
                { "P", ".--." },
                //latinToMorse.Add("p", ".--.");
                { "R", ".-." },
                //latinToMorse.Add("r", ".-.");
                { "S", "..." },
                //latinToMorse.Add("s", "...");
                { "T", "-" },
                //latinToMorse.Add("t", "-");
                { "U", "..-" },
                //latinToMorse.Add("u", "..-");
                { "V", "...-" },
                //latinToMorse.Add("v", "...-");
                { "Z", "--.." },
                //latinToMorse.Add("z", "--..");

                { "Q", "--.-" },
                //latinToMorse.Add("q", "--.-");
                { "W", ".--" },
                //latinToMorse.Add("w", ".--");
                { "X", "-..-" },
                //latinToMorse.Add("x", "-..-");
                { "Y", "-.--" },
                //latinToMorse.Add("y", "-.--");

                { "Č", "-.--." },
                //latinToMorse.Add("č", "-.--.");
                { "Ć", "-.-.." },
                //latinToMorse.Add("ć", "-.-..");
                { "DŽ", "--.-." },
                //latinToMorse.Add("dž", "--.-.");
                { "Đ", "-..--" },
                //latinToMorse.Add("đ", "-..--");
                { "LJ", ".---." },
                //latinToMorse.Add("lj", ".---.");
                { "NJ", "--.--" },
                //latinToMorse.Add("nj", "--.--");
                { "Š", "---.-" },
                //latinToMorse.Add("š", "---.-");
                { "Ž", "--..-" },
                //latinToMorse.Add("ž", "--..-");


                { "1", ".----" },
                { "2", "..---" },
                { "3", "...--" },
                { "4", "....-" },
                { "5", "....." },
                { "6", "-...." },
                { "7", "--..." },
                { "8", "---.." },
                { "9", "----." },
                { "0", "-----" },


                { ".", ".-.-.-" },
                { ",", "--..--" },
                { "?", "..--.." },
                { "'", ".----." },
                { "!", "-.-.--" },
                { "/", "-..-." },
                { "(", "-.--." },
                { ")", "-.--.-" },
                { "&", ".-..." },
                { ":", "---..." },
                { ";", "-.-.-." },
                { "=", "-...-" },
                { "+", ".-.-." },
                { "-", "-....-" },
                { "_", "..--.-" },
                { "\"", ".-..-." },
                { "$", "...-..-" },
                { "@", ".--.-." }
            };


            LatinToMorse = latinToMorse;
        }

        private string latin;
        private string morse;

        public string Latin
        {
            get
            {
                return latin;
            }

            set
            {
                if (latin != value)
                {
                    latin = value;
                    RaisePropertyChanged("Latin");

                    FromLatinToMorse();
                    RaisePropertyChanged("Morse");
                }
            }
        }

        public string Morse
        {
            get
            {
                return morse;
            }

            set
            {
                if (morse != value)
                {
                    morse = value;
                    RaisePropertyChanged("Morse");

                    FromMorseToLatin();
                    RaisePropertyChanged("Latin");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void FromLatinToMorse()
        {
            morse = "";
            foreach(char c in latin)
            {
                if (!latinToMorse.TryGetValue(c.ToString().ToUpper(), out string value))
                {
                    if (c == ' ')
                        morse += "  ";
                    else if (c == '\r' || c == '\n')
                        morse += c;
                    else
                    {
                        morse += c;
                        morse += "  ";
                    }
                }
                else
                {
                    morse += value += "  ";
                }
            }
        }

        private void FromMorseToLatin()
        {
            latin = "";
            string letter = "";
            foreach (char c in morse)
            {
                if (c != '-' && c != '.')
                {
                    if (latinToMorse.ContainsValue(letter))
                    {
                        string key = latinToMorse.FirstOrDefault(x => x.Value == letter).Key;
                        latin += key;
                    }
                    //else
                    //{
                    //    latin += letter;
                    //}
                    //latin += " ";
                    letter = "";
                    //latin += c;
                    if (c == ' ' || c == '\r' || c == '\n') //ubaceno
                        latin += c;
                }
                else
                {
                    letter += c;
                }
            }
            if (latinToMorse.ContainsValue(letter))
            {
                string key = latinToMorse.FirstOrDefault(x => x.Value == letter).Key;
                latin += key;
            }
            ExtractSpaces();
        }

        private void ExtractSpaces()
        {
            string tmp = "";
            for (int i = 0; i < latin.Length; i++)
            {
                if (latin[i] == ' ')
                    if (latin[i + 1] == ' ')
                    {
                        i += 2;
                        if (latin[i] == ' ')
                            if (latin[i + 1] == ' ')
                                i += 1;
                    }
                tmp += latin[i];
            }
            latin = tmp;
        }
    }
}