

namespace ICSharpCode.SharpZipLib.Zip.Compression 
{
	public class DeflaterPending : PendingBuffer
	{
		public DeflaterPending() : base(DeflaterConstants.PENDING_BUF_SIZE)
		{
		}
	}
}
