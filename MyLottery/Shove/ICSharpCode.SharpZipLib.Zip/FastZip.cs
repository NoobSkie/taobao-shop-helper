

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class FastZipEvents
	{
		public ProcessDirectoryHandler ProcessDirectory;
		
		public ProcessFileHandler ProcessFile;

		public ProgressHandler Progress;

		public CompletedFileHandler CompletedFile;
		
		public DirectoryFailureHandler DirectoryFailure;
		
		public FileFailureHandler FileFailure;
		
		public bool OnDirectoryFailure(string directory, Exception e)
		{
			bool result = false;
			DirectoryFailureHandler handler = DirectoryFailure;

			if ( handler != null ) {
				ScanFailureEventArgs args = new ScanFailureEventArgs(directory, e);
				handler(this, args);
				result = args.ContinueRunning;
			}
			return result;
		}
		

		public bool OnFileFailure(string file, Exception e)
		{
			FileFailureHandler handler = FileFailure;
            bool result = (handler != null);

			if ( result ) {
				ScanFailureEventArgs args = new ScanFailureEventArgs(file, e);
				handler(this, args);
				result = args.ContinueRunning;
			}
			return result;
		}
		

		public bool OnProcessFile(string file)
		{
			bool result = true;
			ProcessFileHandler handler = ProcessFile;

			if ( handler != null ) {
				ScanEventArgs args = new ScanEventArgs(file);
				ProcessFile(this, args);
				result = args.ContinueRunning;
			}
			return result;
		}


		public bool OnCompletedFile(string file)
		{
			bool result = true;
			CompletedFileHandler handler = CompletedFile;
			if ( handler != null ) {
				ScanEventArgs args = new ScanEventArgs(file);
				handler(this, args);
				result = args.ContinueRunning;
			}
			return result;
		}
		

		public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			bool result = true;
			ProcessDirectoryHandler handler = ProcessDirectory;
			if ( handler != null ) {
				DirectoryEventArgs args = new DirectoryEventArgs(directory, hasMatchingFiles);
				handler(this, args);
				result = args.ContinueRunning;
			}
			return result;
		}


		public TimeSpan ProgressInterval
		{
			get { return progressInterval_; }
			set { progressInterval_ = value; }
		}

		#region Instance Fields
		TimeSpan progressInterval_ = TimeSpan.FromSeconds(3);
		#endregion
	}
	

	public class FastZip
	{
		#region Enumerations

		public enum Overwrite 
		{
			Prompt,
			Never,
			Always
		}
		#endregion
		
		#region Constructors

		public FastZip()
		{
		}

		public FastZip(FastZipEvents events)
		{
			events_ = events;
		}
		#endregion
		
		#region Properties

		public bool CreateEmptyDirectories
		{
			get { return createEmptyDirectories_; }
			set { createEmptyDirectories_ = value; }
		}

#if !NETCF_1_0

		public string Password
		{
			get { return password_; }
			set { password_ = value; }
		}
#endif


		public INameTransform NameTransform
		{
			get { return entryFactory_.NameTransform; }
			set {
				entryFactory_.NameTransform = value;
			}
		}


		public IEntryFactory EntryFactory
		{
			get { return entryFactory_; }
			set {
				if ( value == null ) {
					entryFactory_ = new ZipEntryFactory();
				}
				else {
					entryFactory_ = value;
				}
			}
		}
		

		public UseZip64 UseZip64
		{
			get { return useZip64_; }
			set { useZip64_ = value; }
		}
		

		public bool RestoreDateTimeOnExtract
		{
			get {
				return restoreDateTimeOnExtract_;
			}
			set {
				restoreDateTimeOnExtract_ = value;
			}
		}
		

		public bool RestoreAttributesOnExtract
		{
			get { return restoreAttributesOnExtract_; }
			set { restoreAttributesOnExtract_ = value; }
		}
		#endregion
		
		#region Delegates

		public delegate bool ConfirmOverwriteDelegate(string fileName);
		#endregion
		
		#region CreateZip

		public void CreateZip(string zipFileName, string sourceDirectory, 
			bool recurse, string fileFilter, string directoryFilter)
		{
			CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
		}

		public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
		{
			CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, null);
		}


		public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
			NameTransform = new ZipNameTransform(sourceDirectory);
			sourceDirectory_ = sourceDirectory;

			using ( outputStream_ = new ZipOutputStream(outputStream) ) {

#if !NETCF_1_0
				if ( password_ != null ) {
					outputStream_.Password = password_;
				}
#endif

				outputStream_.UseZip64 = UseZip64;
				FileSystemScanner scanner = new FileSystemScanner(fileFilter, directoryFilter);
				scanner.ProcessFile += new ProcessFileHandler(ProcessFile);
				if ( this.CreateEmptyDirectories ) {
					scanner.ProcessDirectory += new ProcessDirectoryHandler(ProcessDirectory);
				}
				
				if (events_ != null) {
					if ( events_.FileFailure != null ) {
						scanner.FileFailure += events_.FileFailure;
					}

					if ( events_.DirectoryFailure != null ) {
						scanner.DirectoryFailure += events_.DirectoryFailure;
					}
				}

				scanner.Scan(sourceDirectory, recurse);
			}
		}

		#endregion
		
		#region ExtractZip

		public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter) 
		{
			ExtractZip(zipFileName, targetDirectory, Overwrite.Always, null, fileFilter, null, restoreDateTimeOnExtract_);
		}
		

		public void ExtractZip(string zipFileName, string targetDirectory, 
							   Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, 
							   string fileFilter, string directoryFilter, bool restoreDateTime)
		{
			if ( (overwrite == Overwrite.Prompt) && (confirmDelegate == null) ) {
				throw new ArgumentNullException("confirmDelegate");
			}

			continueRunning_ = true;
			overwrite_ = overwrite;
			confirmDelegate_ = confirmDelegate;
			extractNameTransform_ = new WindowsNameTransform(targetDirectory);
			
			fileFilter_ = new NameFilter(fileFilter);
			directoryFilter_ = new NameFilter(directoryFilter);
			restoreDateTimeOnExtract_ = restoreDateTime;
			
			using ( zipFile_ = new ZipFile(zipFileName) ) {

#if !NETCF_1_0
				if (password_ != null) {
					zipFile_.Password = password_;
				}
#endif

				System.Collections.IEnumerator enumerator = zipFile_.GetEnumerator();
				while ( continueRunning_ && enumerator.MoveNext()) {
					ZipEntry entry = (ZipEntry) enumerator.Current;
					if ( entry.IsFile )
					{
						if ( directoryFilter_.IsMatch(Path.GetDirectoryName(entry.Name)) && fileFilter_.IsMatch(entry.Name) ) {
							ExtractEntry(entry);
						}
					}
					else if ( entry.IsDirectory ) {
						if ( directoryFilter_.IsMatch(entry.Name) && CreateEmptyDirectories ) {
							ExtractEntry(entry);
						}
					}
					else {
					}
				}
			}
		}
		#endregion
		
		#region Internal Processing
		void ProcessDirectory(object sender, DirectoryEventArgs e)
		{
			if ( !e.HasMatchingFiles && CreateEmptyDirectories ) {
				if ( events_ != null ) {
					events_.OnProcessDirectory(e.Name, e.HasMatchingFiles);
				}
				
				if ( e.ContinueRunning ) {
					if (e.Name != sourceDirectory_) {
						ZipEntry entry = entryFactory_.MakeDirectoryEntry(e.Name);
						outputStream_.PutNextEntry(entry);
					}
				}
			}
		}
		
		void ProcessFile(object sender, ScanEventArgs e)
		{
			if ( (events_ != null) && (events_.ProcessFile != null) ) {
				events_.ProcessFile(sender, e);
			}
			
			if ( e.ContinueRunning ) {
				using( FileStream stream=File.OpenRead(e.Name) ) {
					ZipEntry entry=entryFactory_.MakeFileEntry(e.Name);
					outputStream_.PutNextEntry(entry);
					AddFileContents(e.Name, stream);
				}
			}
		}

		void AddFileContents(string name, Stream stream)
		{
			if( stream==null ) {
				throw new ArgumentNullException("stream");
			}

			if( buffer_==null ) {
				buffer_=new byte[4096];
			}

			if( (events_!=null)&&(events_.Progress!=null) ) {
				StreamUtils.Copy(stream, outputStream_, buffer_,
					events_.Progress, events_.ProgressInterval, this, name);
			}
			else {
				StreamUtils.Copy(stream, outputStream_, buffer_);
			}

			if( events_!=null ) {
				continueRunning_=events_.OnCompletedFile(name);
			}
		}

		void ExtractFileEntry(ZipEntry entry, string targetName)
		{
			bool proceed = true;
			if ( overwrite_ != Overwrite.Always ) {
				if ( File.Exists(targetName) ) {
					if ( (overwrite_ == Overwrite.Prompt) && (confirmDelegate_ != null) ) {
						proceed = confirmDelegate_(targetName);
					}
					else {
						proceed = false;
					}
				}
			}
			
			if ( proceed ) {
				if ( events_ != null ) {
					continueRunning_ = events_.OnProcessFile(entry.Name);
				}
			
				if ( continueRunning_ ) {
					try {
						using ( FileStream outputStream = File.Create(targetName) ) {
							if ( buffer_ == null ) {
								buffer_ = new byte[4096];
							}
							if ((events_ != null) && (events_.Progress != null))
							{
								StreamUtils.Copy(zipFile_.GetInputStream(entry), outputStream, buffer_,
									events_.Progress, events_.ProgressInterval, this, entry.Name, entry.Size);
							}
							else
							{
								StreamUtils.Copy(zipFile_.GetInputStream(entry), outputStream, buffer_);
							}
							
							if (events_ != null) {
								continueRunning_ = events_.OnCompletedFile(entry.Name);
							}
						}

#if !NETCF_1_0 && !NETCF_2_0
						if ( restoreDateTimeOnExtract_ ) {
							File.SetLastWriteTime(targetName, entry.DateTime);
						}
						
						if ( RestoreAttributesOnExtract && entry.IsDOSEntry && (entry.ExternalFileAttributes != -1)) {
							FileAttributes fileAttributes = (FileAttributes) entry.ExternalFileAttributes;
							fileAttributes &= (FileAttributes.Archive | FileAttributes.Normal | FileAttributes.ReadOnly | FileAttributes.Hidden);
							File.SetAttributes(targetName, fileAttributes);
						}
#endif						
					}
					catch(Exception ex) {
						if ( events_ != null ) {
							continueRunning_ = events_.OnFileFailure(targetName, ex);
						}
						else {
                            continueRunning_ = false;
                            throw;
						}
					}
				}
			}
		}

		void ExtractEntry(ZipEntry entry)
		{
			bool doExtraction = entry.IsCompressionMethodSupported();
			string targetName = entry.Name;
			
			if ( doExtraction ) {
				if ( entry.IsFile ) {
					targetName = extractNameTransform_.TransformFile(targetName);
				}
				else if ( entry.IsDirectory ) {
					targetName = extractNameTransform_.TransformDirectory(targetName);
				}
				
				doExtraction = !((targetName == null) || (targetName.Length == 0));
			}
			

			string dirName = null;
			
			if ( doExtraction ) {
					if ( entry.IsDirectory ) {
						dirName = targetName;
					}
					else {
						dirName = Path.GetDirectoryName(Path.GetFullPath(targetName));
					}
			}
			
			if ( doExtraction && !Directory.Exists(dirName) ) {
				if ( !entry.IsDirectory || CreateEmptyDirectories ) {
					try {
						Directory.CreateDirectory(dirName);
					}
					catch (Exception ex) {
						doExtraction = false;
						if ( events_ != null ) {
							if ( entry.IsDirectory ) {
								continueRunning_ = events_.OnDirectoryFailure(targetName, ex);
							}
							else {
								continueRunning_ = events_.OnFileFailure(targetName, ex);
							}
						}
						else {
							continueRunning_ = false;
                            throw;
						}
					}
				}
			}
			
			if ( doExtraction && entry.IsFile ) {
				ExtractFileEntry(entry, targetName);
			}
		}

		static int MakeExternalAttributes(FileInfo info)
		{
			return (int)info.Attributes;
		}
		
#if NET_1_0 || NET_1_1 || NETCF_1_0
		static bool NameIsValid(string name)
		{
			return (name != null) &&
				(name.Length > 0) &&
				(name.IndexOfAny(Path.InvalidPathChars) < 0);
		}
#else
		static bool NameIsValid(string name)
		{
			return (name != null) &&
				(name.Length > 0) &&
				(name.IndexOfAny(Path.GetInvalidPathChars()) < 0);
		}
#endif
		#endregion
		
		#region Instance Fields
		bool continueRunning_;
		byte[] buffer_;
		ZipOutputStream outputStream_;
		ZipFile zipFile_;
		string sourceDirectory_;
		NameFilter fileFilter_;
		NameFilter directoryFilter_;
		Overwrite overwrite_;
		ConfirmOverwriteDelegate confirmDelegate_;
		
		bool restoreDateTimeOnExtract_;
		bool restoreAttributesOnExtract_;
		bool createEmptyDirectories_;
		FastZipEvents events_;
		IEntryFactory entryFactory_ = new ZipEntryFactory();
		INameTransform extractNameTransform_;
		UseZip64 useZip64_=UseZip64.Dynamic;
		
#if !NETCF_1_0
		string password_;
#endif	

		#endregion
	}
}
