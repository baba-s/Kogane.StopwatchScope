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
		public delegate void OnStartCallback( string name );

		public delegate void OnCompleteCallback( string name, TimeSpan elapsed );

		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private readonly string    m_name;
		private readonly Stopwatch m_stopwatch = new Stopwatch();

		//==============================================================================
		// イベント(static)
		//==============================================================================
		public static event OnStartCallback    OnStart;
		public static event OnCompleteCallback OnComplete;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 計測を開始します
		/// </summary>
		public StopwatchScope( string name )
		{
			m_name = name;
			m_stopwatch.Start();
			OnStart?.Invoke( name );
		}

		/// <summary>
		/// 計測を終了します
		/// </summary>
		public void Dispose()
		{
			m_stopwatch.Stop();
			var elapsed = m_stopwatch.Elapsed;
			OnComplete?.Invoke( m_name, elapsed );
		}
	}
}