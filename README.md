# Rogue
目標：ランダム生成マップの実装<br>
参考サイト：
https://unity-shoshinsha.biz/archives/536
https://daeudaeu.com/c_create_maze/#:~:text=%E7%A9%B4%E6%8E%98%E3%82%8A%E6%B3%95%E3%81%A8%E3%81%AF%E3%81%BE%E3%81%95%E3%81%AB%E3%80%8C%E5%A3%81%E3%81%AB%E7%A9%B4%E3%82%92,%E8%BF%B7%E8%B7%AF%E3%82%92%E4%BD%9C%E6%88%90%E3%81%97%E3%81%BE%E3%81%99%E3%80%82
<br>
<br>
設計<br>
スタート地点を決める<br>
→壁以外の1地点<br>
<br>
1回目<br>
・乱数で4方向から進行方向を選ぶ<br>
・掘る量を1～3マスから選ぶ<br>
・掘り進める先が壁の場合は別の方向を選びなおす<br>
・決めた方向、量で掘る<br>
<br>
2回目以降<br>
・乱数で3方向から進行方向を選ぶ<br>
・掘る量を1～3マスから選ぶ<br>
・掘り進める先が壁や道の場合は別の方向を選びなおす<br>
・決めた方向、量で掘る<br>
<br>
掘れなくなったら処理終了<br>
<br>
