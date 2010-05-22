using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{

	public sealed class StreamUtils
	{
	
		static public void ReadFully(Stream stream, byte[] buffer)
		{
			ReadFully(stream, buffer, 0, buffer.Length);
		}


		static public void ReadFully(Stream stream, byte[] buffer, int offset, int count)
		{
			if ( stream == null ) {
				throw new ArgumentNullException("stream");
			}

			if ( buffer == null ) {
				throw new ArgumentNullException("buffer");
			}

			if ( (offset < 0) || (offset > buffer.Length) ) {
				throw new ArgumentOutOfRangeException("offset");
			}

			if ( (count < 0) || (offset + count > buffer.Length) ) {
				throw new ArgumentOutOfRangeException("count");
			}

			while ( count > 0 ) {
				int readCount = stream.Read(buffer, offset, count);
				if ( readCount <= 0 ) {
					throw new EndOfStreamException();
				}
				offset += readCount;
				count -= readCount;
			}
		}


		static public void Copy(Stream source, Stream destination, byte[] buffer)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}

			if (destination == null) {
				throw new ArgumentNullException("destination");
			}

			if (buffer == null) {
				throw new ArgumentNullException("buffer");
			}

			if (buffer.Length < 128) {
				throw new ArgumentException("Buffer is too small", "buffer");
			}

			bool copying = true;

			while (copying) {
				int bytesRead = source.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0) {
					destination.Write(buffer, 0, bytesRead);
				}
				else {
					destination.Flush();
					copying = false;
				}
			}
		}


		static public void Copy(Stream source, Stream destination,
			byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name)
		{
			Copy(source, destination, buffer, progressHandler, updateInterval, sender, name, -1);
		}


		static public void Copy(Stream source, Stream destination,
			byte[] buffer, 
			ProgressHandler progressHandler, TimeSpan updateInterval, 
			object sender, string name, long fixedTarget)
		{
			if (source == null) {
				throw new ArgumentNullException("source");
			}

			if (destination == null) {
				throw new ArgumentNullException("destination");
			}

			if (buffer == null) {
				throw new ArgumentNullException("buffer");
			}

			if (buffer.Length < 128) {
				throw new ArgumentException("Buffer is too small", "buffer");
			}

			if (progressHandler == null) {
				throw new ArgumentNullException("progressHandler");
			}

			bool copying = true;

			DateTime marker = DateTime.Now;
			long processed = 0;
			long target = 0;

			if (fixedTarget >= 0) {
				target = fixedTarget;
			}
			else if (source.CanSeek) {
				target = source.Length - source.Position;
			}

			ProgressEventArgs args = new ProgressEventArgs(name, processed, target);
			progressHandler(sender, args);

			bool progressFired = true;

			while (copying) {
				int bytesRead = source.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0) {
					processed += bytesRead;
					progressFired = false;
					destination.Write(buffer, 0, bytesRead);
				}
				else {
					destination.Flush();
					copying = false;
				}

				if (DateTime.Now - marker > updateInterval) {
					progressFired = true;
					marker = DateTime.Now;
					args = new ProgressEventArgs(name, processed, target);
					progressHandler(sender, args);

					copying = args.ContinueRunning;
				}
			}

			if (!progressFired) {
				args = new ProgressEventArgs(name, processed, target);
				progressHandler(sender, args);
			}
		}


		private StreamUtils()
		{

		}
	}
}
