using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace ICSharpCode.SharpZipLib.Core
{
	public class NameFilter : IScanFilter
	{
		#region Constructors

		public NameFilter(string filter)
		{
			filter_ = filter;
			inclusions_ = new ArrayList();
			exclusions_ = new ArrayList();
			Compile();
		}
		#endregion

	
		public static bool IsValidExpression(string expression)
		{
			bool result = true;
			try {
				Regex exp = new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			}
			catch (ArgumentException) {
				result = false;
			}
			return result;
		}

		
		public static bool IsValidFilterExpression(string toTest)
		{
			if ( toTest == null ) {
				throw new ArgumentNullException("toTest");
			}

			bool result = true;

			try {
				string[] items = SplitQuoted(toTest);
				for (int i = 0; i < items.Length; ++i) {
					if ((items[i] != null) && (items[i].Length > 0)) {
						string toCompile;

						if (items[i][0] == '+') {
							toCompile = items[i].Substring(1, items[i].Length - 1);
						}
						else if (items[i][0] == '-') {
							toCompile = items[i].Substring(1, items[i].Length - 1);
						}
						else {
							toCompile = items[i];
						}

						Regex testRegex = new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
			}
			catch (ArgumentException) {
				result = false;
			}

			return result;
		}

		
		public static string[] SplitQuoted(string original)
		{
			char escape = '\\';
			char[] separators = { ';' };

			ArrayList result = new ArrayList();

			if ((original != null) && (original.Length > 0)) {
				int endIndex = -1;
				StringBuilder b = new StringBuilder();

				while (endIndex < original.Length) {
					endIndex += 1;
					if (endIndex >= original.Length) {
						result.Add(b.ToString());
					}
					else if (original[endIndex] == escape) {
						endIndex += 1;
						if (endIndex >= original.Length) {
#if NETCF_1_0
							throw new ArgumentException("Missing terminating escape character");
#else
							throw new ArgumentException("Missing terminating escape character", "original");
#endif
						}

						b.Append(original[endIndex]);
					}
					else {
						if (Array.IndexOf(separators, original[endIndex]) >= 0) {
							result.Add(b.ToString());
							b.Length = 0;
						}
						else {
							b.Append(original[endIndex]);
						}
					}
				}
			}

			return (string[])result.ToArray(typeof(string));
		}

	
		public override string ToString()
		{
			return filter_;
		}

		
		public bool IsIncluded(string name)
		{
			bool result = false;
			if ( inclusions_.Count == 0 ) {
				result = true;
			}
			else {
				foreach ( Regex r in inclusions_ ) {
					if ( r.IsMatch(name) ) {
						result = true;
						break;
					}
				}
			}
			return result;
		}

	
		public bool IsExcluded(string name)
		{
			bool result = false;
			foreach ( Regex r in exclusions_ ) {
				if ( r.IsMatch(name) ) {
					result = true;
					break;
				}
			}
			return result;
		}

		#region IScanFilter Members
		
		public bool IsMatch(string name)
		{
			return (IsIncluded(name) == true) && (IsExcluded(name) == false);
		}
		#endregion

		
		void Compile()
		{
			
			if ( filter_ == null ) {
				return;
			}

			string[] items = SplitQuoted(filter_);
			for ( int i = 0; i < items.Length; ++i ) {
				if ( (items[i] != null) && (items[i].Length > 0) ) {
					bool include = (items[i][0] != '-');
					string toCompile;

					if ( items[i][0] == '+' ) {
						toCompile = items[i].Substring(1, items[i].Length - 1);
					}
					else if ( items[i][0] == '-' ) {
						toCompile = items[i].Substring(1, items[i].Length - 1);
					}
					else {
						toCompile = items[i];
					}

				
					if ( include ) {
						inclusions_.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
					else {
						exclusions_.Add(new Regex(toCompile, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
				}
			}
		}

		#region Instance Fields
		string filter_;
		ArrayList inclusions_;
		ArrayList exclusions_;
		#endregion
	}
}
