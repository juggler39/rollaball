# rollaball

![image](https://github.com/user-attachments/assets/56f8ff0e-c3c2-4115-9455-af16d535cd5e)


# Когда вам нужно обновить сборку:
rm -rf deploy/*  # удаление старых файлов
cp -r Builds/Rollaball/* deploy/  # копирование новых файлов
git add deploy
git commit -m "Update game build"
git subtree push --prefix=deploy origin gh-pages
