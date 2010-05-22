using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public delegate void ProgressMessageHandler(TarArchive archive, TarEntry entry, string message);


	public class TarArchive : IDisposable
	{
		public event ProgressMessageHandler ProgressMessageEvent;
		
		protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
		{
			if (ProgressMessageEvent != null) {
				ProgressMessageEvent(this, entry, message);
			}
		}
		
		#region Constructors

		protected TarArchive()
		{
		}
		
	
		protected TarArchive(TarInputStream stream)
		{
			if ( stream == null ) {
				throw new ArgumentNullException("stream");
			}
			
			tarIn = stream;
		}
		
	
		protected TarArchive(TarOutputStream stream)
		{
			if ( stream == null ) {
				throw new ArgumentNullException("stream");
			}
			
			tarOut = stream;
		}
		#endregion
		
		#region Static factory methods
		public static TarArchive CreateInputTarArchive(Stream inputStream)
		{
			if ( inputStream == null ) {
				throw new ArgumentNullException("inputStream");
			}

			TarInputStream tarStream = inputStream as TarInputStream;

			if ( tarStream != null ) {
				return new TarArchive(tarStream);
			}
			else {
				return CreateInputTarArchive(inputStream, TarBuffer.DefaultBlockFactor);
			}
		}
		

		public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
		{
			if ( inputStream == null ) {
				throw new ArgumentNullException("inputStream");
			}

			if ( inputStream is TarInputStream ) {
				throw new ArgumentException("TarInputStream not valid");
			}
			
			return new TarArchive(new TarInputStream(inputStream, blockFactor));
		}
		

		public static TarArchive CreateOutputTarArchive(Stream outputStream)
		{
			if ( outputStream == null ) {
				throw new ArgumentNullException("outputStream");
			}
			TarOutputStream tarStream = outputStream as TarOutputStream;
			if ( tarStream != null ) {
				return new TarArchive(tarStream);
			}
			else {
				return CreateOutputTarArchive(outputStream, TarBuffer.DefaultBlockFactor);
			}
		}

	
		public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
		{
			if ( outputStream == null ) {
				throw new ArgumentNullException("outputStream");
			}

			if ( outputStream is TarOutputStream ) {
				throw new ArgumentException("TarOutputStream is not valid");
			}

			return new TarArchive(new TarOutputStream(outputStream, blockFactor));
		}
		#endregion
		

		public void SetKeepOldFiles(bool keepOldFiles)
		{
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			this.keepOldFiles = keepOldFiles;
		}
		

		public bool AsciiTranslate
		{
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return asciiTranslate;
			}
			
			set { 
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				asciiTranslate = value; 
			}
		
		}
		

		[Obsolete("Use the AsciiTranslate property")]
		public void SetAsciiTranslation(bool asciiTranslate)
		{
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			this.asciiTranslate = asciiTranslate;
		}


		public string PathPrefix
		{
			get { 
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return pathPrefix;
			}
			
			set { 
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				pathPrefix = value;
			}
		
		}

		public string RootPath
		{
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return rootPath;
			}

			set {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				rootPath = value;
			}
		}

		public void SetUserInfo(int userId, string userName, int groupId, string groupName)
		{
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			this.userId    = userId;
			this.userName  = userName;
			this.groupId   = groupId;
			this.groupName = groupName;
			applyUserInfoOverrides = true;
		}
	
		public bool ApplyUserInfoOverrides
		{
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return applyUserInfoOverrides;
			}

			set {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				applyUserInfoOverrides = value;
			}
		}


		public int UserId {
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return userId;
			}
		}
		

		public string UserName {
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return userName;
			}
		}
		

		public int GroupId {
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return this.groupId;
			}
		}
		

		public string GroupName {
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
			
				return this.groupName;
			}
		}
		

		public int RecordSize {
			get {
				if ( isDisposed ) {
					throw new ObjectDisposedException("TarArchive");
				}
				
				if (tarIn != null) {
					return tarIn.RecordSize;
				} else if (tarOut != null) {
					return tarOut.RecordSize;
				}
				return TarBuffer.DefaultRecordSize;
			}
		}

		[Obsolete("Use Close instead")]
		public void CloseArchive()
		{
			Close();
		}
		

		public void ListContents()
		{
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			while (true) {
				TarEntry entry = this.tarIn.GetNextEntry();
				
				if (entry == null) {
					break;
				}
				OnProgressMessageEvent(entry, null);
			}
		}
		

		public void ExtractContents(string destinationDirectory)
		{
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			while (true) {
				TarEntry entry = this.tarIn.GetNextEntry();
				
				if (entry == null) {
					break;
				}
				
				this.ExtractEntry(destinationDirectory, entry);
			}
		}
		

		void ExtractEntry(string destDir, TarEntry entry)
		{
			OnProgressMessageEvent(entry, null);
			
			string name = entry.Name;
			
			if (Path.IsPathRooted(name) == true) {

				name = name.Substring(Path.GetPathRoot(name).Length);
			}
			
			name = name.Replace('/', Path.DirectorySeparatorChar);
			
			string destFile = Path.Combine(destDir, name);
			
			if (entry.IsDirectory) {
				EnsureDirectoryExists(destFile);
			} else {
				string parentDirectory = Path.GetDirectoryName(destFile);
				EnsureDirectoryExists(parentDirectory);
				
				bool process = true;
				FileInfo fileInfo = new FileInfo(destFile);
				if (fileInfo.Exists) {
					if (this.keepOldFiles) {
						OnProgressMessageEvent(entry, "Destination file already exists");
						process = false;
					} else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0) {
						OnProgressMessageEvent(entry, "Destination file already exists, and is read-only");
						process = false;
					}
				}
				
				if (process) {
					bool asciiTrans = false;
					
					Stream outputStream = File.Create(destFile);
					if (this.asciiTranslate) {
						asciiTrans = !IsBinary(destFile);
					}
					
					StreamWriter outw = null;
					if (asciiTrans) {
						outw = new StreamWriter(outputStream);
					}
					
					byte[] rdbuf = new byte[32 * 1024];
					
					while (true) {
						int numRead = this.tarIn.Read(rdbuf, 0, rdbuf.Length);
						
						if (numRead <= 0) {
							break;
						}
						
						if (asciiTrans) {
							for (int off = 0, b = 0; b < numRead; ++b) {
								if (rdbuf[b] == 10) {
									string s = Encoding.ASCII.GetString(rdbuf, off, (b - off));
									outw.WriteLine(s);
									off = b + 1;
								}
							}
						} else {
							outputStream.Write(rdbuf, 0, numRead);
						}
					}
					
					if (asciiTrans) {
						outw.Close();
					} else {
						outputStream.Close();
					}
				}
			}
		}

		
		public void WriteEntry(TarEntry sourceEntry, bool recurse)
		{
			if ( sourceEntry == null ) {
				throw new ArgumentNullException("sourceEntry");
			}
			
			if ( isDisposed ) {
				throw new ObjectDisposedException("TarArchive");
			}
			
			try
			{
				if ( recurse ) {
					TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName,
											   sourceEntry.GroupId, sourceEntry.GroupName);
				}
				WriteEntryCore(sourceEntry, recurse);
			}
			finally
			{
				if ( recurse ) {
					TarHeader.RestoreSetValues();
				}
			}
		}
		
		
		void WriteEntryCore(TarEntry sourceEntry, bool recurse)
		{
			bool asciiTrans = false;
			
			string tempFileName = null;
			string entryFilename   = sourceEntry.File;
			
			TarEntry entry = (TarEntry)sourceEntry.Clone();

			if ( applyUserInfoOverrides ) {
				entry.GroupId = groupId;
				entry.GroupName = groupName;
				entry.UserId = userId;
				entry.UserName = userName;
			}
			
			OnProgressMessageEvent(entry, null);
			
			if (this.asciiTranslate && !entry.IsDirectory) {
				asciiTrans = !IsBinary(entryFilename);

				if (asciiTrans) {
					tempFileName = Path.GetTempFileName();
					
					using (StreamReader inStream  = File.OpenText(entryFilename)) {
						using (Stream outStream = File.Create(tempFileName)) {
						
							while (true) {
								string line = inStream.ReadLine();
								if (line == null) {
									break;
								}
								byte[] data = Encoding.ASCII.GetBytes(line);
								outStream.Write(data, 0, data.Length);
								outStream.WriteByte((byte)'\n');
							}
							
							outStream.Flush();
						}
					}
					
					entry.Size = new FileInfo(tempFileName).Length;
					entryFilename = tempFileName;
				}
			}
			
			string newName = null;
		
			if (this.rootPath != null) {
				if (entry.Name.StartsWith(this.rootPath)) {
					newName = entry.Name.Substring(this.rootPath.Length + 1 );
				}
			}
			
			if (this.pathPrefix != null) {
				newName = (newName == null) ? this.pathPrefix + "/" + entry.Name : this.pathPrefix + "/" + newName;
			}
			
			if (newName != null) {
				entry.Name = newName;
			}
			
			tarOut.PutNextEntry(entry);
			
			if (entry.IsDirectory) {
				if (recurse) {
					TarEntry[] list = entry.GetDirectoryEntries();
					for (int i = 0; i < list.Length; ++i) {
						WriteEntryCore(list[i], recurse);
					}
				}
			}
			else {
				using (Stream inputStream = File.OpenRead(entryFilename)) {
					int numWritten = 0;
					byte[] localBuffer = new byte[32 * 1024];
					while (true) {
						int numRead = inputStream.Read(localBuffer, 0, localBuffer.Length);
						
						if (numRead <=0) {
							break;
						}
						
						tarOut.Write(localBuffer, 0, numRead);
						numWritten +=  numRead;
					}
				}
				
				if ( (tempFileName != null) && (tempFileName.Length > 0) ) {
					File.Delete(tempFileName);
				}
				
				tarOut.CloseEntry();
			}
		}

		
		protected virtual void Dispose(bool disposing)
		{
			if ( !isDisposed ) {
				isDisposed = true;
				if ( disposing ) {
					if ( tarOut != null ) {
						tarOut.Flush();
						tarOut.Close();
					}
		
					if ( tarIn != null ) {
						tarIn.Close();
					}
				}
			}
		}
		
		
		public virtual void Close()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		
		~TarArchive()
		{
			Dispose(false);
		}
		
		#region IDisposable Members

	
		void IDisposable.Dispose()
		{
			Close();
		}

		#endregion
		
		static void EnsureDirectoryExists(string directoryName)
		{
			if (!Directory.Exists(directoryName)) {
				try {
					Directory.CreateDirectory(directoryName);
				}
				catch (Exception e) {
					throw new TarException("Exception creating directory '" + directoryName + "', " + e.Message, e);
				}
			}
		}
		
		
		static bool IsBinary(string filename)
		{
			using (FileStream fs = File.OpenRead(filename))
			{
				int sampleSize = System.Math.Min(4096, (int)fs.Length);
				byte[] content = new byte[sampleSize];
			
				int bytesRead = fs.Read(content, 0, sampleSize);
			
				for (int i = 0; i < bytesRead; ++i) {
					byte b = content[i];
					if ( (b < 8) || ((b > 13) && (b < 32)) || (b == 255) ) {
						return true;
					}
				}
			}
			return false;
		}		
		
		#region Instance Fields
		bool keepOldFiles;
		bool asciiTranslate;
		
		int    userId;
		string userName = string.Empty;
		int    groupId;
		string groupName = string.Empty;
		
		string rootPath;
		string pathPrefix;
		
		bool applyUserInfoOverrides;
		
		TarInputStream  tarIn;
		TarOutputStream tarOut;
		bool isDisposed;
		#endregion
	}
}
