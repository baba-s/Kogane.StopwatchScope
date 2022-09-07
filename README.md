# Kogane Stopwatch Scope

経過時間を計測するクラス

## 使用例

```cs
StopwatchScope.OnStart += name =>
{
    Debug.Log( $"[Stopwatch]「{name}」開始" );
};
StopwatchScope.OnComplete += ( name, elapsed ) =>
{
    Debug.Log( $"[Stopwatch]「{name}」終了    {elapsed.TotalSeconds:0.00} 秒" );
};

using ( new StopwatchScope( "【ここにタグ名】" ) )
{
}
```