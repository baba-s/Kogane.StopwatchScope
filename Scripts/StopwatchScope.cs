using System;
using System.Diagnostics;

namespace UniStopwatchScope
{
	public sealed class StopwatchScope : IDisposable
	{
		public delegate void OnCompleteCallback( string name, TimeSpan elapsed );

		private readonly string             m_name;
		private readonly Stopwatch          m_stopwatch = new Stopwatch();
		private readonly OnCompleteCallback m_onComplete;

		public static event OnCompleteCallback OnComplete;

		public StopwatchScope( string name, OnCompleteCallback onComplete )
		{
			m_name       = name;
			m_onComplete = onComplete;

			m_stopwatch.Start();
		}

		public StopwatchScope( string name ) : this( name, null )
		{
		}

		public void Dispose()
		{
			m_stopwatch.Stop();
			var elapsed = m_stopwatch.Elapsed;
			m_onComplete?.Invoke( m_name, elapsed );
			OnComplete?.Invoke( m_name, elapsed );
		}
	}
}