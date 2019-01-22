using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;


namespace VolarelaNS {
	public static class TextManager{
		///<summary>
		///Return the original string without the first word before a point or a space. If there is no point or space in the string then nothing is deleted.
		///</summary>

		public static string DeleteFirstWord(this string _orgText){
			var _append = 0;
			StringBuilder _finalText = new StringBuilder();
			foreach(var characters in _orgText){
				_append ++;
				if(characters == ' '
				|| characters == '.'){
					
					for (int i = _append; i < _orgText.Length; i++)
					{
						_finalText.Append(_orgText[i]);
					}
					_orgText = _finalText.ToString();
					return _orgText;
				}
			}

			return _orgText;
		}
		
		///<summary>
		///Return true if the string words is present in the string.
		///</summary>
		public static bool IsAWordInAString ( this string _str, string word){
			int wordChar = 0;
			foreach (var _char in _str)
			{
				if (_char == word[wordChar]){
					wordChar++;
				}else{
					wordChar = 0;
				}
				if (wordChar == word.Length){
					return true;
				}
			}
			return false;
		}
		///<summary>
		///Convert a long string into a list of string
		///</summary>
		///<para name=characterMax> The max caracter that contain each string of the list. </para>x
		public static List<string> ConvertLargeText (this string text, int characterMax = 20){
			var _list = new List<string>();
			if(text.Length == 0) {return _list;}
			char[] separator = {'.','?',':'};
			while (text.Length>=characterMax){
				var _characterIndex = characterMax;
				if (text[characterMax] != separator[0]
				||  text[characterMax] != separator[1]
				||  text[characterMax] != separator[2])
				{
					for (int i = characterMax; i > 0; i--)
					{
						if (text[i] == separator[0]
						||	text[i] == separator[1]
						||	text[i] == separator[2])
						{
							_characterIndex = i;
							break;		
						}
					}
					_list.Add(text.Substring(0,_characterIndex));
					text = text.Substring(_characterIndex+1);
				}else{
					if (text[_characterIndex] == separator[0]
					||	text[_characterIndex] == separator[1]
					||  text[_characterIndex] == separator[2])
					{
						_characterIndex++;
					}
					_list.Add(text.Substring(0,_characterIndex));
					text = text.Substring(_characterIndex);
				}
			}
			if(text.Length<=characterMax){
				_list.Add(text);
			}
			return _list;
		}

		public static string GetFirstWord (this string text)
		{
			if (text.Length == 0)
			{
				return "";
			}
			var returnText = "";
			var init = 0;
			if(text[0] == ' ')
			{
				init = 1;	
			}

			for (int i = init; i < text.Length; i++)
			{
				if(text[i] == ' ')
				{
					break;
				}
				else
				{
					returnText += text[i];
				}
			}
			return returnText;
		}

		public static string GetLastWord (this string text)
		{
			var returnText = "";
			var returnTextInRightOrder = "";
			for (int i = text.Length-1; i >= 0; i--)
			{
				if(text[i] == ' ')
				{
					break;
				}
				else
				{
				
					returnText += text[i];
				}
			}
			
			for (int i = returnText.Length-1 ; i >= 0; i--)
			{
				returnTextInRightOrder += returnText[i];
			}
			
			return returnTextInRightOrder;
		}

		public static bool EqualTextWithoutCase (this string proposition, string rightAnswer)
		{
			if(proposition.Length != rightAnswer.Length) {return false;}

			var ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var alpha = "abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < proposition.Length; i++)
			{
				var actualInt = 26;
				for (var l = 0; l< ALPHA.Length; l++)
				{
					if(proposition[i] == ALPHA[l]) {actualInt = l;}
				}
				for (var l = 0; l< alpha.Length; l++)
				{
					if(proposition[i] == alpha[l]) {actualInt = l;}
				}

				if(proposition[i]!=alpha[actualInt])
				if(proposition[i]!=ALPHA[actualInt])
				if(proposition[i]!=rightAnswer[i])
				{
					return false;
				}
			}
			return true;
		}
	}


}
