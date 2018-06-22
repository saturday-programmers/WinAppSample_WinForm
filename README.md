# WinAppSample_WinForm

2018/7月PGK用サンプルコード（WindowsForms版）  

## 課題
以下の要求定義書、要件定義書を基にシステムを作る。

### 要求定義書
- 有理数の四則演算とべき乗、sin、cosの計算ができる電卓がほしい。
- Windowsの関数電卓は機能が多すぎて使いにくい。
- 将来的には業務で使う複雑な計算式も簡単に計算できるようにしたい。
- 四則演算は利用頻度が高い。


### 要件定義書
以下の機能を備えた簡易の関数電卓システムを構築する。  

#### 機能要件
- 四則演算とべき乗、sin、cosの計算ができる。
- 計算対象は整数と小数とする。

#### 非機能要件
- 計算パターンを今後追加する可能性があるので、追加時の拡張性を考慮した作りにする。
- 時間のかかる計算パターンが追加されることを考慮し、計算処理は非同期で行う。
- 四則演算は利用頻度が高いので、少ない操作回数で実行できるようにする。


## サンプルについて
### 環境
- .NET Framework 4.7.1
- C# 7.3
- 3層アーキテクチャ

### 参考ポイント
C#の各文法の特徴的な部分をできるだけ使うようにしてみました。  
辞書的に参考にする場合はそれぞれ以下の箇所を見て下さい。

#### プロパティ
- FrmMain.InputtableTextBoxes
- BizMain.IsCalculating

#### イベントハンドラ
- FrmMain.btnCalc_Click()
- FrmMain.btnCancel_Click()
- FrmMain.btnClear_Click()
- FrmMain.rbtnCalcPattern_CheckedChanged()
- FrmMain.cmbOtherCalcPattern_SelectedIndexChanged
- FrmMain.txtValue_TextChanged()

#### コントロールへのアクセス
- FrmMain.rbtnCalcPattern_CheckedChanged()
- FrmMain.txtValue_TextChanged()
- FrmMain.Initialize()
- FrmMain.SetRegularCalcPatternSign()
- FrmMain.SetOtherCalcPatternSign()
- FrmMain.Validate()
- FrmMain.ControlEnabledAll()

#### インターフェース
- ICalculator<T>

#### デリゲート
- FrmMain.rbtnCalcPattern_CheckedChanged()

#### ジェネリック
- AdditionCalculator<T>
- PowerCalculator<T>

#### 拡張メソッド
- EnumExtension.Name()

#### LINQ
- FrmMain.btnCalc_Click()
- FrmMain.EnableTextBoxes()
- FrmMain.Validate()
- FrmMain.ControlEnabledAll()

#### 非同期
- FrmMain.btnCalc_Click()
- FrmMain.btnCancel_Click()
- FrmMain.CancelCalculationAsync()
- BizMain.CalculateAsync()

#### ヴァリデーション
- FrmMain.Validate()

#### 可変長引数
- BizMain.CalculateAsync()
- BizMain.HasCorrectParameterCount()

#### 出力引数
- FrmMain.Validate()

#### オプション引数
- FrmMain.Validate()