#### 概要
* 01 ( https://github.com/violakatze/api-docker-study-01 ) のコマンドマイグレーション版
* api実体は01より雑に作ってある

#### 実行
* プロジェクトルートで `docker-compose up -d`
* 初回実行時はmigration実行 `docker-compose run -rm migration`
* swaggerを使いたい場合はapiのコンテナを止めてからVisual Studioなりで実行(ソリューション構成は`Debug`で)

#### その他
* 要Docker Desktop
* 初回migration時、MySqlデータのダウンロードが完了していない場合にエラーが発生しうる
* mysql/data直下にDBデータの実体が作成される
