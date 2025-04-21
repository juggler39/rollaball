# rollaball

# Когда вам нужно обновить сборку:
rm -rf deploy/*  # удаление старых файлов
cp -r Builds/Rollaball/* deploy/  # копирование новых файлов
git add deploy
git commit -m "Update game build"
git subtree push --prefix=deploy origin gh-pages