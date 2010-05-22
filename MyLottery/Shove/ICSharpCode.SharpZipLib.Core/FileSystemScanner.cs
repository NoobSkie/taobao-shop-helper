using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	#region EventArgs
	
	public class ScanEventArgs : EventArgs
	{
		#region Constructors
	
		public ScanEventArgs(string name)
		{
			name_ = name;
		}
		#endregion
		
		
		public string Name
		{
			get { return name_; }
		}
		
		
		public bool ContinueRunning
		{
			get { return continueRunning_; }
			set { continueRunning_ = value; }
		}
		
		#region Instance Fields
		string name_;
		bool continueRunning_ = true;
		#endregion
	}

	
	public class ProgressEventArgs : EventArgs
	{
		#region Constructors
		
		public ProgressEventArgs(string name, long processed, long target)
		{
			name_ = name;
			processed_ = processed;
			target_ = target;
		}
		#endregion
		
		
		public string Name
		{
			get { return name_; }
		}
		
		
		public bool ContinueRunning
		{
			get { return continueRunning_; }
			set { continueRunning_ = value; }
		}

		
		public float PercentComplete
		{
			get
			{
				if (target_ <= 0)
				{
					return 0;
				}
				else
				{
					return ((float)processed_ / (float)target_) * 100.0f;
				}
			}
		}
		
	
		public long Processed
		{
			get { return processed_; }
		}

	
		public long Target
		{
			get { return target_; }
		}
		
		#region Instance Fields
		string name_;
		long processed_;
		long target_;
		bool continueRunning_ = true;
		#endregion
	}

	
	public class DirectoryEventArgs : ScanEventArgs
	{
		#region Constructors
		
		public DirectoryEventArgs(string name, bool hasMatchingFiles)
			: base (name)
		{
			hasMatchingFiles_ = hasMatchingFiles;
		}
		#endregion
		
		
		public bool HasMatchingFiles
		{
			get { return hasMatchingFiles_; }
		}
		
		#region Instance Fields
		bool hasMatchingFiles_;
		#endregion
	}
	
	
	public class ScanFailureEventArgs : EventArgs
	{
		#region Constructors
	
		public ScanFailureEventArgs(string name, Exception e)
		{
			name_ = name;
			exception_ = e;
			continueRunning_ = true;
		}
		#endregion
		
	
		public string Name
		{
			get { return name_; }
		}
		
	
		public Exception Exception
		{
			get { return exception_; }
		}
		
		
		public bool ContinueRunning
		{
			get { return continueRunning_; }
			set { continueRunning_ = value; }
		}
		
		#region Instance Fields
		string name_;
		Exception exception_;
		bool continueRunning_;
		#endregion
	}
	
	#endregion
	
	#region Delegates
	
	public delegate void ProcessDirectoryHandler(object sender, DirectoryEventArgs e);
	
	
	public delegate void ProcessFileHandler(object sender, ScanEventArgs e);

	
	public delegate void ProgressHandler(object sender, ProgressEventArgs e);


	public delegate void CompletedFileHandler(object sender, ScanEventArgs e);
	

	public delegate void DirectoryFailureHandler(object sender, ScanFailureEventArgs e);
	
	
	public delegate void FileFailureHandler(object sender, ScanFailureEventArgs e);
	#endregion

	
	public class FileSystemScanner
	{
		#region Constructors
		
		public FileSystemScanner(string filter)
		{
			fileFilter_ = new PathFilter(filter);
		}
		
		
		public FileSystemScanner(string fileFilter, string directoryFilter)
		{
			fileFilter_ = new PathFilter(fileFilter);
			directoryFilter_ = new PathFilter(directoryFilter);
		}
		
		
		public FileSystemScanner(IScanFilter fileFilter)
		{
			fileFilter_ = fileFilter;
		}
		
		
		public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
		{
			fileFilter_ = fileFilter;
			directoryFilter_ = directoryFilter;
		}
		#endregion

		#region Delegates
		
		public ProcessDirectoryHandler ProcessDirectory;
	
		public ProcessFileHandler ProcessFile;

		public CompletedFileHandler CompletedFile;

		public DirectoryFailureHandler DirectoryFailure;
	
		public FileFailureHandler FileFailure;
		#endregion

		
		bool OnDirectoryFailure(string directory, Exception e)
		{
            DirectoryFailureHandler handler = DirectoryFailure;
            bool result = (handler != null);
            if ( result ) {
				ScanFailureEventArgs args = new ScanFailureEventArgs(directory, e);
				handler(this, args);
				alive_ = args.ContinueRunning;
			}
            return result;
		}
		
		
		bool OnFileFailure(string file, Exception e)
		{
            FileFailureHandler handler = FileFailure;

            bool result = (handler != null);

			if ( result ){
				ScanFailureEventArgs args = new ScanFailureEventArgs(file, e);
				FileFailure(this, args);
				alive_ = args.ContinueRunning;
			}
            return result;
		}

		
		void OnProcessFile(string file)
		{
			ProcessFileHandler handler = ProcessFile;

			if ( handler!= null ) {
				ScanEventArgs args = new ScanEventArgs(file);
				handler(this, args);
				alive_ = args.ContinueRunning;
			}
		}

	
		void OnCompleteFile(string file)
		{
			CompletedFileHandler handler = CompletedFile;

			if (handler != null)
			{
				ScanEventArgs args = new ScanEventArgs(file);
				handler(this, args);
				alive_ = args.ContinueRunning;
			}
		}

	
		void OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			ProcessDirectoryHandler handler = ProcessDirectory;

			if ( handler != null ) {
				DirectoryEventArgs args = new DirectoryEventArgs(directory, hasMatchingFiles);
				handler(this, args);
				alive_ = args.ContinueRunning;
			}
		}


		public void Scan(string directory, bool recurse)
		{
			alive_ = true;
			ScanDir(directory, recurse);
		}
		
		void ScanDir(string directory, bool recurse)
		{

			try {
				string[] names = System.IO.Directory.GetFiles(directory);
				bool hasMatch = false;
				for (int fileIndex = 0; fileIndex < names.Length; ++fileIndex) {
					if ( !fileFilter_.IsMatch(names[fileIndex]) ) {
						names[fileIndex] = null;
					} else {
						hasMatch = true;
					}
				}
				
				OnProcessDirectory(directory, hasMatch);
				
				if ( alive_ && hasMatch ) {
					foreach (string fileName in names) {
						try {
							if ( fileName != null ) {
								OnProcessFile(fileName);
								if ( !alive_ ) {
									break;
								}
							}
						}
						catch (Exception e) {
                            if (!OnFileFailure(fileName, e)) {
                                throw;
                            }
						}
					}
				}
			}
			catch (Exception e) {
                if (!OnDirectoryFailure(directory, e)) {
                    throw;
                }
			}

			if ( alive_ && recurse ) {
				try {
					string[] names = System.IO.Directory.GetDirectories(directory);
					foreach (string fulldir in names) {
						if ((directoryFilter_ == null) || (directoryFilter_.IsMatch(fulldir))) {
							ScanDir(fulldir, true);
							if ( !alive_ ) {
								break;
							}
						}
					}
				}
				catch (Exception e) {
                    if (!OnDirectoryFailure(directory, e)) {
                        throw;
                    }
				}
			}
		}
		
		#region Instance Fields
	
		IScanFilter fileFilter_;
	
		IScanFilter directoryFilter_;
	
		bool alive_;
		#endregion
	}
}
