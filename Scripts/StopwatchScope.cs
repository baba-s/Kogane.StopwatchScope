using System;
using System.Diagnostics;

namespace UniStopwatchScope
{
	/// <summary>
	/// 経過時間を計測するクラス
	/// </summary>
	public sealed class StopwatchScope : IDisposable
	{
		//==============================================================================
		// デリゲート
		//==============================================================================
		public delegate void OnCompleteCallback( string name, TimeSpan elapsed );

		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private readonly string             m_name;
		private readonly Stopwatch          m_stopwatch = new Stopwatch();
		private readonly OnCompleteCallback m_onComplete;

		//==============================================================================
		// イベント(static)
		//==============================================================================
		public static event OnCompleteCallback OnComplete;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 計測を開始します
		/// </summary>
		public StopwatchScope( string name, OnCompleteCallback onComplete )
		{
			m_name       = name;
			m_onComplete = onComplete;

			m_stopwatch.Start();
		}

		/// <summary>
		/// 計測を開始します
		/// </summary>
		public StopwatchScope( string name ) : this( name, null )
		{
		}

		/// <summary>
		/// 計測を終了します
		/// </summary>
		public void Dispose()
		{
			m_stopwatch.Stop();
			var elapsed = m_stopwatch.Elapsed;
			m_onComplete?.Invoke( m_name, elapsed );
			OnComplete?.Invoke( m_name, elapsed );
		}
	}
}