using System;
using System.IO;
using System.Text;

using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{

	public class WindowsNameTransform : INameTransform
	{

		public WindowsNameTransform(string baseDirectory)
		{
			if ( baseDirectory == null ) {
				throw new ArgumentNullException("baseDirectory", "Directory name is invalid");
			}

			BaseDirectory = baseDirectory;
		}
		

		public WindowsNameTransform()
		{

		}
		

		public string BaseDirectory
		{
			get { return baseDirectory_; }
			set {
				if ( value == null ) {
					throw new ArgumentNullException("value");
				}

				baseDirectory_ = Path.GetFullPath(value);
			}
		}
		

		public bool TrimIncomingPaths
		{
			get { return trimIncomingPaths_; }
			set { trimIncomingPaths_ = value; }
		}
		
	
		public string TransformDirectory(string name)
		{
			name = TransformFile(name);
			if (name.Length > 0) {
				while ( name.EndsWith(@"\") ) {
					name = name.Remove(name.Length - 1, 1);
				}
			}
			else {
				throw new ZipException("Cannot have an empty directory name");
			}
			return name;
		}
		

		public string TransformFile(string name)
		{
			if (name != null) {
				name = MakeValidName(name, replacementChar_);
				
				if ( trimIncomingPaths_ ) {
					name = Path.GetFileName(name);
				}
				

				if ( baseDirectory_ != null ) {
					name = Path.Combine(baseDirectory_, name);
				}	
			}
			else {
				name = string.Empty;
			}
			return name;
		}
		

		public static bool IsValidName(string name)
		{
			bool result = 
				(name != null) &&
				(name.Length <= MaxPath) &&
				(string.Compare(name, MakeValidName(name, '_')) == 0)
				;

			return result;
		}


		static WindowsNameTransform()
		{
			char[] invalidPathChars;

#if NET_1_0 || NET_1_1 || NETCF_1_0
			invalidPathChars = Path.InvalidPathChars;
#else
			invalidPathChars = Path.GetInvalidPathChars();
#endif
			int howMany = invalidPathChars.Length + 3;

			InvalidEntryChars = new char[howMany];
			Array.Copy(invalidPathChars, 0, InvalidEntryChars, 0, invalidPathChars.Length);
			InvalidEntryChars[howMany - 1] = '*';
			InvalidEntryChars[howMany - 2] = '?';
			InvalidEntryChars[howMany - 2] = ':';
		}


		public static string MakeValidName(string name, char replacement)
		{
			if ( name == null ) {
				throw new ArgumentNullException("name");
			}
			
			name = WindowsPathUtils.DropPathRoot(name.Replace("/", @"\"));


			while ( (name.Length > 0) && (name[0] == '\\')) {
				name = name.Remove(0, 1);
			}


			while ( (name.Length > 0) && (name[name.Length - 1] == '\\')) {
				name = name.Remove(name.Length - 1, 1);
			}


			int index = name.IndexOf(@"\\");
			while (index >= 0) {
				name = name.Remove(index, 1);
				index = name.IndexOf(@"\\");
			}


			index = name.IndexOfAny(InvalidEntryChars);
			if (index >= 0) {
				StringBuilder builder = new StringBuilder(name);

				while (index >= 0 ) {
					builder[index] = replacement;

					if (index >= name.Length) {
						index = -1;
					}
					else {
						index = name.IndexOfAny(InvalidEntryChars, index + 1);
					}
				}
				name = builder.ToString();
			}
			

			if ( name.Length > MaxPath ) {
				throw new PathTooLongException();
			}
					
			return name;
		}


		public char Replacement
		{
			get { return replacementChar_; }
			set { 
				for ( int i = 0; i < InvalidEntryChars.Length; ++i ) {
					if ( InvalidEntryChars[i] == value ) {
						throw new ArgumentException("invalid path character");
					}
				}

				if ((value == '\\') || (value == '/')) {
					throw new ArgumentException("invalid replacement character");
				}
				
				replacementChar_ = value;
			}
		}
		

		const int MaxPath = 260;
		
		#region Instance Fields
		string baseDirectory_;
		bool trimIncomingPaths_;
		char replacementChar_ = '_';
		#endregion
		
		#region Class Fields
		static readonly char[] InvalidEntryChars;
		#endregion
	}
}
