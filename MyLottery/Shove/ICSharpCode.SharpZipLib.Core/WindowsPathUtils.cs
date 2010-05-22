using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public abstract class WindowsPathUtils
	{
		public  WindowsPathUtils()
		{
		}
		
		public static string DropPathRoot(string path)
		{
			string result = path;
			
			if ( (path != null) && (path.Length > 0) ) {
				if ((path[0] == '\\') || (path[0] == '/')) {
					if ((path.Length > 1) && ((path[1] == '\\') || (path[1] == '/'))) {
						int index = 2;
						int elements = 2;
						while ((index <= path.Length) &&
							(((path[index] != '\\') && (path[index] != '/')) || (--elements > 0))) {
							index++;
						}

						index++;

						if (index < path.Length) {
							result = path.Substring(index);
						}
						else {
							result = "";
						}
					}
				}
				else if ((path.Length > 1) && (path[1] == ':')) {
					int dropCount = 2;
					if ((path.Length > 2) && ((path[2] == '\\') || (path[2] == '/'))) {
						dropCount = 3;
					}
					result = result.Remove(0, dropCount);
				}
			}
			return result;
		}
	}
}
