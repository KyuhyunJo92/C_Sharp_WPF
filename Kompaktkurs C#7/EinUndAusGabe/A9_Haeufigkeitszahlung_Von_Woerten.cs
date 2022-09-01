using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Ein_undAusgebe
{
    class A9_Haeufigkeitszahlung_Von_Woerten
    {
        private string _path = @"c:\temp\19_5_Aufgabe9_Woerten.txt";

        private string ReadFile()
        {
            string dummyString = "";
            FileStream fsReadFile = new FileStream(_path, FileMode.Open);

            fsReadFile.Seek(0, SeekOrigin.Begin);

            int ch = fsReadFile.ReadByte();

            while (ch >= 0)
            {
                dummyString += (char)ch;
                ch = fsReadFile.ReadByte();
            }
            return dummyString;
        }

        private string[] MakeWordArray(string ReadWords)
        {
            string[] dummyStrArr = ReadWords.Split(' ', '\n', '\r');
            return dummyStrArr;
        }
        
        private string[] ShuffleDeck(IEnumerable<string> wordDeck)
        {
            string[] shuffledDeck = wordDeck.OrderBy(a => Guid.NewGuid()).ToArray();
            return shuffledDeck;
        }

        private Dictionary<string, int> KeyIsWordValueIsHaeufigkeitzahl(string[] shuffledDeck)
        {
            
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < shuffledDeck.Length; i++)
            {
                string checkWord = shuffledDeck[i];
                if (dic.ContainsKey(checkWord))
                {
                    dic[checkWord] =  (int)dic[checkWord] + 1;
                    //_sList[_sList.IndexOfKey(checkWord)] = new KeyValuePair<string, int>(checkWord, _sList.IndexOfKey(checkWord)+1); 
                }
                else
                {
                    dic.Add(checkWord, 1);
                    //_sList.Add(checkWord, _sList.IndexOfKey(checkWord));
                }
            }
            return dic;
        }
        KeyValuePair<string, int> kvp;

        private SortedList<string,int> SortDenDictionaryMitDerHaeufigkeit(Dictionary<string, int> dic)
        {
            SortedList<string,int> sList = new SortedList<string, int>(dic);

            //for(int i = 0; i<Dic.Count; i++)
            //{
            //    _sList.Add( Dic.Values.ElementAt(i),Dic.Keys.ElementAt(i));
            //}

            //foreach (KeyValuePair<string, int> kvp in Dic)
            //{
            //    sList.Add(kvp.Value, kvp.Key);
            //}

            //_sList.OrderBy<string, int>(Func < KeyValuePair<string, int>, int > int);
            
            return sList;
        }



        //private SortedList<int,string> sortDenDictionaryMitDerHaeufigkeit(Dictionary<string, int> Dic)
        //{
        //    SortedList<int, string> sList = new SortedList<int, string>();

        //    //for(int i = 0; i<Dic.Count; i++)
        //    //{
        //    //    _sList.Add( Dic.Values.ElementAt(i),Dic.Keys.ElementAt(i));
        //    //}

        //    foreach(KeyValuePair<string,int> kvp in Dic)
        //    {
        //        sList.Add(kvp.Value, kvp.Key);
        //    }

        //    //_sList.OrderBy<string, int>(Func < KeyValuePair<string, int>, int > int);



        //    return sList;
        //}

        public SortedList<string,int> Run()
        {
            string readFile = ReadFile();
            string[] fruits = MakeWordArray(readFile);
            string[] shuffledFruits = ShuffleDeck(fruits);
            Dictionary<string, int> frequencyOfFruit = KeyIsWordValueIsHaeufigkeitzahl(shuffledFruits);
            SortedList<string, int> sortedByFrequency = SortDenDictionaryMitDerHaeufigkeit(frequencyOfFruit);
            
            return sortedByFrequency;
        }  
    }
}

/*
 * static void Main()
        {
            A9_Haeufigkeitszahlung_Von_Woerten A9 = new A9_Haeufigkeitszahlung_Von_Woerten();

            foreach(KeyValuePair<string,int> kvp in A9.Run())
            {
                Console.WriteLine("Obst : {0}, HaeufigKeitszahlung : {1}", kvp.Key, kvp.Value);
            }  
        }
 
     */
         
/*
 * List<string> _wordDeck = new List<string>();
            for (int i = 0; i < _dummyStrArr.Length; i++)
            {
                _wordDeck[i] = _dummyStrArr[i];
            }
     */

/*SortedList _sList = new SortedList();

        for (int i = 0; i < shuffledDeck.Length; i++)
        {
            string checkWord = shuffledDeck[i];
            if (_sList.Contains(checkWord))
            {
                _sList.SetByIndex(_sList.IndexOfKey(checkWord), (int)_sList[checkWord]+1);
                //_sList[_sList.IndexOfKey(checkWord)] = new KeyValuePair<string, int>(checkWord, _sList.IndexOfKey(checkWord)+1); 
            }
            else
            {
                _sList.Add(checkWord, 1);
                //_sList.Add(checkWord, _sList.IndexOfKey(checkWord));
            }
        }



        return _sList;   */
